﻿using System;
using System.Collections.Generic;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.repository;

namespace MPP_TeledonClientServer.services
{
    public class DonationService
    {
        private ICaseRepository caseRepository;
        private IDonorRepository donorRepository;
        private IDonationRepository donationRepository;

        public DonationService(ICaseRepository caseRepository, IDonorRepository donorRepository, IDonationRepository donationRepository)
        {
            this.caseRepository = caseRepository;
            this.donorRepository = donorRepository;
            this.donationRepository = donationRepository;
        }

        public void saveDonation(int donorId, string name, string address, string telephone,double sum, int caseId)
        {
            Case caz = this.caseRepository.FindOne(caseId);
            if (caz == null)
                throw new Exception("No case!");
            double totalSum = caz.TotalSum;
            totalSum = totalSum + sum;
            Donor donor = this.donorRepository.FindOne(donorId);
            if (donor == null)
            {
                this.saveDonor(donorId,name,address,telephone);
            }
            //caz.TotalSum = totalSum;
            this.updateCaseSum(totalSum,caz.Id);
            this.donationRepository.Save(new Donation(donorId,sum,caseId));
        }

        public void updateCaseSum(double sum, int id)
        {
            this.caseRepository.Update(sum, id);
        }
        public void saveDonor(int id, string name, string address, string telephone)
        {
            this.donorRepository.Save(new Donor(id,name,address,telephone));
        }

        public IEnumerable<Donor> searchDonorByName(string substring)
        {
            if (substring.Equals(""))
                return this.donorRepository.FindAll();
            else
            {
                return this.donorRepository.FindByName(substring);
            }
        }

        public IEnumerable<Case> getAllCases()
        {
            return this.caseRepository.FindAll();
        }
    }
}