using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class LopHocPhan
    {
        public LopHocPhan(string maLopHocPhan, string tenLopHocPhan, int soTinChi)
        {
            MaLopHocPhan = maLopHocPhan;
            TenLopHocPhan = tenLopHocPhan;
            SoTinChi = soTinChi;
        }

        public string MaLopHocPhan { get; set; }
        public string TenLopHocPhan { get; set; }
        public int SoTinChi { get; set; }

    }

}
