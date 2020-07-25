using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Mobilephone.Manager
{
    class ConnectionDB
    {
        public static string URLS = @"Data Source=DESKTOP-FEIOFK2;Initial Catalog=DB;Integrated Security=True";
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter dat;
        public static SqlDataReader dr;
        public static DataSet ds;    
        public static string setDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public static string upDate = "0000-00-00 00:00:00";


        public static void ConnectDB()
        {
            con = new SqlConnection();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.ConnectionString = URLS;
                con.Open();
                
            }
            
        }


    }
}
