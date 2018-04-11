using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public static class DbHelper
    {
        /// <summary>
        /// 获取局域网内的所有数据库服务器名称
        /// </summary>
        /// <returns>服务器名称数组</returns>
        public static List<string> GetSqlServerNames()
        {
            var enumerator = SqlClientFactory.Instance.CreateDataSourceEnumerator();
            if (enumerator != null)
            {
                DataTable dataSources = enumerator.GetDataSources();

                DataColumn column = dataSources.Columns["InstanceName"];
                DataColumn column2 = dataSources.Columns["ServerName"];

                DataRowCollection rows = dataSources.Rows;
                List<string> serverlist = new List<string>();
                for (int i = 0; i < rows.Count; i++)
                {
                    string str2 = rows[i][column2] as string;
                    string str = rows[i][column] as string;
                    string array;
                    if (((str == null) || (str.Length == 0)) || ("MSSQLSERVER" == str))
                    {
                        array = str2;
                    }
                    else
                    {
                        array = str2 + @"/" + str;
                    }

                    serverlist.Add(array);
                }

                serverlist.Sort();

                return serverlist;
            }
            return null;
        }

        /// <summary>
        /// 查询sql中的非系统库
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static List<string> GetdatabaseList(string connection)
        {
            List<string> getCataList = new List<string>();
            string cmdStirng = "select name from sys.databases where database_id > 4";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(cmdStirng, connect);
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    IDataReader dr = cmd.ExecuteReader();
                    getCataList.Clear();
                    while (dr.Read())
                    {
                        getCataList.Add(dr["name"].ToString());
                    }
                    dr.Close();
                }

            }
            catch (SqlException)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Dispose();
                }
            }
            return getCataList;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static List<string> GetTables(string connection)
        {
            List<string> tablelist = new List<string>();
            SqlConnection objConnetion = new SqlConnection(connection);
            try
            {
                if (objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Open();
                    DataTable objTable = objConnetion.GetSchema("Tables");
                    foreach (DataRow row in objTable.Rows)
                    {
                        tablelist.Add(row[2].ToString());
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                if (objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Dispose();
                }

            }
            return tablelist;
        }

        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetColumnField(string connection, string tableName)
        {
            List<string> columnlist = new List<string>();
            SqlConnection objConnetion = new SqlConnection(connection);
            try
            {
                if (objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Open();
                }

                SqlCommand cmd = new SqlCommand("Select Name FROM SysColumns Where id=Object_Id('" + tableName + "')", objConnetion);
                SqlDataReader objReader = cmd.ExecuteReader();

                while (objReader.Read())
                {
                    columnlist.Add(objReader[0].ToString());

                }
            }
            catch
            {
                // ignored
            }
            objConnetion.Close();
            return columnlist;
        }
    }
}
