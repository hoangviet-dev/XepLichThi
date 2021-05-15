using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class PhongThi
    {
        public PhongThi(string maPhongThi, string loaiPhongThi, int soChoNgoi)
        {
            MaPhongThi = maPhongThi;
            LoaiPhongThi = loaiPhongThi;
            SoChoNgoi = soChoNgoi;
        }

        [DisplayName("Mã phòng thi")]
        public string MaPhongThi { get; set; }

        [DisplayName("Loại phòng thi")]
        public string LoaiPhongThi { get; set; }

        [DisplayName("Số chỗ ngồi")]
        public int SoChoNgoi { get; set; }
    }
}
