using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Google.Protobuf;
using MPP_TeledonClientServer.services;

namespace proto
{
    public class ProtoWorker:ITeledonObserver
    {
        private ITeledonService server;
        private TcpClient connection;

        private NetworkStream stream;
        //private IFormatter formatter;
        private volatile bool connected;

        public ProtoWorker(ITeledonService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
               // formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    Request request = Request.Parser.ParseDelimitedFrom(stream);//    formatter.Deserialize(stream);
                    //object response = handleRequest((Request) request);
                    Response response = handleRequest(request);
                    if (response != null)
                    {
                        sendResponse(response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private Response handleRequest(Request request)
        {
            //Response response = null;
            Request.Types.Type reqType = request.Type;
            switch (reqType)
            {
                case Request.Types.Type.Login:
                {
                    Console.WriteLine("Login request... ");
                    //LoginRequest loginRequest = (LoginRequest) request;
                    //Volunteer volunteer = loginRequest.Volunteer;
                    MPP_TeledonClientServer.model.Volunteer volunteer = ProtoUtils.getVoluneer(request);
                    try
                    {
                        lock (server)
                        {
                            server.login(this, volunteer.Username, volunteer.Password);
                        }

                        return ProtoUtils.createOKResponse();
                    }
                    catch (TeledonException e)
                    {
                        connected = false;
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case Request.Types.Type.Logout:
                {
                    Console.WriteLine("Logout request... ");
                    try
                    {
                        lock (server)
                        {
                            server.logout(this);
                        }

                        connected = false;
                        return ProtoUtils.createOKResponse();
                    }
                    catch (TeledonException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case Request.Types.Type.GetAllCases:
                {
                    Console.WriteLine("Get all cases request... ");
                    try
                    {
                        lock (server)
                        {
                            IEnumerable<MPP_TeledonClientServer.model.Case> cases = server.getAllCases();
                            return ProtoUtils.createGetAllCasesResponse(cases);
                        }
                    }
                    catch (TeledonException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case Request.Types.Type.GetAllDonors:
                {
                    Console.WriteLine("Get all donors request...");
                    string subtring = ProtoUtils.getSubstring(request);
                    try
                    {
                        lock (server)
                        {

                            IEnumerable<MPP_TeledonClientServer.model.Donor>
                                donors = server.searchDonorByName(subtring);
                            return ProtoUtils.createGetAllDonorsResponse(donors);
                        }
                    }
                    catch (TeledonException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case Request.Types.Type.NewDonation:
                {
                    Console.WriteLine("New donation request...");
                    int donorId = ProtoUtils.getDonorId(request);
                    String name = ProtoUtils.getName(request);
                    String address = ProtoUtils.getAddress(request);
                    String telephone = ProtoUtils.getTelephone(request);
                    Double sum = ProtoUtils.getSum(request);
                    int caseId = ProtoUtils.getCaseId(request);
                    try
                    {
                        lock (server)
                        {
                            server.saveDonation(donorId, name, address, telephone, sum, caseId);
                            return ProtoUtils.createOKResponse();
                        }
                    }
                    catch (TeledonException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }

            }

            return null;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("Sending response "+response);
            lock (stream)
            {
                response.WriteDelimitedTo(stream);
                stream.Flush();
            }
        }

        public void donationDone(IEnumerable<MPP_TeledonClientServer.model.Donor> donors, IEnumerable<MPP_TeledonClientServer.model.Case> cases)
        {
            Console.WriteLine("Donation done... ");
            try
            {
                sendResponse(ProtoUtils.createNewDonationResponse(donors, cases));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}