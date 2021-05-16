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
    class CtlPhongThi
    {
        private DataProvider dataProvider;

        public CtlPhongThi()
        {
            dataProvider = new DataProvider();
        }

        public List<PhongThi> getData(string search)
        {
            string query = "SELECT * FROM func_PT_Tim_Kiem (@In)";

            List<PhongThi> phongThi = new List<PhongThi>();
            DataTable dtb = dataProvider.excuteQuery(query, new SqlParam[] { new SqlParam("@In", search) });
            DataRowCollection drc = dtb.Rows;

            foreach (DataRow dr in drc)
            {
                phongThi.Add(new PhongThi(dr[0].ToString(), dr[1].ToString(), int.Parse(dr[2].ToString())));
            }

            return phongThi;
        }

        public int addData(string maPhongThi, string maLoaiPhongThi, int soChoNgoi)
        {
            string sql = "EXEC proc_PT_Them @MaPhongThi, @MaLoaiPhongThi, @SoChoNgoi, @Result OUT";

            SqlParam[] paramIn =
            {
                new SqlParam("@MaPhongThi", maPhongThi),
                new SqlParam("@MaLoaiPhongThi", maLoaiPhongThi),
                new SqlParam("@SoChoNgoi", soChoNgoi)
            };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(sql, paramIn, paramOut);

            //0: thêm thành công
            //- 1: dữ liệu trống
            // - 2: trùng mã phòng thi
            //-3: mã loại phòng thi không tồn tại

            return (int)res[0];
        }

        public int updateData(string maPhongThi, string maLoaiPhongThi, int soChoNgoi)
        {
            string proc = "EXEC proc_PT_Sua @MaPhongThi, @MaLoaiPhongThi, @SoChoNgoi, @Result OUT";

            SqlParam[] paramIn =
            {
                new SqlParam("@MaPhongThi", maPhongThi),
                new SqlParam("@MaLoaiPhongThi", maLoaiPhongThi),
                new SqlParam("@SoChoNgoi", soChoNgoi)
            };
            SqlParam[] paramOut = { new SqlParam("@Result", 1) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }

        public int deleteData(string maPhongThi)
        {
            string sql = "EXEC proc_PT_Xoa @MaPhongThi, @Result OUT";

            SqlParam[] paramIn = { new SqlParam("@MaPhongThi", maPhongThi) };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(sql, paramIn, paramOut);

            //0: xóa thành công
            //- 1: dữ liệu trống
            // - 2: không có mã phòng thi

            return (int)res[0];
        }
    }
}
