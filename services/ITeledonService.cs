using System;
using System.Collections.Generic;
using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.services
{
    public interface ITeledonService
    {
        void login(ITeledonObserver client,String username, String password);
        void saveDonation(int donorId, string name, string address, string telephone,double sum, int caseId);
        IEnumerable<Donor> searchDonorByName(String substring);
        IEnumerable<Case> getAllCases();
        void logout(ITeledonObserver client);
    }
}