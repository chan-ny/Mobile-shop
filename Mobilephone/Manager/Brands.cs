using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class Brands:ConnectionDB
    {
        public static string ID { set; get; }
        public static string Brand { set; get; }
        public static string BrandDetail { set; get; }
        public static string SearchName { set; get; }
        public static string SubID { set; get; }
        public static int States { set; get; }

        private static string sql = "";


        public static void checkEmpty(DataGridView dgv)
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Brand.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (BrandDetail.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (States == 1)
                {
                    saveData(dgv);
                }
                if (States == 2)
                {
                    updateData(dgv);
                }
            }

        }
        public static void setloadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from brands";
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
        public static void setComboBox(ComboBox cb)
        {
            ConnectDB();
            sql = "select * from supplier";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = "subName";
            cb.ValueMember = "SubId";
        }
        public static void formatDatagridView(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "ລະຫັດ";
            dgv.Columns[1].HeaderText = "ຊື່ຍິຫໍ້";
            dgv.Columns[2].HeaderText = "ຜູ້ສະໜອງ";
            dgv.Columns[3].HeaderText = "ລາຍລະອຽດສີ";
            dgv.Columns[4].HeaderText = "ວັນເດືອນປິ";
            dgv.Columns[5].HeaderText = "ວັນເດືອນປີແກ້ໄຂ";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(brandId)+1 as id from brands";
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
        public static void cleatData(TextBox txt)
        {
            txt.Clear();
        }

        public static void saveData(DataGridView dgv)
        {
            ConnectDB();
            try
            {
                sql = "insert into brands values(@subid,@brand,@detail,@createDate,@update)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("subid", SubID);
                cmd.Parameters.AddWithValue("brand", Brand);
                cmd.Parameters.AddWithValue("detail", BrandDetail);
                cmd.Parameters.AddWithValue("createDate", setDate);
                cmd.Parameters.AddWithValue("update", setDate);

                DialogResult message = MessageBox.Show("Do you want to Save Change value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        setloadData(dgv);
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void updateData(DataGridView dgv)
        {
            ConnectDB();
            try
            {
                sql = "update  brands set SubId=@subid,branName=@brand,branDeteil=@detail,UpdateDate=@update where brandId=@id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("brand", Brand);
                cmd.Parameters.AddWithValue("subid", SubID);
                cmd.Parameters.AddWithValue("detail", BrandDetail);
                cmd.Parameters.AddWithValue("update", setDate);
                cmd.Parameters.AddWithValue("id", ID);

                DialogResult message = MessageBox.Show("Do you want to  Change value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        setloadData(dgv);
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void deleteData(DataGridView dgv)
        {
            ConnectDB();
            try
            {
                sql = "delete from brands where brandId=@id ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);

                DialogResult message = MessageBox.Show("Do you want to  Delete value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        setloadData(dgv);
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can not Record Value.... please Delete Supplier before");
                return;
            }

        }

        public static void searchData(DataGridView dgv)
        {
            if (SearchName == "")
            {
                dgv.Visible = true;
                setloadData(dgv);
            }
            else
            {
                ConnectDB();
                sql = " select * from brands where branName like @name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", "%" + SearchName + "%");
                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dat.Fill(ds, "table");
                dgv.DataSource = ds;
                dgv.DataMember = "table";
                formatDatagridView(dgv);


            }
        }
    }
}
