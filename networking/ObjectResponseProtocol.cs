using System;
using System.Collections.Generic;
using MPP_TeledonClientServer.model;

namespace networking
{
    public interface Response
    {
        
    }

    [Serializable]
    public class OKResponse : Response
    {
        
    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }
    }

    [Serializable]
    public class UpdateResponse : Response
    {
        
    }

    [Serializable]
    public class NewDonationResponse : UpdateResponse
    {
        private IEnumerable<Donor> donors;
        private IEnumerable<Case> cases;

        public NewDonationResponse(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            this.donors = donors;
            this.cases = cases;
        }

        public IEnumerable<Donor> Donors
        {
            get => donors;
            set => donors = value;
        }

        public IEnumerable<Case> Cases
        {
            get => cases;
            set => cases = value;
        }
    }

    [Serializable]
    public class GetAllDonorsResponse : Response
    {
        private IEnumerable<Donor> donors;

        public GetAllDonorsResponse(IEnumerable<Donor> donors)
        {
            this.donors = donors;
        }

        public IEnumerable<Donor> Donors
        {
            get => donors;
            set => donors = value;
        }
    }

    [Serializable]
    public class GetAllCasesResponse : Response
    {
        private IEnumerable<Case> cases;

        public GetAllCasesResponse(IEnumerable<Case> cases)
        {
            this.cases = cases;
        }

        public IEnumerable<Case> Cases
        {
            get => cases;
            set => cases = value;
        }
    }
}