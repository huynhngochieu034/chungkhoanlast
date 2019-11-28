using ChungKhoan.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChungKhoan
{
     static class Program
    {
        //normal
        public static String connnectionString = "Data Source=DESKTOP-7V9QME6\\SQLEXPRESS;Initial Catalog=CHUNGKHOAN;Integrated Security=True";

        //100 records D
         //1k database
        //public static String connnectionString = "Data Source=DESKTOP-7V9QME6\\SQLEXPRESS;Initial Catalog=CHUNGKHOAN100;Integrated Security=True";

        //11k records D
        //110k database
         // public static String connnectionString = "Data Source=DESKTOP-7V9QME6\\SQLEXPRESS;Initial Catalog=CHUNGKHOANTESTLAST;Integrated Security=True";
          
         //100k records D
          //500k database
        //public static String connnectionString = "Data Source=DESKTOP-7V9QME6\\SQLEXPRESS;Initial Catalog=CHUNGKHOANTEST;Integrated Security=True";
        
        public static List<MaHoa> listMahoa = new List<MaHoa>();
        public static List<TapF> listTapF = new List<TapF>();
        public static List<TapL> listTapL = new List<TapL>();
        public static int minSup = 0;
       
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
