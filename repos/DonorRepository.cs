﻿using System;
using System.Collections.Generic;
using System.Data;
using log4net;
 using MPP_TeledonClientServer.model;

 namespace MPP_TeledonClientServer.repository
{
   public class DonorRepository:IDonorRepository /*ICrudRepository<int,Donor>*/
    {
        private static readonly ILog log = LogManager.GetLogger("DonorRepository");
        public DonorRepository()
        {
            log.Info("DonorRepository");
        }
        
        public IEnumerable<Donor> FindByName(string substring)
        {
            log.InfoFormat("Entering findBYName with value {0}", substring);
            IDbConnection con = DBUtils.getConnection();
            IList<Donor> donors = new List<Donor>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donor Where Name Like '%" + substring + "%'";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        String address = dataR.GetString(2);
                        String telephone = dataR.GetString(3);
                        Donor donor = new Donor(idV, name, address, telephone);
                        log.InfoFormat("Exiting findBYName with value {0}", donor);
                        donors.Add(donor);
                    }
                }
            }
            //log.InfoFormat("Exiting findOne with value {0}", null);
            return donors;
        }

        public IEnumerable<Donor> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Donor> donors = new List<Donor>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donor";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        String address = dataR.GetString(2);
                        String telephone = dataR.GetString(3);
                        Donor donor = new Donor(idV, name, address, telephone);
                        donors.Add(donor);
                    }
                }
            }

            return donors;
        }

        public void Save(Donor entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Donor  values (@id,@name, @address, @telephone)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = entity.Name;
                comm.Parameters.Add(paramName);

                var paramAddress = comm.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = entity.Address;
                comm.Parameters.Add(paramAddress);

                var paramTelephone = comm.CreateParameter();
                paramTelephone.ParameterName = "@telephone";
                paramTelephone.Value = entity.Telephone;
                comm.Parameters.Add(paramTelephone);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No donor added !");
            }
        }

        public Donor FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donor where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        String address = dataR.GetString(2);
                        String telephone = dataR.GetString(3);
                        Donor donor = new Donor(idV, name, address, telephone);
                        log.InfoFormat("Exiting findOne with value {0}", donor);
                        return donor;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        /*public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Donor where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No donor deleted!");
            }
        }*/
    }
}