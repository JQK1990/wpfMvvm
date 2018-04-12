using System.Configuration;
using Common;

namespace MainProject
{
    public static class Settings
    {
        public static string SqlConnection;

        public static void LoadSetting()
        {
            SqlConnection = GetConnectString();
        }

        public static string GetConnectString()
        {
            string connection = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            connection = CodeEncrypt.Decrypt(connection);
            return connection;
        }

        public static void WriteSetting()
        {
            
        }
    }
}
