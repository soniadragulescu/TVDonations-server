using System;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.repository;
using MPP_TeledonClientServer.services;


namespace server
{
    public class StartServer
    {

        static void Main(string[] args)
        {
            VolunteerRepository volunteerRepository=new VolunteerRepository();
            VolunteerService volunteerService=new VolunteerService(volunteerRepository);
                        
            DonorRepository donorRepository=new DonorRepository();
            DonationRepository donationRepository=new DonationRepository();
            CaseRepository caseRepository=new CaseRepository();
            DonationService donationService=new DonationService(caseRepository,donorRepository,donationRepository);
            
            // Volunteer volunteer = volunteerRepository.FindOne("admin", "admin");
            // Console.WriteLine("voluntar: "+volunteer.Username);
            
            ServerService serverService=new ServerService(volunteerService,donationService);
            SerialServer server = new SerialServer("127.0.0.1", 55555, serverService);
            server.Start();
            Console.WriteLine("Server started... ");
            
        }
        
    }
}