using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class LoaiPhongThi
    {
        public LoaiPhongThi(string MaLoaiPhongThi, string LoaiPhongThi, string ChiTiet)
        {
            maLoaiPhongThi = MaLoaiPhongThi;
            loaiPhongThi = LoaiPhongThi;
            chiTiet = ChiTiet;
        }
        public string maLoaiPhongThi { get; set; }
        public string loaiPhongThi { get; set; }
        public string chiTiet { get; set; }

    }
}
