using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;

namespace XepLichThi.Controllers
{
    class CtlLogin
    {
        DataProvider provider;
        public CtlLogin()
        {
            provider = new DataProvider();
        }

        public bool CheckLogin(string username, string password)
        {
            string sql = "select * from TaiKhoan where UserName = @UserName and Password = @Password";
            object[] param = { username, password};
            DataTable data = provider.excuteQuery(sql, param);
            return data.Rows.Count>0;
        }

    }
}
