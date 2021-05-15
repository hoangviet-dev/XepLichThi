using System;
using System.Collections.Generic;
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
        public string MaPhongThi { get; set; }
        public string LoaiPhongThi { get; set; }
        public int SoChoNgoi { get; set; }
    }
}
