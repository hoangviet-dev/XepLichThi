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
                mdXepLiches.Add(new mdXepLich(dataRow[0].ToString(), int.Parse(dataRow[1].ToString())));
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
            for (int i = 0; i < edge[a].Count; i++)
            {
                edge[edge[a][i]].Remove(a);
            }
            edge[0].RemoveRange(0, edge[a].Count);
        }
        private void coloring(ref List<List<int>> edge, Dictionary<string, int> key, ref List<mdXepLich> node)
        {
            int color = 0;
            while (true)
            {
                int maxDegNode = -1;
                int valMaxDegNode = 0;

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

                //Tim tap dinh co bac bang valMaxDegNode khong ke voi tap dinh tim duoc
                List<int> list = new List<int>();
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

                //Xoa canh trong list
                list.Add(maxDegNode);
                for (int i = 0; i < list.Count; i++)
                {
                    xoaCanh(ref edge, list[i]);
                }
            }
        }
        public List<mdXepLich> process(string namHoc, int hocKy)
        {
            List<mdXepLich> node = new List<mdXepLich>();
            List<List<int>> edge = new List<List<int>>();
            Dictionary<string, int> key = new Dictionary<string, int>();
            node = loadNode(namHoc, hocKy);
            key = markNode(node);
            edge = createEdge(key, namHoc, hocKy);
            coloring(ref edge, key, ref node);
            return node;
        }
    }
}
