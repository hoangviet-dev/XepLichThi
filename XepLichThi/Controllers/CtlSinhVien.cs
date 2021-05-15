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
    class CtlSinhVien
    {
        private DataProvider dataProvider;

        public CtlSinhVien()
        {
            dataProvider = new DataProvider();
        }

        public List<SinhVien> getData(string search)
        {
            DataTable table;
            List<SinhVien> list = new List<SinhVien>();
            string query = @"SELECT * FROM func_SV_Tim_Kiem(@search)";
            table = dataProvider.excuteQuery(query, new object[]{search});
            DataRowCollection rows = table.Rows;
            foreach(DataRow row in rows)
            {
                list.Add(new SinhVien(row[0].ToString(), row[1].ToString(), DateTime.Parse(row[2].ToString())));
            }
            return list;
        }

        public int addData(string maSV, string ten, DateTime ngay)
        {
            int res = 0;
            string query = @"EXEC proc_SV_Them @MaSinhVien, @TenSinhVien, @NgaySinh, @res OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaSinhVien", maSV)
                ,new SqlParam("@TenSinhVien", ten)
                ,new SqlParam("@NgaySinh", ngay)
            };

            SqlParam[] paramOut =
            {
                new SqlParam("@res", 0)
            };
            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);
            res = (int)obj[0];
            /*
                0: thành công
                -1: dữ liệu trống
                -2: trùng mã
             */
            return res;
        }

        public int deleteData(string maSV)
        {
            int res = 0;
            string query = @"EXEC proc_SV_Xoa @MaSinhVien, @res";
            SqlParam[] paramIn = {new SqlParam(@"MaSinhVien", maSV) };
            SqlParam[] paramOut = { new SqlParam("@res", 0) };

            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);

            res = (int)obj[0];
            /*
                0: thành công
                -1: dữ liệu trống
                -2: k tìm thấy mã
             */
            return res;
        }

        public int updateData(string maSV, string ten, DateTime ngay)
        {
            int res = 0;
            string query = @"EXEC proc_SV_Sua @MaSinhVien, @TenSinhVien, @NgaySinh, @res OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaSinhVien", maSV)
                ,new SqlParam("@TenSinhVien", ten)
                ,new SqlParam("@NgaySinh", ngay)
            };

            SqlParam[] paramOut =
            {
                new SqlParam("@res", 0)
            };
            object[] obj = dataProvider.excuteProc(query, paramIn, paramOut);
            res = (int)obj[0];
            /*
                0: thành công
                -1: dữ liệu trống
                -2: k tìm thấy mã
             */ 
            return res;
        }
    }
}
