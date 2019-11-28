using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChungKhoan
{
    public partial class Form3 : Form
    {
        private int k = 0;
        List<string> List_Full = new List<string>();
        List<string> List_R = new List<string>();
        List<string> List_L = new List<string>();
        List<int> List_sup = new List<int>();
        List<int> List_supR = new List<int>();
        // List<string> list_ten = new List<string>();
        // List<KeyValuePair<string, string>> list_ten = new List<KeyValuePair<string, string>>();
        Dictionary<string, string> list_ten = new Dictionary<string, string>();

        public Form3(int k)
        {
            InitializeComponent();
            this.k = k;

            if (Form1.checkTangGiam == 1)
                label6.Text = "CÁC CỔ PHIẾU CÙNG TĂNG";
            else label6.Text = "CÁC CỔ PHIẾU CÙNG GIẢM";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Ten_CP();
            Sinh_Luat(k);
            Load_supR();
        }

        private List<string> Sinh_NhiPhan(int k)
        {
            List<string> listtemp = new List<string>();
            int n = k + 1;
            int[] mang = new int[n];
            int i;
            for (i = 0; i < n; i++)
            {
                mang[i] = 0;
            }
            for (i = n - 1; i >= 0; i--)
            {
                if (mang[i] == 0) 
                {
                    mang[i] = 1;  
                    int j;
                    string ss = "";
                    for (j = i + 1; j < n; j++) 
                    {
                        mang[j] = 0;
                    }               
                    for (j = 0; j < n; j++)
                    {
                        ss = ss + " " + mang[j];
                    }
                    listtemp.Add(ss.Trim());
                    i = n;
                }
            }
            return listtemp;
        }

        public void Sinh_Luat(int k)
        {
            for (int i = 0; i <= k; i++)
            {
                List<string> List_NP = new List<string>();
                List_NP = Sinh_NhiPhan(i);
                foreach (var l in Program.listTapL[i])
                {
                    if (i > 0)
                    {
                        string[] chuoiL = l.Key.Split(' ');
                        // Sinh_chuoi(List_NP, chuoiL, l.Key, l);
                        for (int j = 0; j < List_NP.Count - 1; j++)
                        {
                            string[] chuoi_np = List_NP[j].Split(' ');
                            int g = 0;
                            string ss = "";
                            string sss = "";
                            for (g = 0; g < chuoi_np.Length; g++)
                            {
                                if (chuoi_np[g].Equals("0"))
                                {
                                    ss = ss + " " + chuoiL[g];
                                }
                                if (chuoi_np[g].Equals("1"))
                                {
                                    sss = sss + " " + chuoiL[g];
                                }
                            }
                            List_L.Add(sss.Trim());
                            List_R.Add(ss.Trim());
                            List_Full.Add(l.Key);
                            List_sup.Add(l.Value);
                        }
                    }
                }
            }
            //foreach (string val in List_L)
            //{
            //    Console.WriteLine(val);
            //}
            //Console.WriteLine("---------------");
            //foreach (string val in List_R)
            //{
            //    Console.WriteLine(val);
            //}
            //Console.WriteLine("---------------");
            //foreach (string val in List_Full)
            //{
            //    Console.WriteLine(val);
            //}
            //Console.WriteLine("---------------");
            //foreach (int val in List_sup)
            //{
            //    Console.WriteLine(val);
            //}
        }
        public void Load_supR()
        {
            for (int i = 0; i < List_R.Count; i++)
            {
                //Load_TapL(k, List_R[i]);
                for (int j = 0; j <= k; j++)
                {
                    foreach (var l in Program.listTapL[j])
                    {
                        if (List_R[i].Trim().Equals(l.Key.Trim()))
                        {
                            // Console.WriteLine("---"+List_R[i] + "------" + l.Value);
                            List_supR.Add(l.Value);
                        }
                    }
                }
            }
        }

        private string getName(string a)
        {
            foreach (var str in list_ten)
            {

                if (str.Key.ToString().Equals(a.Trim()))
                {

                    return str.Value.ToString();
                }
            }
            return null;
        }

        private string getNameMaHoa(string a)
        {
            foreach (var str in Program.listMahoa)
            {

                if (str.maHoa == Int32.Parse(a.Trim()))
                {
                    return str.maCp;
                }
            }
            return null;
        }
        public void Ten_CP()
        {
            for (int i = 0; i < Program.listMahoa.Count; i++)
            {
                list_ten.Add(Program.listMahoa[i].maHoa.ToString(), getNameCP(Program.listMahoa[i].maCp.ToString()));
            }
        }
        private string getNameCP(string maCP)
        {
            SqlConnection conn = new SqlConnection(Program.connnectionString);
            conn.Open();
            string sql = "select TENCTY from COPHIEU where MACP='" + maCP + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return rdr.GetValue(0).ToString();
            }
            //conn.Close();
            return null;
        }
        public void Ket_Qua(int tb_conf)
        {
            lv_conf.Columns.Add("Stt");
            lv_conf.Columns.Add(" Luật sinh ra");
            //  lv_conf.Columns.Add(" Luật sinh ra");
            lv_conf.Columns.Add("MinConF %");
            int dem = 0;
            for (int i = 0; i < List_sup.Count; i++)
            {
                double conf = Math.Round(((double)List_sup[i] / List_supR[i]) * 100);
                ListViewItem lv_Item = new ListViewItem();
                string abc = "";
                string abcd = "";
                string bc = "";
                string bcd = "";
                if (conf >= tb_conf)
                {
                    dem = dem + 1;
                    string[] listtemp = List_R[i].Split(' ');
                    string[] listtemp1 = List_L[i].Split(' ');
                    int j = 0;
                    for (j = 0; j < listtemp.Length; j++)
                    {
                        abc = abc + ", " + getName(listtemp[j]);
                        bc = bc + ", " + getNameMaHoa(listtemp[j]);

                    }
                    for (j = 0; j < listtemp1.Length; j++)
                    {
                        abcd = abcd + ", " + getName(listtemp1[j]);
                        bcd = bcd + ", " + getNameMaHoa(listtemp1[j]);
                    }
                    lv_Item.Text = dem.ToString();
                    // lv_Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = List_supR[i].ToString() });
                    // lv_Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = List_sup[i].ToString() });
                    //lv_Item.Text = List_Full[i].Trim();
                    //  lv_Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = bc.Remove(0, 1) + " ==> " + bcd.Remove(0, 1) });
                    lv_Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = abc.Remove(0, 1) + " ==> " + abcd.Remove(0, 1) });
                    lv_Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = conf.ToString() + " %" });
                    lv_conf.Items.Add(lv_Item);
                    // Console.WriteLine(List_R[i] + "==>" + List_L[i] + "  : " + conf);

                }
            }
            lv_conf.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_conf.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lv_conf.Clear();
            Ket_Qua(tb_trackbar.Value);
        }
        //======================================================= //======================================================= //=======================================================
        private void Sinh_chuoi(List<string> List_NP, string[] chuoiL, string ls, KeyValuePair<string, int> l)
        {
            for (int j = 0; j < List_NP.Count - 1; j++)
            {
                string[] chuoi_np = List_NP[j].Split(' ');
                int g = 0;
                string ss = "";
                string sss = "";
                for (g = 0; g < chuoi_np.Length; g++)
                {
                    // int index = ls.IndexOf(chuoiL[g]);
                    // string s = ls.Remove(index); 
                    if (chuoi_np[g].Equals("0"))
                    {
                        ss = ss + " " + chuoiL[g];
                    }
                    if (chuoi_np[g].Equals("1"))
                    {
                        sss = sss + " " + chuoiL[g];
                    }
                }
                List_L.Add(sss.Trim());
                List_R.Add(ss.Trim());
                List_Full.Add(ls);
                List_sup.Add(l.Value);
            }
        }
        public void Load_TapL(int k, string List_R)
        {
            for (int i = 0; i <= k; i++)
            {
                foreach (var l in Program.listTapL[i])
                {
                    if (List_R.Trim().Equals(l.Key.Trim()))
                    {
                        // Console.WriteLine("---"+List_R[i] + "------" + l.Value);
                        List_supR.Add(l.Value);
                    }
                }
            }
        }
        private void tb_trackbar_Scroll(object sender, EventArgs e)
        {
            lb_conf.Text = tb_trackbar.Value + "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}