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
    class Report : ConnectionDB
    {
        public static string sql = "";

      /// <summary>
      /// 
      /// </summary>
      /// <param name="dgv">Product</param>
      /// 
      public static string SearchProduct { set; get; }
        public static void setLoadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_products";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds);
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            formatDatagridView(dgv);

        }
        public static void formatDatagridView(DataGridView dgv)
        {
            dgv.Columns[1].HeaderText = "ລະຫັດຄ້າ";
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[4].HeaderText = "ປະເພດສີ";
            dgv.Columns[5].HeaderText = "ລາຍລະອຽດສີ";
            dgv.Columns[6].HeaderText = "ຍິຫໍ້";
            dgv.Columns[7].HeaderText = "ລາຍລະອຽດຍິຫໍ້";
            dgv.Columns[8].HeaderText = "ປະເພດ";
            dgv.Columns[9].HeaderText = "ລາຍລະອຽດປະເພດ";
            dgv.Columns[10].HeaderText = "ໜ້າຈໍ";
            dgv.Columns[11].HeaderText = "ຂະໜາດໜ້າຈໍ";
            dgv.Columns[12].HeaderText = "ຫົວໜວ່ຍ";
            dgv.Columns[13].HeaderText = "ລາຍລະອຽດໜ່ວຍ";
            dgv.Columns[14].HeaderText = "ເນັດເວີລ";
            dgv.Columns[15].HeaderText = "ວັນທີຜະລິດ";
            dgv.Columns[16].HeaderText = "ຊີມກາດ";
            dgv.Columns[17].HeaderText = "ບູທຸດ";
            dgv.Columns[18].HeaderText = "ຈີພີເອັດ";
            dgv.Columns[19].HeaderText = "ແບັດເຕີລີ";
            dgv.Columns[20].HeaderText = "ລະບົບປະຕີບັດການ";
            dgv.Columns[21].HeaderText = "ຊີບເຊັດ";
            dgv.Columns[22].HeaderText = "ຊີພີຢູ";
            dgv.Columns[23].HeaderText = "ຈີພີຢູ";
            dgv.Columns[24].HeaderText = "ແຣມ";
            dgv.Columns[25].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[26].HeaderText = "ກ້ອງໜ້າ";
            dgv.Columns[27].HeaderText = "ວີດິໂອກ້ອງໜ້າ";
            dgv.Columns[28].HeaderText = "ກ້ອງຫຼັງ";
            dgv.Columns[29].HeaderText = "ວີດິໂອກ້ອງຫຼັງ";
            dgv.Columns[30].HeaderText = "ລາຄານຳເຂົ້າ";
            dgv.Columns[31].HeaderText = "ຈຳນວນ";
            dgv.Columns[32].HeaderText = "ລາຄາຂາຍ";
            dgv.Columns[33].HeaderText = "ຜົນກຳໄລ";
            dgv.Columns[34].HeaderText = "ວັນເດືອນສ້າງ";
            dgv.Columns[35].HeaderText = "ວັນເດືອນແກ້ໄຂ";

        }

        public static void searchDataProduct(DataGridView dgv)
        {
            try
            {
                if (SearchProduct == "")
                {
                    dgv.Visible = true;
                    setLoadData(dgv);
                }
                else
                {
                    ConnectDB();
                    sql = " select * from tb_products where productName like @name";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", "%" + SearchProduct + "%");
                    dat = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    dat.Fill(ds, "table");
                    dgv.DataSource = ds;
                    dgv.DataMember = "table";
                    formatDatagridView(dgv);


                }
            }
            catch
            {
                return;
            }
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv">Customer</param>
        /// 
        public static string SearchNameCustomer { set; get; }
        public static void setloadDataCustomer(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_Insurance";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridViewCustomer(dgv);

        }
        public static void formatDatagridViewCustomer(DataGridView dgv)
        {
            dgv.Columns[1].HeaderText = "ລະຫັດຮັບປະກັນ";
            dgv.Columns[2].HeaderText = "ລະຫັດບີນ";
            dgv.Columns[3].HeaderText = "ລະຫັດລຸກຄ້າ";
            dgv.Columns[4].HeaderText = "ເພດ";
            dgv.Columns[5].HeaderText = "ຊື່";
            dgv.Columns[6].HeaderText = "ນາມສະກຸນ";
            dgv.Columns[7].HeaderText = "ບ້ານ";
            dgv.Columns[8].HeaderText = "ເມືອງ";
            dgv.Columns[9].HeaderText = "ແຂວງ";
            dgv.Columns[10].HeaderText = "ເບີໂທ";
            dgv.Columns[11].HeaderText = "ອີເມວ";
            dgv.Columns[12].HeaderText = "ເລກບັດປະຊາຊົນ";
            dgv.Columns[13].HeaderText = "ຮັບປະກັນ";
            dgv.Columns[14].HeaderText = "ເລີ້ມຕົັນ";
            dgv.Columns[15].HeaderText = "ສີ້ນສຸດ";
            dgv.Columns[16].HeaderText = "ວັນເດືອນປິ";
            dgv.Columns[17].HeaderText = "ວັນເດືອນປີແກ້ໄຂ";
        }

        public static void searchDataCustomer(DataGridView dgv)
        {
            try
            {
                if (SearchNameCustomer == "")
                {
                    dgv.Visible = true;
                    setloadDataCustomer(dgv);
                }
                else
                {
                    ConnectDB();
                    sql = " select * from tb_Insurance where cusName like @name";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", "%" + SearchNameCustomer + "%");
                    dat = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    dat.Fill(ds, "table");
                    dgv.DataSource = ds;
                    dgv.DataMember = "table";
                    formatDatagridViewCustomer(dgv);


                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv">Seler</param>
        /// 
        public static string SellerDate { set; get;}
        public static int StateSeller { set; get; }

        public static void setloadDataSeller(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_seller";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridViewSeller(dgv);

        }
        public static void formatDatagridViewSeller(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "ລະຫັດ";
            dgv.Columns[2].HeaderText = "ລະຫັດລຸກຄ້າ";
            dgv.Columns[3].HeaderText = "ເພດ";
            dgv.Columns[4].HeaderText = "ຊື່";
            dgv.Columns[5].HeaderText = "ນາມສະກຸນ";
            dgv.Columns[6].HeaderText = "ເບີໂທ";
            dgv.Columns[7].HeaderText = "ເພດ";
            dgv.Columns[8].HeaderText = "ພະນັກງານຂາຍ";
            dgv.Columns[9].HeaderText = "ນາມສະກຸນ";
            dgv.Columns[10].Visible = false;
            dgv.Columns[11].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[12].HeaderText = "ປະເພດສີ";
            dgv.Columns[13].HeaderText = "ຍິຫໍ້";
            dgv.Columns[14].HeaderText = "ປະເພດ";
            dgv.Columns[15].HeaderText = "ຈໍພາບ";
            dgv.Columns[16].HeaderText = "ຂະໜາດຈໍ";
            dgv.Columns[17].HeaderText = "ຫົວໜວ່ຍ";
            dgv.Columns[18].HeaderText = "ຊີມກາດ";
            dgv.Columns[19].HeaderText = "ແບັດເຕີລີ";
            dgv.Columns[20].HeaderText = "ລະບົບປະຈີບັດການ";
            dgv.Columns[21].HeaderText = "ຊີພີຍູ";
            dgv.Columns[22].HeaderText = "ແຣມ";
            dgv.Columns[23].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[24].HeaderText = "ກ້ອງໜ້າ";
            dgv.Columns[25].HeaderText = "ກ້ອງຫຼັງ";
            dgv.Columns[26].HeaderText = "ລາຄາ";
            dgv.Columns[27].HeaderText = "ຈຳນວນ";
            dgv.Columns[28].HeaderText = "ລວມ";
            dgv.Columns[29].HeaderText = "ລວມທັງໜົດ";
            dgv.Columns[30].HeaderText = "ວັນທີ່ເດືອນປິ";
            dgv.Columns[31].HeaderText = "ວັນທີ່ແກ້ໄຂ";

        }

        public static void searchDataSeller(DataGridView dgv, string date)
        {
            try
            {
                if (SellerDate == "")
                {
                    dgv.Visible = true;
                    setloadDataSeller(dgv);
                }
                else
                {
                    ConnectDB();
                    sql = "select * from tb_seller where  " + date + "(CreateDate)=" + SellerDate;
                    cmd = new SqlCommand(sql, con);
                    dat = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    dat.Fill(ds, "table");
                    dgv.DataSource = ds;
                    dgv.DataMember = "table";
                    formatDatagridViewSeller(dgv);
                }
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv">Import</param>
        /// 

        public static string importDate { set; get; }
        public static int Stateimport { set; get; }


        public static void setloadDataImport(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_ImportReport";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridViewImport(dgv);

        }
        public static void formatDatagridViewImport(DataGridView dgv)
        {
            
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "ລະຫັດສີນຄ້າ";
            dgv.Columns[2].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[3].HeaderText = "ປະເພດສີ";
            dgv.Columns[4].HeaderText = "ຍິຫໍ້";
            dgv.Columns[5].HeaderText = "ຜູ້ສະໜອງ";
            dgv.Columns[6].HeaderText = "ນຳເຂົ້າຈາກ";
            dgv.Columns[7].HeaderText = "ປະເພດ";
            dgv.Columns[8].HeaderText = "ຫົວໜວ່ຍ";
            dgv.Columns[9].HeaderText = "ຊີມກາດ";
            dgv.Columns[10].HeaderText = "ແບັດເຕິລີ";
            dgv.Columns[11].HeaderText = "ລະບົບປະຈີບັດການ";
            dgv.Columns[12].HeaderText = "ຊີພີຍູ";
            dgv.Columns[13].HeaderText = "ແຣມ";
            dgv.Columns[14].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[15].HeaderText = "ລາຄາ";
            dgv.Columns[16].HeaderText = "ຈຳນວນ";
            dgv.Columns[17].HeaderText = "ລວມ";
            dgv.Columns[18].HeaderText = "ສະຖານະ";
            dgv.Columns[19].HeaderText = "ວັນທີ່ເດືອນປິ";
            dgv.Columns[20].HeaderText = "ວັນທີ່ແກ້ໄຂ";

        }

        public static void searchDataImport(DataGridView dgv,string date)
        {
            try
            {
                if (importDate == "")
                {
                    dgv.Visible = true;
                    setloadDataImport(dgv);
                }
                else
                {
                    ConnectDB();
                    sql = "select * from tb_ImportReport where  " + date + "(CreateDate)=" + importDate;
                    cmd = new SqlCommand(sql, con);
                    dat = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    dat.Fill(ds, "table");
                    dgv.DataSource = ds;
                    dgv.DataMember = "table";
                    formatDatagridViewImport(dgv);
                }
            }
            catch
            {
                return;
            }
        }


    }
}
