using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class LopHocPhan
    {
        public LopHocPhan(string maLopHocPhan, string tenLopHocPhan, int soTinChi, string hinhThucThi)
        {
            MaLopHocPhan = maLopHocPhan;
            TenLopHocPhan = tenLopHocPhan;
            SoTinChi = soTinChi;
            HinhThucThi = hinhThucThi;
        }

        [DisplayName("Mã lớp học phần")]
        public string MaLopHocPhan { get; set; }

        [DisplayName("Tên lớp học phần")]
        public string TenLopHocPhan { get; set; }

        [DisplayName("Số tín chỉ")]
        public int SoTinChi { get; set; }
        public string HinhThucThi { get; set; }
    }

}
