using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class SinhVien
    {
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [DisplayName("Tên sinh viên")]
        public string TenSinhVien { get; set; }

        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
 
        public SinhVien(string maSinhVien, string tenSinhVien, DateTime ngaySinh)
        {
            MaSinhVien = maSinhVien;
            TenSinhVien = tenSinhVien;
            NgaySinh = ngaySinh;
        }
    }
}
