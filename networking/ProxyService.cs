using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.services;

namespace networking
{
    public class ProxyService:ITeledonService
    {
        private string host;
        private int port;

       private ITeledonObserver client;

       private NetworkStream stream;
       private IFormatter formatter;
       private TcpClient connection;
       private Queue<Response> responses;
       private volatile bool finished;
       private EventWaitHandle waitHandle;

       public ProxyService(string host, int port)
       {
           this.host = host;
           this.port = port;
           responses=new Queue<Response>();
       }

       public virtual void login(ITeledonObserver client,string username, string password)
        {
            initializeConnection();
            Volunteer volunteer=new Volunteer(username,password);
            sendRequest(new LoginRequest(volunteer));
            Response response = readResponse();
            if (response is OKResponse)
            {
                this.client = client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }

        }

        public virtual void saveDonation(int donorId, string name, string address, string telephone, double sum, int caseId)
        {
            sendRequest(new NewDonationRequest(donorId,name,address,telephone,sum,caseId));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }
            
        }

        public virtual IEnumerable<Donor> searchDonorByName(string substring)
        {
            sendRequest(new GetAllDonorsRequest(substring));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }

            GetAllDonorsResponse getAllDonorsResponse = (GetAllDonorsResponse) response;
            IEnumerable<Donor> donors = getAllDonorsResponse.Donors;
            return donors;
        }

        public virtual IEnumerable<Case> getAllCases()
        {
            sendRequest(new GetAllCasesRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }

            GetAllCasesResponse getAllCasesResponse = (GetAllCasesResponse) response;
            IEnumerable<Case> cases = getAllCasesResponse.Cases;
            return cases;
        }

        public virtual void logout(ITeledonObserver client)
        {
            sendRequest(new LogoutRequest());
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                connection.Close();
                waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new TeledonException("Error sending object "+e.Message);
            }
        }

        private Response readResponse()
        {
            Response response =null;
            try
            {
                waitHandle.WaitOne();
                lock (responses)
                {
                    response = responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void startReader()
        {
            Thread tw=new Thread(run);
            tw.Start();
        }

        private void handleUpdate(UpdateResponse update)
        {
            if (update is NewDonationResponse)
            {
                NewDonationResponse newDonationResponse = (NewDonationResponse) update;
                Console.WriteLine("New donation update...");
                try
                {
                    IEnumerable<Donor> donors = newDonationResponse.Donors;
                    IEnumerable<Case> cases = newDonationResponse.Cases;
                    client.donationDone(donors, cases);
                }
                catch (TeledonException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("Response recived " + response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse) response);
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue((Response) response);
                        }

                        waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e.Message);
                }
            }
        }
    }
}