﻿using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.repository;

namespace MPP_TeledonClientServer.services
{
    public class VolunteerService
    {
        private IVolunteerRepository volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            this.volunteerRepository = volunteerRepository;
        }

        public Volunteer loginVolunteer(string username, string password)
        {  
            return this.volunteerRepository.FindOne(username, password);
        }
    }
}