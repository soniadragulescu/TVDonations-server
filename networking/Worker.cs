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
    public class Worker:ITeledonObserver
    {
        private ITeledonService server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;

        public Worker(ITeledonService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
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
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request) request);
                    if (response != null)
                    {
                        sendResponse((Response) response);
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
            Response response = null;
            
            //LOGIN
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request... ");
                LoginRequest loginRequest = (LoginRequest) request;
                Volunteer volunteer = loginRequest.Volunteer;
                try
                {
                    lock (server)
                    {
                        server.login(this,volunteer.Username, volunteer.Password);
                    }

                    return new OKResponse();
                }
                catch (TeledonException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            //LOGOUT
            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request... ");
                LogoutRequest logoutRequest = (LogoutRequest) request;
                try
                {
                    lock (server)
                    {
                        server.logout(this);
                    }

                    connected = false;
                    return new OKResponse();
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            
            //GET ALL CASES
            if (request is GetAllCasesRequest)
            {
                Console.WriteLine("Get all cases request... ");
                GetAllCasesRequest getAllCasesRequest = (GetAllCasesRequest) request;
                try
                {
                    lock (server)
                    {
                        IEnumerable<Case> cases = server.getAllCases();
                        return new GetAllCasesResponse(cases);
                    }
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            
            //GET ALL DONORS
            if (request is GetAllDonorsRequest)
            {
                Console.WriteLine("Get all donors request...");
                GetAllDonorsRequest getAllDonorsRequest = (GetAllDonorsRequest) request;
                string subtring = getAllDonorsRequest.Substring;
                try
                {
                    lock (server)
                    {

                        IEnumerable<Donor> donors = server.searchDonorByName(subtring);
                        return new GetAllDonorsResponse(donors);
                    }
                }
                catch (TeledonException e)
                {
                    return  new ErrorResponse(e.Message);
                }
            }
            
            //NEW DONATION
            if (request is NewDonationRequest)
            {
                Console.WriteLine("New donation request...");
                NewDonationRequest newDonationRequest = (NewDonationRequest) request;
                int donorId = newDonationRequest.DonorId;
                String name = newDonationRequest.Name;
                String address = newDonationRequest.Address;
                String telephone=newDonationRequest.Telephone;
                Double sum=newDonationRequest.Sum;
                int caseId=newDonationRequest.CaseId;
                try
                {
                    lock (server)
                    {
                        server.saveDonation(donorId, name, address, telephone, sum, caseId);
                        return new OKResponse();
                    }
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("Sending response "+response);
            formatter.Serialize(stream,response);
            stream.Flush();
        }

        public void donationDone(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            Console.WriteLine("Donation done... ");
            try
            {
                sendResponse(new NewDonationResponse(donors, cases));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}