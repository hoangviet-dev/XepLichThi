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
    class CtlDieuKien
    {
        DataProvider dataProvider;
        public CtlDieuKien()
        {
            dataProvider = new DataProvider();
        }
        public List<DieuKien> getData(string search)
        {
            List<DieuKien> dieuKiens = new List<DieuKien>();

            string query = "SELECT * FROM func_DK_Tim_Kiem(@Search)";
            SqlParam[] sqlParams = { new SqlParam("@Search", search) };

            DataTable dataTable = dataProvider.excuteQuery(query, sqlParams);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach(DataRow dataRow in dataRowCollection)
            {
                dieuKiens.Add(new DieuKien(dataRow[0].ToString(),
                                            dataRow[1].ToString(),
                                            int.Parse(dataRow[2].ToString())));
            }
            return dieuKiens;
        }
        public int addDieuKien(string maDieuKien, string tenDieuKien, int soBuoiNghi)
        {
            string proc = "EXEC proc_DK_Them @MaDieuKien, @TenDieuKien, @SoBuoiNghi, @Result OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaDieuKien", maDieuKien),
                new SqlParam("@TenDieuKien", tenDieuKien),
                new SqlParam("@SoBuoiNghi", soBuoiNghi)
            };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }
        public int updateDieuKien(string maDieuKien, string tenDieuKien, int soBuoiNghi)
        {
            string proc = "EXEC proc_DK_Sua @MaDieuKien, @TenDieuKien, @SoBuoiNghi, @Result OUT";
            SqlParam[] paramIn =
            {
                new SqlParam("@MaDieuKien", maDieuKien),
                new SqlParam("@TenDieuKien", tenDieuKien),
                new SqlParam("@SoBuoiNghi", soBuoiNghi)
            };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }
        public int deleteDieuKien(string maDieuKien)
        {
            string proc = "EXEC proc_DK_Xoa @MaDieuKien, @Result OUT";
            SqlParam[] paramIn = { new SqlParam("@MaDieuKien", maDieuKien) };
            SqlParam[] paramOut = { new SqlParam("@Result", 0) };

            object[] res = dataProvider.excuteProc(proc, paramIn, paramOut);

            return (int)res[0];
        }
    }
}
