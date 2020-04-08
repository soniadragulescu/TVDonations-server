﻿﻿using System;
 using System.Data;
 using log4net;
 using MPP_TeledonClientServer.model;

 namespace MPP_TeledonClientServer.repository
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private static readonly ILog log = LogManager.GetLogger("VolunteerRepository");
        public VolunteerRepository()
        {
            log.Info("VolunteerRepository");
        }
        public Volunteer FindOne(string username, string password)
        {
            log.InfoFormat("Entering findOne with value {0}, {1}", username,password);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Volunteer where Username=@username and Password=@password";
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);
                
                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = username;
                comm.Parameters.Add(paramPassword);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String user = dataR.GetString(0);
                        String pass = dataR.GetString(1);
                        Volunteer volunteer = new Volunteer( user, pass);
                        log.InfoFormat("Exiting findOne with value {0}", volunteer);
                        return volunteer;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }
    }
}