using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.repository;
using MPP_TeledonClientServer.services;

namespace server
{
    public class ServerService:ITeledonService
    {
        private VolunteerService volunteerService;
        private DonationService donationService;
        private readonly IList<ITeledonObserver> observers;

        public ServerService(VolunteerService volunteerService, DonationService donationService)
        {
            this.volunteerService = volunteerService;
            this.donationService = donationService;
            observers=new List<ITeledonObserver>();
        }

        public void login(ITeledonObserver client,string username, string password)
        {
            this.volunteerService.loginVolunteer(username, password);
            observers.Add(client);
        }

        public void saveDonation(int donorId, string name, string address, string telephone, double sum, int caseId)
        {
            this.donationService.saveDonation(donorId,name,address,telephone,sum,caseId);
            notifyVolunteers();
        }

        public IEnumerable<Donor> searchDonorByName(string substring)
        {
            return this.donationService.searchDonorByName(substring);
        }

        public IEnumerable<Case> getAllCases()
        {
            return this.donationService.getAllCases();
        }

        public void logout(ITeledonObserver client)
        {
            observers.Remove(client);
        }

        private void notifyVolunteers()
        {
            IEnumerable<Donor> donors = donationService.searchDonorByName("");
            IEnumerable<Case> cases = donationService.getAllCases();
            foreach (var observer in observers)
            {
                Task.Run(()=>observer.donationDone(donors,cases)) ;
            }
        }
    }
}