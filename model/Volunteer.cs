using System;

namespace MPP_TeledonClientServer.model
{
    [Serializable]
    public class Volunteer
    {
        private string username;
        private string password;

        public Volunteer(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}