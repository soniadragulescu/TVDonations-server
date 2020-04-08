using System;
using System.Collections.Generic;

namespace MPP_TeledonClientServer.model
{
    [Serializable]
    public class Donation/*:Entity<KeyValuePair<int, int>>*/
    {
        private KeyValuePair<int, int> id;

        public KeyValuePair<int, int> Id
        {
            get => id;
            set => id = value;
        }

        private int donorId;
        private double sum;
        private int caseId;


        public Donation(int donorId, double sum, int caseId)
        {
            this.Id=new KeyValuePair<int, int>(donorId,caseId);
            this.donorId = donorId;
            this.sum = sum;
            this.caseId = caseId;
        }

        public double Sum
        {
            get => sum;
            set => sum = value;
        }
    }
}