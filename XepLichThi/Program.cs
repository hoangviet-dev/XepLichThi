using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XepLichThi.Models;
using XepLichThi.Views;

namespace XepLichThi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //List<LichThi> listLichThi = new List<LichThi>();
            //Controllers.XepLich xepLich = new Controllers.XepLich();
            //DateTime dateTime = new DateTime(2020, 12, 1);
            //int hk = 1;
            //int nh = dateTime.Year;
            //int nt = nh + 1;
            //string namhoc = nh.ToString() + "-" + nt.ToString();
            //if (hk > 1 || (hk == 1 && dateTime.Month < 3))
            //{
            //    nt = nh - 1;
            //    namhoc = nt.ToString() + "-" + nh.ToString();
            //}
            //listLichThi = xepLich.process(namhoc, hk, dateTime);
        }
    }
}
