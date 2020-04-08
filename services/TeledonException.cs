using System;

namespace MPP_TeledonClientServer.services
{
    public class TeledonException:Exception
    {
        public TeledonException(string message) : base(message)
        {
        }
    }
}