using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class DataProvider
    {
        private string connectionString = @"Data Source=DESKTOP-P5KS5H9\SQLEXPRESS;Initial Catalog=XepLichThi;Integrated Security=True";

        public DataProvider()
        {
             
        }

        private List<string> getListNameParameter(string query)
        {
            List<string> res = new List<string>();

            MatchCollection names = Regex.Matches(query, @"@(.*?)(?=[ ,)])");
            foreach(Match name in names)
            {
                if (res.Find(item => item == name.Value) != name.Value)
                    res.Add(name.Value);
            }
            return res;
        }

        public DataTable excuteQuery(string query, SqlParam[] parameter = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query,connection))
            {
                connection.Open();

                if (parameter != null)
                {
                    for(int i = 0; i < parameter.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parameter[i].Name, parameter[i].Value);
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int excuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    List<string> names = getListNameParameter(query + " ");
                    for (int i = 0; i < names.Count; i++)
                    {
                        command.Parameters.AddWithValue(names[i], parameter[i]);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object[] excuteProc(string procName, SqlParam[] parameterIn = null, SqlParam[] parameterOut = null)
        {
            object[] data = new object[parameterOut.Length];
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(procName, connection))
            {
                cmd.CommandType = CommandType.Text;

                if (parameterIn != null)
                {
                    for (int i=0; i<parameterIn.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parameterIn[i].Name, parameterIn[i].Value);
                    }
                }
                if (parameterOut != null)
                {
                    for (int i = 0; i < parameterOut.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parameterOut[i].Name, parameterOut[i].Value).Direction = ParameterDirection.Output;
                    }
                }

                Console.WriteLine(cmd.Parameters.Count);
                
                connection.Open();
                cmd.ExecuteNonQuery();

                for (int i = 0; i < parameterOut.Length; i++)
                {
                    data[i] = cmd.Parameters[parameterOut[i].Name].Value;
                }

                connection.Close();
            }
            return data;
        }
               
        public class SqlParam
        {
            public string Name;
            public object Value;
            public SqlParam(string name, object value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
