using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;

namespace XepLichThi.Controllers
{
    class CtlSinhVien
    {
        private DataProvider data;

        public CtlSinhVien()
        {
            this.data = new DataProvider();
        }

        public List<SinhVien> getData(string search)
        {
            DataTable table;
            List<SinhVien> list = new List<SinhVien>();
            string query = @"SELECT * FROM SinhVien WHERE MaSinhVien like @search or TenSinhVien like @search";
            search = "%" + search + "%";
            table = data.excuteQuery(query, new object[]{search});
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
            string query = @"INSERT INTO SinhVien VALUES (@ma, @ten, @ngay)";

            res = data.excuteNonQuery(query, new object[] { maSV, ten, ngay });
            return res;
        }

        public int deleteData(string maSV)
        {
            int res = 0;
            string query = @"DELETE FROM SinhVien WHERE MaSinhVien = @maSV";
            res = data.excuteNonQuery(query, new object[] { maSV });

            return res;
        }

        public int updateData(string maSV, string ten, DateTime ngay)
        {
            int res = 0;
            string query = @"
                                UPDATE SinhVien
                                SET TenSinhVien = @ten, NgaySinh = @ngay
                                WHERE MaSinhVien = @ma";
            res = data.excuteNonQuery(query, new object[] { ten, ngay, maSV });
            return res;
        }
    }
}
