using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class SinhVien
    {
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public DateTime NgaySinh { get; set; }
 
        public SinhVien(string maSinhVien, string tenSinhVien, DateTime ngaySinh)
        {
            MaSinhVien = maSinhVien;
            TenSinhVien = tenSinhVien;
            NgaySinh = ngaySinh;
        }
    }
}
