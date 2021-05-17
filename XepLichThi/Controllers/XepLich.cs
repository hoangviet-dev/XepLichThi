using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepLichThi.Models;
using static XepLichThi.Models.DataProvider;

namespace XepLichThi.Controllers
{
    class XepLich
    {
        DataProvider DataProvider;
        public XepLich()
        {
            DataProvider = new DataProvider();
        }
        private List<mdXepLich> loadNode(string namHoc, int hocKy)
        {
            List<mdXepLich> mdXepLiches = new List<mdXepLich>();

            string query = "SELECT * FROM func_Danh_Sach_Lop_Hoc_Phan(@NamHoc, @HocKy)";
            SqlParam[] sqlParams =
            {
                new SqlParam("@NamHoc", namHoc),
                new SqlParam("@HocKy", hocKy)
            };
            DataTable dataTable = DataProvider.excuteQuery(query, sqlParams);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach (DataRow dataRow in dataRowCollection)
            {
                mdXepLiches.Add(new mdXepLich(dataRow[0].ToString(), int.Parse(dataRow[1].ToString()), dataRow[2].ToString()));
            }
            return mdXepLiches;
        }
        private Dictionary<string, int> markNode(List<mdXepLich> mdXepLiches)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            int cnt = -1;
            foreach (mdXepLich mdXepLich in mdXepLiches)
            {
                keyValuePairs.Add(mdXepLich.MaLopHocPhan, ++cnt);
            }
            return keyValuePairs;
        }
        private List<List<int>> createEdge(Dictionary<string, int> keyValuePairs, string namHoc, int hocKy)
        {
            List<List<int>> myList = new List<List<int>>();

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                myList.Add(new List<int>());
            }

