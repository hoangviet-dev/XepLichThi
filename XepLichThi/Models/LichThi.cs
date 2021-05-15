using System;
using System.Collections.Generic;
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

        public string MaLichThi { get; set; }
        public string MaLopHocPhan { get; set; }
        public DateTime NgayThi { get; set; }
        public int ThoiGian { get; set; }
        public string MaPhongThi { get; set; }
        public string HinhThuc { get; set; }
    }
}
