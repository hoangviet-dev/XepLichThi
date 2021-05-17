using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Application.Run(new Main());
            //List<mdXepLich> list = new List<mdXepLich>();
            //XepLich xepLich = new XepLich();
            //DateTime dateTime = new DateTime(2021, 5, 15);
            //int numColor = 0;
            //list = xepLich.process("2020-2021", 2, ref numColor);
            //Console.WriteLine(numColor);
            //foreach(mdXepLich md in list)
            //{
            //    md.HinhThuc = "VD";
            //}

            //List<LichThi> listLichThi = new List<LichThi>();
            //listLichThi = xepLich.calRoom(ref list, numColor, dateTime);

            //foreach(mdXepLich mon in list)
            //{
            //    Console.WriteLine(mon.getData());
            //}

            //foreach (LichThi lichThi in listLichThi)
            //{
            //    Console.WriteLine("=" + lichThi.getData());
            //}
        }
    }
}
