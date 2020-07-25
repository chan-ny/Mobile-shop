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
    class Units:ConnectionDB
    {
        private static string sql = "";

        public static string NameUnit { set; get; }
        public static string Description { set; get; }
        public static string ID { set; get; }
        public static string Search { set; get; }
        public static void setloadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from Unit";
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
            dgv.Columns[0].HeaderText = "ລະຫັດ";
            dgv.Columns[1].HeaderText = "ຊື່ຫົວໜ່ວຍ";
            dgv.Columns[2].HeaderText = "ລາຍລະອຽດ";
            dgv.Columns[3].HeaderText = "ວັນທີເດືອຮປີ";
            dgv.Columns[4].HeaderText = "ວັນທີ່ແກ້ໄຂ";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(usid)+1 as id from unit";
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
        private static void setEmpty()
        {
            if(NameUnit == "" || Description == "")
            {
                MessageBox.Show("please input value to textBox ");
                return;
            }

        }
        public static void saveDate(DataGridView dgv)
        {
            setEmpty();
            try
            {
                ConnectDB();
                sql = "insert into Unit values(@name,@description,@createDate,@update)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", NameUnit);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@createDate", setDate);
                cmd.Parameters.AddWithValue("@update", setDate);

            DialogResult message = MessageBox.Show("Do you want to Save Change value ?","Question ?" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if(result != 0)
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
                MessageBox.Show("please Check Database now ...");
            }
            finally
            {
                con.Close();
            }
        }
        public static void updateData(DataGridView dgv)
        {
            setEmpty();
            try
            {
                ConnectDB();
                sql = "update Unit set uName=@name,uDetail=@description,updateDate=@update where usid= @id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", NameUnit);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@update", setDate);
                cmd.Parameters.AddWithValue("@id", ID);


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
            catch
            {
                MessageBox.Show("please Check Database now ...");
            }
            finally
            {
                con.Close();
            }
        }
        public static void deleteData(DataGridView dgv)
        {
            setEmpty();
            try
            {
                ConnectDB();
                sql = "delete from unit where usid= @id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", ID);

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
                MessageBox.Show("please Check Database now ...");
            }
            finally
            {
                con.Close();
            }
        }

        public static void searchData(DataGridView dgv)
        {
            if(Search == "")
            {
                dgv.Visible = true;
                setloadData(dgv);
            }
            else
            {
                ConnectDB();
                sql = " select * from unit where uname like @name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name","%"+Search+"%");
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
