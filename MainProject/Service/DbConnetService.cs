using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using Common;

namespace MainProject.Service
{
    public class DbConnetService
    {
        public bool TestConnection(string serverName,string userName,string password,string dbName)
        {
            
            EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
            ecb.Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
            ecb.Provider = "System.Data.SqlClient";
            ecb.ProviderConnectionString = string.Format("data source={0};initial catalog= {1};persist security info=True;user id={2};password={3};multipleactiveresultsets=True;App=EntityFramework",serverName,dbName,userName,password);
            return DbHelper.TestConnect(ecb.ConnectionString);

        }

        public List<string> GetDataBase(string serverName, string userName, string password, string dbName = "master")
        {
            try
            {
                EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
                ecb.Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
                ecb.Provider = "System.Data.SqlClient";
                ecb.ProviderConnectionString = string.Format("data source={0};initial catalog= {1};persist security info=True;user id={2};password={3};multipleactiveresultsets=True;App=EntityFramework", serverName, dbName, userName, password);
                return DbHelper.GetdatabaseList(ecb.ConnectionString);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
