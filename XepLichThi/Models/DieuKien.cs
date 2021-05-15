using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class DieuKien
    {
        public DieuKien(string maDieuKien, string tenDieuKien, int soBuoiNghi)
        {
            MaDieuKien = maDieuKien;
            TenDieuKien = tenDieuKien;
            SoBuoiNghi = soBuoiNghi;
        }

        public string MaDieuKien { get; set; }
        public string TenDieuKien { get; set; }
        public int SoBuoiNghi { get; set; }
    }
}
