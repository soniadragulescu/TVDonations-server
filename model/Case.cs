using System;

namespace MPP_TeledonClientServer.model
{
    [Serializable]
    public class Case:Entity<int>
    {
        private string name;
        private double totalSum;

        public Case(int id, string name, double totalSum) : base(id)
        {
            this.name = name;
            this.totalSum = totalSum;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double TotalSum
        {
            get => totalSum;
            set => totalSum = value;
        }
    }
}