using System;

namespace MPP_TeledonClientServer.model
{
    [Serializable]
    public class Donor:Entity<int>
    {
        private string name;
        private string address;
        private string telephone;

        public Donor(int id,string name, string address, string telephone) : base(id)
        {
            this.name = name;
            this.address = address;
            this.telephone = telephone;
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
    }
}