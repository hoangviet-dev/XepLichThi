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
    class CtlLopHocPhan
    {
        DataProvider dataProvider;
        public CtlLopHocPhan()
        {
            dataProvider = new DataProvider();
        }
        public List<LopHocPhan> getData(string search)
        {
            string query = "SELECT * FROM func_LopHP_Tim_Kiem(@search)";      
            List<LopHocPhan> llhp = new List<LopHocPhan>();
            DataTable dt = dataProvider.excuteQuery(query, new SqlParam[] { new SqlParam("@search", search) });
            DataRowCollection drc = dt.Rows;
            foreach (DataRow dr in drc)
            {
                llhp.Add(new LopHocPhan(dr[0].ToString(), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString()));
            }
            return llhp;
        }

        public int addData(string maHP, string tenHP, int soTC, string hinhThucThi)
        {
            int res = 0;
            string query = @"EXEC proc_LopHP_Them @MaLopHocPhan, @TenLopHocPhan, @SoTinChi, @HinhThucThi, @res OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaLopHocPhan", maHP)
                ,new SqlParam("@TenLopHocPhan", tenHP)
                ,new SqlParam("@SoTinChi", soTC)
                ,new SqlParam("@HinhThucThi", hinhThucThi)
            };

            SqlParam[] paramOut = {new SqlParam("@res", 0) };
            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);

            res = (int)obj[0];
            //0: thêm thành công
            //- 1: dữ liệu trống
            // - 2: trùng mã lớp học phần

            return res;
        }

        public int deleteData(string maHP)
        {
            int res = 0;
            string query = @"dbo.proc_LopHP_Xoa @MaLopHocPhan, @res OUTPUT";
            SqlParam[] paramIn = {new SqlParam("@MaLopHocPhan", maHP) };
            SqlParam[] paramOut = {new SqlParam("@res", 0) };

            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);
            res = (int)obj[0];

            //0: xóa thành công
            //- 1: dữ liệu trống
            // - 2: không có mã lớp học phần
            return res;
        }

        public int updateData(string maHP, string tenHP, int soTC, string hinhThucThi)
        {
            int res = 0;
            string query = @"EXEC proc_LopHP_Sua @MaLopHocPhan, @TenLopHocPhan, @SoTinChi, @HinhThucThi, @res OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaLopHocPhan", maHP)
                ,new SqlParam("@TenLopHocPhan", tenHP)
                ,new SqlParam("@SoTinChi", soTC)
                ,new SqlParam("@HinhThucThi", hinhThucThi)
            };

            SqlParam[] paramOut = { new SqlParam("@res", 0) };
            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);

            res = (int)obj[0];
            //0: sửa thành công
            //-1: dữ liệu trống
            //-2: không có mã lớp học phần

            return res;
        }
    }
}
