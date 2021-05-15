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

            MatchCollection names = Regex.Matches(query, @"@(.*?)(?=[ ,])");
            foreach(Match name in names)
            {
                res.Add(name.Value);
            }
            return res;
        }

        public DataTable excuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query,connection);
                if (parameter != null)
                {
                    List<string> names = getListNameParameter(query + " ");
                    for(int i = 0; i < names.Count; i++)
                    {
                        command.Parameters.AddWithValue(names[i], parameter[i]);
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
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

        public object excuteProc(string procName, List<SqlParam> parameter = null)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(procName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    foreach (SqlParam param in parameter)
                    {
                        cmd.Parameters.AddWithValue("@" + param.Name, param.Value);
                    }
                }
                data = cmd.ExecuteReader();
                connection.Close();
            }
            return data;
        }

        public class SqlParam
        {
            public string Name;
            public string Value;
            public SqlParam(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
