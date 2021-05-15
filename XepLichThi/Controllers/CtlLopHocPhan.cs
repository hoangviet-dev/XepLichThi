using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;

namespace XepLichThi.Controllers
{
    class CtlLopHocPhan
    {
        DataProvider provider;
        public CtlLopHocPhan()
        {
            provider = new DataProvider();
        }
        public List<LopHocPhan> GetData(string search)
        {
            search = "%" + search + "%";
            string query = @"select * from LopHocPhan where MaLopHocPhan like @search or TenLopHocPhan like @search";      
            List<LopHocPhan> llhp = new List<LopHocPhan>;
            object[] para = { search };
            DataTable dt = provider.excuteQuery(query,para);
            DataRowCollection drc = dt.Rows;
            foreach (DataRow dr in drc)
            {
                llhp.Add(new LopHocPhan(dr[0].ToString(), dr[1].ToString(), int.Parse((string)dr[2])));
            }
            return llhp;
        }
    }
}
