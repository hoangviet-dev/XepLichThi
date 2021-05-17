using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class LichThi
    {
        public LichThi(string maLichThi, string maLopHocPhan, DateTime ngayThi, int thoiGian, string maPhongThi, string hinhThuc)
        {
            MaLichThi = maLichThi;
            MaLopHocPhan = maLopHocPhan;
            NgayThi = ngayThi;
            ThoiGian = thoiGian;
            MaPhongThi = maPhongThi;
            HinhThuc = hinhThuc;
        }

        public string getData()
        {
            string st = "";
            st += MaLichThi + " ";
            st += MaLopHocPhan + " ";
            st += NgayThi.ToString() + " ";
            st += ThoiGian.ToString() + " ";
            st += MaPhongThi + " ";
            st += HinhThuc + " ";
            return st;
        }

        [DisplayName("Mã lịch thi")]
        public string MaLichThi { get; set; }

        [DisplayName("Mã lớp học phần")]
        public string MaLopHocPhan { get; set; }

        [DisplayName("Ngày thi")]
        public DateTime NgayThi { get; set; }

        [DisplayName("Thời gian")]
        public int ThoiGian { get; set; }

        [DisplayName("Mã phòng thi")]
        public string MaPhongThi { get; set; }

        [DisplayName("Hình thức")]
        public string HinhThuc { get; set; }
    }
}