            string query = "SELECT * FROM func_Danh_Sach_Lop_Hoc_Phan_Trung(@NamHoc,@HocKy)";
            SqlParam[] sqlParams =
            {
                new SqlParam("@NamHoc",namHoc),
                new SqlParam("@HocKy",hocKy)
            };
            DataTable dataTable = DataProvider.excuteQuery(query, sqlParams);
            DataRowCollection dataRowCollection = dataTable.Rows;
            foreach (DataRow dataRow in dataRowCollection)
            {
                string hp1 = dataRow[0].ToString();
                string hp2 = dataRow[1].ToString();
                Console.WriteLine("?" + hp1 + " " + keyValuePairs[hp1]);
                Console.WriteLine("?" + hp2 + " " + keyValuePairs[hp2]);
                myList[keyValuePairs[hp1]].Add(keyValuePairs[hp2]);
            }
            return myList;
        }
        private bool checkKe(List<List<int>> edge, int a, int b)
        {
            for (int i = 0; i < edge[a].Count; i++)
            {
                if (edge[a][i] == b) return true;
            }
            return false;
        }
        private bool checkKeTapDinh(List<List<int>> edge, List<int> list, int a)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (checkKe(edge, list[i], a) == true) return true;
            }
            return false;
        }
        private void xoaCanh(ref List<List<int>> edge, int a)
        {
            for (int i = edge[a].Count - 1; i >= 0; i--)
            {
                edge[edge[a][i]].Remove(a);
                edge[a].RemoveAt(i);
            }
        }
        private int coloring(ref List<List<int>> edge, Dictionary<string, int> key, ref List<mdXepLich> node)
        {
            int color = 0;
            while (true)
            {
                int maxDegNode = -1;
                int valMaxDegNode = -1;

                //Tim node co bac cao nhat
                for (int i = 0; i < node.Count; i++)
                {
                    if (node[i].Color != 0) continue;
                    if (edge[i].Count > valMaxDegNode)
                    {
                        maxDegNode = i;
                        valMaxDegNode = edge[i].Count;
                    }
                }
                if (maxDegNode == -1) break;

                //To mau cho dinh tim duoc
                node[maxDegNode].Color = ++color;

                Console.WriteLine("~" + maxDegNode);

                //Tim tap dinh co bac bang valMaxDegNode khong ke voi tap dinh tim duoc
                List<int> list = new List<int>();
                list.Add(maxDegNode);
                for (int i = maxDegNode + 1; i < node.Count; i++)
                {
                    if (edge[i].Count == valMaxDegNode && node[i].Color == 0)
                    {
                        if (checkKeTapDinh(edge, list, i) == false)
                        {
                            list.Add(i);
                            node[i].Color = color;
                        }
                    }
                }

                for (int i = 0; i < list.Count; i++) Console.WriteLine("!" + list[i]);

                //Xoa canh trong list
                for (int i = 0; i < list.Count; i++)
                {
                    xoaCanh(ref edge, list[i]);
                }
            }
            return color;
        }
        private bool checkIn(List<int> list, int a)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (a == list[i]) return true;
            }
            return false;
        }
        public void distrubute(ref List<mdXepLich> node, List<PhongThi> listRoom, int numColor, DateTime fromDate)
        {
            List<List<int>> room = new List<List<int>>();
            int suatThiMin = 1;
            for (int i = 0; i < listRoom.Count; i++) room.Add(new List<int>());
            for (int color = 1; color <= numColor; color++)
            {
                List<mdXepLich> listSameColor = new List<mdXepLich>();
                foreach (mdXepLich mdXepLich in node)
                {
                    if (mdXepLich.Color == color)
                    {
                        listSameColor.Add(mdXepLich);
                    }
                }
                int suatThi = suatThiMin;
                List<int> availableRoom = new List<int>();
                foreach (mdXepLich mon in listSameColor)
                {
                    int seatNeed = mon.SiSo;
                    int seatHave = 0;
                    Console.WriteLine("-> " + mon.MaLopHocPhan);
                    Console.WriteLine("@@@" + seatNeed.ToString() + " " + seatHave.ToString());
                    int numListRoom = listRoom.Count;
                    while (seatHave < seatNeed)
                    {
                        for (int i = 0; i < numListRoom; i++)
                        {
                            if (checkIn(room[i], suatThi) == false && listRoom[i].LoaiPhongThi.Contains(mon.HinhThuc))
                            {
                                availableRoom.Add(i);
                                seatHave += listRoom[i].SoChoNgoi;
                                mon.SuatThi = suatThi;
                                mon.Phong = i;
                                room[i].Add(suatThi);
                                if (seatHave >= seatNeed) break;
                            }
                        }
                        if (seatHave >= seatNeed) break;
                        suatThi++;
                    }
                    suatThiMin = suatThi + 1;
                    Console.WriteLine(seatHave);
                }
            }
        }
        public List<LichThi> calRoom(ref List<mdXepLich> node, int numColor, DateTime fromDate)
        {
            CtlPhongThi ctlPhongThi = new CtlPhongThi();
            List<PhongThi> listRoom = ctlPhongThi.getData("");
            Console.WriteLine("^" + listRoom.Count.ToString());
            distrubute(ref node, listRoom, numColor, fromDate);

            List<LichThi> listLich = new List<LichThi>();
            DateTime date = fromDate;
            TimeSpan timeAm = new TimeSpan(7, 30, 0);
            TimeSpan timePm = new TimeSpan(14, 0, 0);

            int bias = 0;
            Console.WriteLine(fromDate.ToString());
            Console.WriteLine(fromDate.DayOfWeek.ToString());
            switch (fromDate.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    fromDate = fromDate.Date.AddDays(-1);
                    bias = 2;
                    break;
                case DayOfWeek.Wednesday:
                    fromDate = fromDate.Date.AddDays(-2);
                    bias = 4;
                    break;
                case DayOfWeek.Thursday:
                    fromDate = fromDate.Date.AddDays(-3);
                    bias = 6;
                    break;
                case DayOfWeek.Friday:
                    fromDate = fromDate.Date.AddDays(-4);
                    bias = 8;
                    break;
                case DayOfWeek.Saturday:
                    fromDate = fromDate.Date.AddDays(-5);
                    bias = 10;
                    break;
            }
            Console.WriteLine("#" + bias.ToString());
            int cnt = 0;
            foreach (mdXepLich mon in node)
            {
                Console.WriteLine("-" + (mon.SuatThi + bias).ToString());
                int weekAdd = (mon.SuatThi + bias) / 13;
                int dayAdd = (mon.SuatThi + bias - weekAdd * 13 - 1) / 2;
                date = fromDate;
                date = date.AddDays(dayAdd);
                date = date.AddDays(weekAdd * 7);

                date = date.Date + (mon.SuatThi % 2 == 1 ? timeAm : timePm);

                string maLichThi = mon.MaLopHocPhan.Substring(0, 12) + (++cnt).ToString();

                listLich.Add(new LichThi(
                                            maLichThi,
                                            mon.MaLopHocPhan,
                                            date,
                                            60,
                                            listRoom[mon.Phong].MaPhongThi,
                                            mon.HinhThuc
                                            ));
            }
            return listLich;
        }
        public List<LichThi> process(string namHoc, int hocKy, DateTime fromDate)
        {
            List<mdXepLich> node = new List<mdXepLich>();
            List<List<int>> edge = new List<List<int>>();
            Dictionary<string, int> key = new Dictionary<string, int>();
            Console.WriteLine("Start load node...");
            node = loadNode(namHoc, hocKy);
            Console.WriteLine("Finish load node...");

            Console.WriteLine("Start mark node...");
            key = markNode(node);
            Console.WriteLine("Finish mark node...");

            Console.WriteLine("Start coloring...");
            edge = createEdge(key, namHoc, hocKy);
            int numColor = coloring(ref edge, key, ref node);
            Console.WriteLine("Finish coloring...");

            Console.WriteLine("Start calRoom...");
            List<LichThi> listLichThi = new List<LichThi>();
            listLichThi = calRoom(ref node, numColor, fromDate);
            Console.WriteLine("Finish coloring...");
            return listLichThi;
        }

    }
}
