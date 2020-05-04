using System.Collections.Generic;
using System.Dynamic;

namespace proto
{
    public class ProtoUtils
    {
        public static Request createLoginRequest(MPP_TeledonClientServer.model.Volunteer volunteer)
        {
            Volunteer protoVolunteer=new Volunteer{Username = volunteer.Username, Password = volunteer.Password};
            Request request = new Request {Type = Request.Types.Type.Login, Volunteer = protoVolunteer};
            return request;
        }

        public static Request createLogoutRequest()
        {
            Request request = new Request {Type = Request.Types.Type.Logout};
            return request;
        }

        public static Request createNewDonationRequest(int donorId, string name, string address, string telephone, double sum, int caseId)
        {
            Request request = new Request {DonorId = donorId, Name = name, Telephone = telephone, Sum = sum,CaseId = caseId, Type = Request.Types.Type.NewDonation};
            return request;
        }

        public static Response createOKResponse()
        {
            Response response=new Response{Type = Response.Types.Type.Ok};
            return response;
        }

        public static Response createErrorResponse(string text)
        {
            Response response = new Response { Type = Response.Types.Type.Error, Error = text};
            return response;
        }

        public static Response createNewDonationResponse(IEnumerable<MPP_TeledonClientServer.model.Donor> donors, IEnumerable<MPP_TeledonClientServer.model.Case> cases)
        {
            Response response=new Response{Type = Response.Types.Type.Update};
            foreach (MPP_TeledonClientServer.model.Donor donor in donors)
            {
                Donor protoDonor = new Donor {Id = donor.Id,Name = donor.Name, Address = donor.Address, Telephone = donor.Address};
                response.Donors.Add(protoDonor);
            }

            foreach (MPP_TeledonClientServer.model.Case caz in cases)
            {
                Case protoCase = new Case {Id = caz.Id, Name = caz.Name, Sum = caz.TotalSum};
                response.Cases.Add(protoCase);
            }

            return response;
        }

        public static Response createGetAllCasesResponse(IEnumerable<MPP_TeledonClientServer.model.Case> cases)
        {
            Response response=new Response{Type = Response.Types.Type.GetAllCases};
            foreach (MPP_TeledonClientServer.model.Case caz in cases)
            {
                Case protoCase = new Case {Id = caz.Id, Name = caz.Name, Sum = caz.TotalSum};
                response.Cases.Add(protoCase);
            }

            return response;
        }

        public static Response createGetAllDonorsResponse(IEnumerable<MPP_TeledonClientServer.model.Donor> donors)
        {
            Response response=new Response{Type = Response.Types.Type.GetAllDonors};
            foreach (MPP_TeledonClientServer.model.Donor donor in donors)
            {
                Donor protoDonor = new Donor {Id = donor.Id, Name = donor.Name, Address = donor.Address, Telephone = donor.Telephone};
                response.Donors.Add(protoDonor);
            }

            return response;
        }

        public static MPP_TeledonClientServer.model.Volunteer getVoluneer(Request request)
        {
            MPP_TeledonClientServer.model.Volunteer volunteer =
                new MPP_TeledonClientServer.model.Volunteer(request.Volunteer.Username, request.Volunteer.Password);
            return volunteer;
        }

        public static int getDonorId(Request request)
        {
            return request.DonorId;
        }

        public static string getName(Request request)
        {
            return request.Name;
        }

        public static string getAddress(Request request)
        {
            return request.Address;
        }

        public static string getTelephone(Request request)
        {
            return request.Telephone;
        }

        public static double getSum(Request request)
        {
            return request.Sum;
        }

        public static int getCaseId(Request request)
        {
            return request.CaseId;
        }

        public static string getSubstring(Request request)
        {
            return request.Substring;
        }
    }
}