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
    class CtlLoaiPhongThi
    {
        DataProvider dataProvider;
        public CtlLoaiPhongThi()
        {
            dataProvider = new DataProvider();
        }
        public List<LoaiPhongThi> getData(string search)
        {
            List<LoaiPhongThi> loaiPhongThis = new List<LoaiPhongThi>();

            string query = "SELECT * FROM func_LPT_Tim_Kiem(@Search)";
            SqlParam[] sqlParams =
            {
                new SqlParam("@Search", search)
            };

            DataTable dataTable = dataProvider.excuteQuery(query, sqlParams);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach (DataRow dataRow in dataRowCollection)
            {
                loaiPhongThis.Add(new LoaiPhongThi( dataRow[0].ToString(),
                                                    dataRow[1].ToString(),
                                                    dataRow[2].ToString()));
            }
            return loaiPhongThis;
        }
        public int addData(string maLoaiPhongThi, string loaiPhongThi, string chiTiet)
        {
            string proc = "EXEC proc_LPT_Them @MaLoaiPhongThi, @LoaiPhongThi, @ChiTiet, @Result OUT";
            SqlParam[] sqlParamIns =
            {
                new SqlParam("@MaLoaiPhongThi", maLoaiPhongThi),
                new SqlParam("@LoaiPhongThi", loaiPhongThi),
                new SqlParam("@chiTiet", chiTiet)
            };
            SqlParam[] sqlParamOuts = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, sqlParamIns, sqlParamOuts);

            return (int)res[0];
        }
        public int deleteData(string maLoaiPhongThi)
        {
            string proc = "EXEC proc_LPT_Xoa @MaLoaiPhongThi, @Result OUT";
            SqlParam[] paramIn = { new SqlParam("@MaLoaiPhongThi", maLoaiPhongThi) };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }
        public int updateData(string maLoaiPhongThi, string loaiPhongThi, string chiTiet)
        {
            string proc = "EXEC proc_LPT_Sua @MaLoaiPhongThi, @LoaiPhongThi, @ChiTiet, @Result OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaLoaiPhongThi", maLoaiPhongThi),
                new SqlParam("@LoaiPhongThi", loaiPhongThi),
                new SqlParam("@ChiTiet", chiTiet)
            };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }
    }
}
