﻿﻿using log4net;
 using MPP_TeledonClientServer.model;

 namespace MPP_TeledonClientServer.repository
{
    public class DonationRepository:IDonationRepository
        {
            private static readonly ILog log = LogManager.GetLogger("DonationRepository");
            public DonationRepository()
            {
                log.Info("DonationRepository");
            }
            public void Save(Donation entity)
            {
                var con = DBUtils.getConnection();

                using (var comm = con.CreateCommand())
                {
                    comm.CommandText = "insert into Donation  values (@donorId, @sum, @caseId)";
                    var paramDonorId = comm.CreateParameter();
                    paramDonorId.ParameterName = "@donorId";
                    paramDonorId.Value = entity.Id.Key;
                    comm.Parameters.Add(paramDonorId);

                    var paramSum = comm.CreateParameter();
                    paramSum.ParameterName = "@sum";
                    paramSum.Value = entity.Sum;
                    comm.Parameters.Add(paramSum);

                    var paramCaseId = comm.CreateParameter();
                    paramCaseId.ParameterName = "@caseId";
                    paramCaseId.Value = entity.Id.Value;
                    comm.Parameters.Add(paramCaseId);

                    var result = comm.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No donation added !");
                }
            }
        }
    }