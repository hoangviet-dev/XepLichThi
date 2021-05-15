using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichThi.Models
{
    class TaiKhoan
    {
        public TaiKhoan(string userName, string password, int type)
        {
            UserName = userName;
            Password = password;
            Type = type;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

    }
}
