using System;
using System.Collections.Generic;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.services;
using networking;

namespace MPP_TeledonClientServer
{
    public class Controller:ITeledonObserver
    {
        private readonly ITeledonService server;
        public event EventHandler<NewDonationResponse> updateEvent;
        public Controller(ITeledonService server)
        {
            this.server = server;
        }

        public Volunteer login(string username, string password)
        {
            this.server.login(this,username,password);
            Console.WriteLine("Login succeded... ");
            return new Volunteer(username,password);
        }

        public void saveDonation(int donorId, string name, string address, string telephone, double sum, int caseId)
        {
            this.server.saveDonation(donorId,name,address,telephone,sum,caseId);
            Console.WriteLine("New donation done... ");
        }

        public IEnumerable<Donor> searchDonorByName(string substring)
        {
            return server.searchDonorByName(substring);
        }

        public IEnumerable<Case> getAllCases()
        {
            return server.getAllCases();
        }

        public void logout()
        {
            server.logout(this);
        }

        public void donationDone(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            NewDonationResponse response=new NewDonationResponse(donors,cases);
            if (updateEvent == null)
            {
                return;
            }
            else
            {
                updateEvent(this, response);
            }
        }
    }
    
}