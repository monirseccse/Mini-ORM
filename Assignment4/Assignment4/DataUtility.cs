using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class DataUtility : IDataUtility
    {
        private readonly string _conncectionstring;
        public DataUtility()
        {
            _conncectionstring = "Server=.\\SQLEXPRESS;Database=Practice;User Id=monir;Password=123456;";
        }
        public void ExecuteCommand(string command, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection=new SqlConnection(_conncectionstring))
            {
                using (SqlCommand sqlcommand=new SqlCommand(command,connection))
                {
                    try
                    {
                        if(connection.State!=ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        if(parameters != null)
                        {
                            foreach (var item in parameters)
                            {
                                sqlcommand.Parameters.Add(new SqlParameter(item.Key, item.Value));
                            }
                        }
                        sqlcommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        public List<Dictionary<string, object>> DataRead(string command, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_conncectionstring))
            {
                using (SqlCommand sqlcommand = new SqlCommand(command, connection))
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        if (parameters != null)
                        {
                            foreach (var item in parameters)
                            {
                                sqlcommand.Parameters.Add(new SqlParameter(item.Key, item.Value));
                            }
                        }
                       using SqlDataReader reader= sqlcommand.ExecuteReader();
                        List<Dictionary<string, object>>Lists=new List<Dictionary<string, object>>();
                        while(reader.Read())
                        {
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dic.Add(reader.GetName(i),reader.GetValue(i));
                            }
                            Lists.Add(dic);
                        }
                        return Lists;
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
