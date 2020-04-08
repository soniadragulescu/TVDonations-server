using System.Collections.Generic;
using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.services
{
    public interface ITeledonObserver
    {
        void donationDone(IEnumerable<Donor> donors, IEnumerable<Case> cases);
    }
}