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
    class DataProduct:ConnectionDB
    {

        public static string ID { set; get; }
        public static string ProductID { set; get; }
        public static string Name { set; get; }
        public static string Colors { set; get; }
        public static string Brands { set; get; }
        public static string Size { set; get; }
        public static string ScrennSize { set; get; }
        public static string Units { set; get; }
        public static string Networks { set; get; }
        public static string Annouced { set; get; }
        public static string Sim { set; get; }
        public static string Blutooth { set; get; }
        public static string GPS { set; get; }
        public static string Battery { set; get; }
        public static string OS { set; get; }
        public static string Chipset { set; get; }
        public static string CPU { set; get; }
        public static string GPU { set; get; }
        public static string RAM { set; get; }
        public static string Memory { set; get; }
        public static string FrontCamera { set; get; }
        public static string FrontVideo { set; get; }
        public static string RearCamera { set; get; }
        public static string RearVideo { set; get; }
        public static string Price { set; get; }
        public static string Qty { set; get; }
        public static string SalePrice { set; get; }
        public static string Discount { set; get; }
        public static string Profit { set; get; }
        public static int States { set; get; }



        public static void setComboBox(string sql,ComboBox cb,string name,string id)
        {
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds);
            cb.DataSource = ds.Tables[0];
            cb.ValueMember = name;
            cb.ValueMember = id;
        }
        
        public static void setLoadData(DataGridView dgv, string sql)
        {
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];

        }

        public static void formatDatagridView(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "ລະຫັດ";
            dgv.Columns[1].HeaderText = "ປະເພດ";
            dgv.Columns[2].HeaderText = "ລາຍລະອຽດ";
            dgv.Columns[3].HeaderText = "ວັນເດືອນປິ";
            dgv.Columns[4].HeaderText = "ວັນເດືອນປີແກ້ໄຂ";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public static void checkEmpty(DataGridView dgv)
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (ProductID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Colors.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (States == 1)
                {
                    //saveData(dgv);
                }
                if (States == 2)
                {
                    //updateData(dgv);
                }
            }

        }

    }
}
