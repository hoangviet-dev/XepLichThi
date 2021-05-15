using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;
using static XepLichThi.Models.DataProvider;

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
            //string sql = "select * from TaiKhoan where UserName = @UserName and Password = @Password";
            //object[] param = { username, password};
            //DataTable data = provider.excuteQuery(sql, param);
            //return data.Rows.Count>0
            //---------------
            //int res = 0;
            //string sql = "proc_TK_Dang_Nhap";

            //SqlParameter[] ParamIn = new SqlParameter[2];
            //SqlParameter[] ParamOut = new SqlParameter[1];

            //ParamIn[0] = new SqlParameter("@UserName", username);
            //ParamIn[1] = new SqlParameter("@Password", password);

            //ParamOut[0] = new SqlParameter("@Type", res);

            //object[] khoa = provider.excuteProc(sql, ParamIn, ParamOut);
            //Console.WriteLine(khoa);
            //return false;
            //int res = provider.executeLogin(username, password);
            //Console.WriteLine(res);

            string sql = "EXEC proc_TK_Dang_Nhap @UserName,@Password,@Type OUT";

            SqlParam[] paramIn =
            {
                new SqlParam("@UserName", username),
                new SqlParam("@Password", password)
            };

            SqlParam[] paramOut = { new SqlParam("@Type", 1) };

            object[] data = provider.excuteProc(sql, paramIn, paramOut);

            Console.WriteLine(data);
            return false;
        }

    }
}
