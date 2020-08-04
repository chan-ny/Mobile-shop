using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class Login:ConnectionDB
    {
        public static void loginAdmain(string name, string pwd,Form fr)
        {

            ConnectDB();
            string sql = "select * from tbAdmin where  admin=@admin and password=@password ";
           cmd = new System.Data.SqlClient.SqlCommand(sql,con);
           cmd.Parameters.AddWithValue("admin",name);
           cmd.Parameters.AddWithValue("password",pwd);
           dr =cmd.ExecuteReader();
           dr.Read();
            if (dr.HasRows)
            {
                fr.Hide();
                fr.Close();
                formMain open = new formMain();
                open.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນອີກຄັ້ງ", "ເກີດຂໍ້ຜິດພາດ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                name = "";
                pwd = "";
                return;
            }


        }

        public static void loginUser(string name, string pwd, Form fr)
        {

            ConnectDB();
            string sql = "select * from Staff where  Users=@user and Password=@password ";
            cmd = new System.Data.SqlClient.SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("user", name);
            cmd.Parameters.AddWithValue("password", pwd);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                fr.Hide();
                fr.Close();
                FormData.formSale open = new FormData.formSale();
                open.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນອີກຄັ້ງ", "ເກີດຂໍ້ຜິດພາດ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                name = "";
                pwd = "";
                return;
            }


        }

    }
}
