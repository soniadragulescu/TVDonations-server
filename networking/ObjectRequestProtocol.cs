using System;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.services;

namespace networking
{
    public interface Request
    {
        
    }

    [Serializable]
    public class LoginRequest : Request
    {
        private Volunteer volunteer;

        public LoginRequest(Volunteer volunteer)
        {
            this.volunteer = volunteer;
        }

        public Volunteer Volunteer
        {
            get => volunteer;
            set => volunteer = value;
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        
    }

    [Serializable]
    public class NewDonationRequest : Request
    {
        private int donorId;
        private String name;
        private String address;
        private String telephone;
        private Double sum;
        private int caseId;

        public NewDonationRequest(int donorId, string name, string address, string telephone, double sum, int caseId)
        {
            this.donorId = donorId;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
            this.sum = sum;
            this.caseId = caseId;
        }

        public int DonorId
        {
            get => donorId;
            set => donorId = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        public double Sum
        {
            get => sum;
            set => sum = value;
        }

        public int CaseId
        {
            get => caseId;
            set => caseId = value;
        }
    }

    [Serializable]
    public class GetAllCasesRequest : Request
    {
        
    }

    [Serializable]
    public class GetAllDonorsRequest : Request
    {
        private String substring;

        public GetAllDonorsRequest(string substring)
        {
            this.substring = substring;
        }

        public string Substring
        {
            get => substring;
            set => substring = value;
        }
    }
}