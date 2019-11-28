using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChungKhoan
{
    public partial class Form2 : Form
    {

        private ListView listViewTapD;
        private ListView listViewMaHoa;
        private List<int> listKhoiTao;
        private int k;
        private string tempChar;
        private List<string> listToTapL;
        private int SoUngVien;
        private int countPre;

        public Form2(ListView listViewD, ListView listViewDetail)
        {
            InitializeComponent();

            listViewTapD = new ListView();
            listViewMaHoa = new ListView();
            listKhoiTao = new List<int>();
            listToTapL = new List<string>();
            k = 0;
            countPre = 0;
            tempChar = "";
            SoUngVien = Program.listMahoa.Count;

            this.listViewTapD = listViewD;
            this.listViewMaHoa = listViewDetail;

            listView1.Columns.Add("NGAY");
            listView1.Columns.Add("UNG VIEN");

            listView2.Columns.Add("UNG VIEN");
            listView2.Columns.Add("SUPPORT");

            KhoiTaoTapF1();
            KhoiTaoTapL1();

            button1.Enabled = false;

        }

        private void TapFToListView(model.TapF tapf)
        {
            listView1.Items.Clear();
            int i = 0;
            StringBuilder strBuild = new StringBuilder();
            label2.Text = tapf.Lable;
            foreach (var t in tapf)
            {

                foreach (string str in t.Value)
                {
                    strBuild.Append(str);
                    strBuild.Append(", ");
                }
                if (strBuild.Length == 0)
                {
                    strBuild.Append(", ");
                }
                strBuild.Length--;
                strBuild.Length--;

                listView1.Items.Add(t.Key);
                listView1.Items[i++].SubItems.Add(strBuild.ToString());
                
                strBuild.Clear();
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void TapLToListView(model.TapL tapl)
        {
            listView2.Items.Clear();
            label3.Text = tapl.Lable;
            int i = 0;
            foreach (var t in tapl)
            {
               
                listView2.Items.Add(t.Key);
                listView2.Items[i++].SubItems.Add(t.Value.ToString());

            }
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void KhoiTaoTapF1()
        {
            model.TapF tapf = new model.TapF();
            tapf.Lable = "Tập F1";

            List<string> listTemp = new List<string>();
            string temp;
            int n = listViewTapD.Items.Count;
            for (int i = 0; i < n; i++)
            {
                temp = listViewTapD.Items[i].SubItems[0].Text;

                for (int j = 1; j <= listViewMaHoa.Items.Count; j++)
                {
                    if (listViewTapD.Items[i].SubItems[j].Text == "1")
                    {
                        listKhoiTao.Add(j);
                        listTemp.Add(j.ToString());
                    }
                }
                tapf.Add(temp, new List<string>(listTemp));
                listTemp.Clear();
            }
            Program.listTapF.Add(tapf);
            TapFToListView(tapf);
        }

        private void KhoiTaoTapL1()
        {
            List<int> listMaHoa = new List<int>();
            foreach (var mh in Program.listMahoa)
            {
                listMaHoa.Add(mh.maHoa);
                //Console.WriteLine("So ma hoa: "+mh.maHoa);
            }

            model.TapL tapl = new model.TapL();
            tapl.Lable = "Tập L1";
           
            int dem = 0;
            foreach (int number in listMaHoa)
            {
               
                dem = listKhoiTao.Where(temp => temp.Equals(number))
                    .Select(temp => temp)
                    .Count();

                tapl.Add(number.ToString(), dem);          
            }
            Program.listTapL.Add(tapl);
            TapLToListView(tapl);
        }

        private List<string> Tim_TapC_Tu_TapL(List<string> listString, int k)
        {

            List<string> arrTemp = new List<string>();
            string result;
            string str1, str2, strLast1, strLast2;

            if (k == 1)
            {
                for (int i = 0; i < listString.Count; i++)
                {
                    for (int j = i + 1; j < listString.Count; j++)
                    {
                        arrTemp.Add(listString[i] + " " + listString[j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < listString.Count; i++)
                {

                    for (int j = i + 1; j < listString.Count; j++)
                    {
                       
                        str1 = xoaPhanTuCuoi(listString[i]);
                        strLast1 = tempChar.Trim();
                        tempChar = "";

                        str2 = xoaPhanTuCuoi(listString[j]);
                        strLast2 = tempChar.Trim();
                        tempChar = "";

                        if (str1.CompareTo(str2) == 0)
                        {
                            result = str1 + " " + strLast1 + " " + strLast2;
                            arrTemp.Add(result);
                        }
                    }
                }
            }
            return arrTemp;
        }

        private string xoaPhanTuCuoi(string str)
        {
            string a = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                tempChar += str[i];
                if (str[i] == ' ')
                {
                    a = str.Remove(i);
                    break;
                }
            }
            return a.Trim();
        }

        private string xoaPhanTuKeCuoi(string str)
        {
            string a = "";
            int dem = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    dem++;
                    if (dem == 2)
                    {
                        a = str.Remove(i + 1);
                        break;
                    }

                }
            }
            return a + tempChar.Trim();
        }


        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            countPre++;
            k--;
            TapFToListView(Program.listTapF[k]);
            TapLToListView(Program.listTapL[k]);

            if (k == 0)
            {
                button1.Enabled = false;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (countPre > 0)
            {
                k++;
                TapFToListView(Program.listTapF[k]);
                TapLToListView(Program.listTapL[k]);
                button1.Enabled = true;
                countPre--;
            }
            else
            {
                TapC_To_TapF();
                button1.Enabled = true;
                k++;
            }

        }
        private void TapC_To_TapF()
        {
            List<string> listStr = new List<string>();
            List<string> listResult = new List<string>();
            List<string> listTemp = new List<string>();
            string[] check;
            string resultLast;
            string resultNearLast;
            bool checkFNull = true;

            if (!Program.listTapL[k].Any() || Program.listTapL[k].Count ==1)
            {
                MessageBox.Show("Thuật toán kết thúc!");
                Form3 frm = new Form3(k);
                frm.ShowDialog();
                k--;
                return;
            }
           
            foreach (var t in Program.listTapL[k])
            {
                listStr.Add(t.Key);
            }

            listResult = Tim_TapC_Tu_TapL(listStr, k + 1);

            //foreach(string str in listResult){
            //    Console.WriteLine("Tap C: "+ str);
            //}

            if (!listResult.Any())
            {
                MessageBox.Show("Thuật toán kết thúc!");
                Form3 frm = new Form3(k);
                frm.ShowDialog();
                k--;
                return;
            }

            model.TapF tapf = new model.TapF();
            tapf.Lable = "Tập F" + ((k + 2).ToString());

            foreach (var t in Program.listTapF[k])
            {
                foreach (string str in listResult)
                {
                    check = str.Split(' ');
                    if (check.Length >= 2)
                    {
                        resultLast = xoaPhanTuCuoi(str);
                        resultNearLast = xoaPhanTuKeCuoi(str);
                        //Console.WriteLine("Last: Near Last: "+resultLast+": "+resultNearLast);

                        tempChar = "";
                        if (t.Value.Contains(resultLast))
                        {
                            if (t.Value.Contains(resultNearLast))
                            {
                                checkFNull = false;
                                listTemp.Add(str);
                                listToTapL.Add(str.Trim());
                            }
                           
                        }
                    }

                }

                if (listTemp.Any())
                {
                    tapf.Add(t.Key, new List<string>(listTemp));
                    listTemp.Clear();
                }
            }

            if (checkFNull == true)
            {
                MessageBox.Show("Thuật toán kết thúc!");
                Form3 frm = new Form3(k);
                frm.ShowDialog();
                k--;
                return;
            }

            Program.listTapF.Add(tapf);
            TapFToListView(tapf);
            TapF_To_TapL(listToTapL);
        }
        private void TapF_To_TapL(List<string> listSTR)
        {
            List<string> tempSTR = new List<string>();
            bool checkLNull = true;
            model.TapL tapl = new model.TapL();
            tapl.Lable = "Tập L" + ((k + 2).ToString());

            tempSTR.AddRange(listSTR.Distinct());
            tempSTR.Sort();
            int count = 0;

            foreach (string findValue in tempSTR)
            {
                count = listSTR.Where(temp => temp.Equals(findValue))
                    .Select(temp => temp)
                    .Count();
                //Console.WriteLine("Find Value: "+findValue+" : "+count);
                if ((count * 100) / SoUngVien >= Program.minSup)
                {
                    checkLNull = false;
                    tapl.Add(findValue, count);
                }
            }

            if (checkLNull == true)
            {
                MessageBox.Show("Thuật toán kết thúc!");
                Form3 frm = new Form3(k);
                frm.ShowDialog();
                k--;
                return;
            }
            Program.listTapL.Add(tapl);
            TapLToListView(tapl);
            listToTapL.Clear();
        }
    }
}
