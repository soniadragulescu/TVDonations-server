﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.repository
{
    public class CaseRepository:ICaseRepository /*ICrudRepository<int,Case>*/
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CaseRepository()
        {
            log.Info("CaseRepository");
        }

        public Case FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cases where id=@id";
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
                        double totalSum = dataR.GetDouble(2);
                        Case caz =new Case(idV, name, totalSum);
                        log.InfoFormat("Exiting findOne with value {0}", caz);
                        return caz;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void Update(double sum, int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Cases set TotalSum=@sum where Id=@id";
                IDbDataParameter paramSum = comm.CreateParameter();
                paramSum.ParameterName = "@sum";
                paramSum.Value = sum;
                comm.Parameters.Add(paramSum);
                
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No case updated!");
            }
        }

        public IEnumerable<Case> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Case> cases = new List<Case>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cases";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        double totalSum = dataR.GetDouble(2);
                        Case caz =new Case(idV, name, totalSum);
                        cases.Add(caz);
                    }
                }
            }

            return cases;
        }
        
    }
}