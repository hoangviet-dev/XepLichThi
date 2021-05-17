using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class mdXepLich
    {
        public mdXepLich(string maLopHocPhan, int siSo, int suatThi = 0, int color = 0, int phong = 0, string hinhThuc = "")
        {
            MaLopHocPhan = maLopHocPhan;
            SiSo = siSo;
            SuatThi = suatThi;
            Color = color;
            Phong = phong;
            HinhThuc = hinhThuc;
        }
        public string getData()
        {
            string st = MaLopHocPhan + " ";
            st = st + SiSo.ToString() + " ";
            st = st + Color.ToString() + " ";
            st = st + SuatThi.ToString() + " ";
            st = st + Phong.ToString() + " ";
            return st;
        }
        public string MaLopHocPhan { get; set; }
        public int SiSo { get; set; }
        public int SuatThi { get; set; }
        public int Color { get; set; }
        public int Phong { get; set; }
        public string HinhThuc { get; set; }
    }
}
