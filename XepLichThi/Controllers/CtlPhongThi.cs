using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;

namespace XepLichThi.Controllers
{
    class CtlPhongThi
    {
        private DataProvider dataProvider;

        public CtlPhongThi()
        {
            dataProvider = new DataProvider();
        }

        public List<PhongThi> getData(string search)
        {
            List<PhongThi> res = new List<PhongThi>();

            string query = @"SELECT PT.MaPhongThi, LPT.LoaiPhongThi, PT.SoChoNgoi 
                            FROM PhongThi AS PT
	                        JOIN LoaiPhongThi AS LPT ON PT.MaLoaiPhongThi = LPT.MaLoaiPhongThi
	                        WHERE PT.MaPhongThi LIKE @search or LPT.LoaiPhongThi LIKE @search";

            search = "%" + search + "%";
            DataTable dataTable = dataProvider.excuteQuery(query, new object[] { search });
            DataRowCollection rows = dataTable.Rows;
            foreach(DataRow row in rows)
            {
                res.Add(new PhongThi(row[0].ToString(), row[1].ToString(), int.Parse(row[2].ToString())));
            }

            return res;
        }

        public int deleteData(string MaPhongThi)
        {
            int res = 0;

            return res;
        }
    }
}
