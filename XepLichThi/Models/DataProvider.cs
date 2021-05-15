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
        private string connectionString = @"Data Source=BAOLAPTOP;Initial Catalog=XepLichThi;Integrated Security=True";
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

        public DataTable excuteQuery(string query, List<object> parameter = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query,connection);
                if (parameter != null)
                {
                    List<string> names = getListNameParameter(query);
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

        public int excuteNonQuery(string query, List<object> parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    List<string> names = getListNameParameter(query);
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
    }
}
