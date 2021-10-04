using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;
using static XepLichThi.Models.DataProvider;

namespace XepLichThi.Controllers
{
    class CtlLichThi
    {
        DataProvider dataPovider;

        public CtlLichThi()
        {
            dataPovider = new DataProvider();
        }

        public List<string> getNamHoc()
        {
            List<string> namHocs = new List<string>();
            string query = "SELECT * FROM func_Danh_Sach_Nam_Hoc()";
            DataTable dataTable = dataPovider.excuteQuery(query);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach (DataRow item in dataRowCollection)
            {
                namHocs.Add(item[0].ToString());
            }
            return namHocs;
        }

        public List<LichThi> getDataMaLichThi(string maLichThi, String fromDate = null, string toDate = null)
        {
            List<LichThi> ls = new List<LichThi>();

            string query = "SELECT * FROM func_Lich_Thi_TK_Ma (@MaLichThi, @FromDatem, @ToDate)";

            SqlParam[] param =
            {
                new SqlParam("@MaLichThi", maLichThi),
                new SqlParam("@FromDate", fromDate == null ? "null" : fromDate),
                new SqlParam("@ToDate", toDate == null ? "null" : toDate)
            };

            DataTable dataTable = dataPovider.excuteQuery(query, param);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach(DataRow dataRow in dataRowCollection)
            {
                ls.Add(new LichThi(
                                dataRow[0].ToString(),
                                dataRow[1].ToString(),
                                DateTime.Parse(dataRow[2].ToString()),
                                int.Parse(dataRow[3].ToString()),
                                dataRow[4].ToString(),
                                dataRow[5].ToString()));
            }
            return ls;
        }
    }
}
