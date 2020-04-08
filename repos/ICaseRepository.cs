using System;
using System.Collections.Generic;
using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.repository
{
    public interface ICaseRepository
    {
        IEnumerable<Case> FindAll();
        Case FindOne(int id);

        void Update(double sum, int id);
    }
}