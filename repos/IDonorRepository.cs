using System.Collections.Generic;
using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.repository
{
    public interface IDonorRepository
    {
        IEnumerable<Donor> FindByName(string name);
        void Save(Donor donor);
        IEnumerable<Donor> FindAll();

        Donor FindOne(int id);
    }
}