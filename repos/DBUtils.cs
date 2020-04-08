﻿using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace MPP_TeledonClientServer.repository
{
    public class DBUtils
    {

        public DBUtils()
        {
        }

        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            string url = @"URI="+System.Configuration.ConfigurationSettings.AppSettings["database.url"];
            if (instance == null)
            {
                instance = new SQLiteConnection(url);
                instance.Open();
            }

            return instance;
        }
    }
}