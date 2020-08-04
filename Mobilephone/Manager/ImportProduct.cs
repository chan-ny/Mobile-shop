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
    class ImportProduct:ConnectionDB
    {
        public static string ID { set; get; }
        private static string sql = "";

        public static string AmountQty { set; get; }
        public static string AmountPrice { set; get; }
        public static string AmountTotal { set; get; }
        public static string Supplier { set; get; }


        public static void setloadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_ViewProduct  where ConpanyName=N'" + Supplier + "'";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridView(dgv);

        }
        public static void formatDatagridView(DataGridView dgv)
        {
            dgv.Columns[1].HeaderText = "ລະຫັດສີນຄ້າ";
            dgv.Columns[2].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[3].HeaderText = "ປະເພດສີ";
            dgv.Columns[4].HeaderText = "ຂະໜາດຈໍ";
            dgv.Columns[5].HeaderText = "ລາຍລະອຽດຈໍ";
            dgv.Columns[6].HeaderText = "ຍິຫໍ້";
            dgv.Columns[7].HeaderText = "ບໍລິສັດນຳເຂົ້າ";
            dgv.Columns[8].HeaderText = "ປະເທດນຳເຂົ້າ";
            dgv.Columns[9].HeaderText = "ຊີມ";
            dgv.Columns[10].HeaderText = "ແບັດເຕີລີ";
            dgv.Columns[11].HeaderText = "ລະບົບປະຕິບັດການ";
            dgv.Columns[12].HeaderText = "ຊິພິຢູ";
            dgv.Columns[13].HeaderText = "ແຣມ";
            dgv.Columns[14].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[15].HeaderText = "ກ້ອງໜ້າ";
            dgv.Columns[16].HeaderText = "ກ້ອງຫຼັງ";
            dgv.Columns[17].HeaderText = "ລາຄາ";
            dgv.Columns[18].HeaderText = "ຈຳນວວນໜ້າຮ້ານ";
            dgv.Columns[19].HeaderText = "ຈຳນວນສະຕອ໊ກ";
            dgv.Columns[20].HeaderText = "ລວມ";

        }
        public static void AutoID(Label txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(importId)+1 as id from ImportProduct";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txt.Text = dr["id"].ToString();
                }
                dr.Close();
            }
            catch
            {
                MessageBox.Show("can not Load Value ID ?");
            }
            finally
            {
                con.Close();
            }
        }

        public static void orderData(string id, DataGridView dgv)
        {
            try
            {
                ConnectDB();
                sql = "insert into ImportProduct values(@importPriceamount,@importAmountNumber,@importTotal,@CreateDate,@UpdateDate,1)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("importPriceamount", AmountPrice);
                cmd.Parameters.AddWithValue("importAmountNumber", AmountQty);
                cmd.Parameters.AddWithValue("importTotal", AmountTotal);
                cmd.Parameters.AddWithValue("CreateDate", setDate);
                cmd.Parameters.AddWithValue("UpdateDate", setDate);
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    ConnectDB();
                    sql = "";
                    sql = "insert into Importlist values(@importId,@SubId,@productId,@importlistPrice,@importlistQty,@importlistAmount,1)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("importId", id);
                    cmd.Parameters.AddWithValue("SubId", dgv.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("productId", dgv.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("importlistPrice", dgv.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("importlistQty", dgv.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("importlistAmount", dgv.Rows[i].Cells[3].Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("keycode Duplicate....");
                return;
            }         

        }

        public static string setSupplier(string indexs)
        {
            string id = "";
            ConnectDB();
            sql = "select subid from Supplier where ConpanyName =N'" + indexs+"'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                id = dr["subid"].ToString();
            }
            dr.Close();
            return id;

        }

        public static void setloadDataP(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from tb_importFinal where statei = 2";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridP(dgv);

        }
        public static void formatDatagridP(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "ລະຫັດບີນ";
            dgv.Columns[2].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[1].Visible = false;
            dgv.Columns[3].HeaderText = "ປະເພດສີ";
            dgv.Columns[4].HeaderText = "ຍິຫໍ້";
            dgv.Columns[5].HeaderText = "ຜູ້ສະໜອງ";
            dgv.Columns[6].HeaderText = "ປະເທດນຳເຂົ້າ";
            dgv.Columns[7].HeaderText = "ປະເພດ";
            dgv.Columns[8].HeaderText = "ຫົວໜວ່ຍ";
            dgv.Columns[9].HeaderText = "ຊີມ";
            dgv.Columns[10].HeaderText = "ແບັດເຕີລີ";
            dgv.Columns[11].HeaderText = "ລະບົບປະຕິບັດການ";
            dgv.Columns[12].HeaderText = "ຊີພີຍູ";
            dgv.Columns[13].HeaderText = "ແຣມ";
            dgv.Columns[14].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[15].HeaderText = "ລາຄາ";
            dgv.Columns[16].HeaderText = "ຈຳນວນ";
            dgv.Columns[17].HeaderText = "ລວມ";
            dgv.Columns[18].HeaderText = "ສະຖານະ";
            dgv.Columns[19].HeaderText = "ວັນທີ່ສ້າງ";
            dgv.Columns[20].HeaderText = "ວັນທີ່ແກ້ໄຂ";


        }

        public static void setloadDataViewP(DataGridView dgv)
        {
            ConnectDB();
            sql = "select  importId, importPriceamount, importAmountNumber, importTotal,Statei, CreateDate, UpdateDate  from ImportProduct where  statei=1";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            dgv.RowTemplate.Height = 30;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            /// metthod
            formatDatagridViewP(dgv);

        }
        public static void formatDatagridViewP(DataGridView dgv)
        {
            dgv.Columns[1].HeaderText = "ລະຫັດບີນ";
            dgv.Columns[2].HeaderText = "ລວມລາຄາ";
            dgv.Columns[3].HeaderText = "ລວມຈຳນວນ";
            dgv.Columns[4].HeaderText = "ລວມເປັນເງີນ";
            dgv.Columns[5].HeaderText = "ສະຖານະ";
            dgv.Columns[6].HeaderText = "ວັນທີ່ສ້າງ";
            dgv.Columns[7].HeaderText = "ວັນທີແກ້ໄຂ";
        }

        public static void saveData(DataGridView dgv)
        {
            if(ID == "")
            {
                MessageBox.Show("please select  value into DataGridView Order ...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                sql = "update ImportProduct set statei =2 where importId = @id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);

                DialogResult message = MessageBox.Show("Do you want to Save  value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        sql = "update Importlist set States =2 where importId = @id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("id", ID);
                        cmd.ExecuteNonQuery();

                        Manager.ReportingTable.importOrderId = ID;

                        setloadDataViewP(dgv);

                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }

        }
        public static void DeleteData(DataGridView dgv)
        {
            if (ID == "")
            {
                MessageBox.Show("please select  value into DataGridView Order ...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ConnectDB();
                sql = "delete from Importlist where importId = @id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);
               

                DialogResult message = MessageBox.Show("Do you want to Dalete value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        ConnectDB();
                        sql = "delete from ImportProduct where importId = @id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("id", ID);
                        cmd.ExecuteNonQuery();
                        setloadDataViewP(dgv);

                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }

        }

        public static void ClearData(TextBox txt)
        {
            txt.Clear();
        }

        public static void ChooseSupplier(ComboBox cb)
        {
            try
            {
                ConnectDB();
                sql = "select * from Supplier";
                cmd = new SqlCommand(sql, con);
                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dat.Fill(ds, "table");
                cb.DataSource = ds.Tables[0];

                cb.DisplayMember = "ConpanyName";
                cb.ValueMember = "subId";

            }
            catch
            {
                return;
            }
            
        }

    }
}
