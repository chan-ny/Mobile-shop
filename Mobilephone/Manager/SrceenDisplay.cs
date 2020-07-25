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
    class SrceenDisplay:ConnectionDB
    {
        public static string ID { set; get; }
        public static string ScreenSize { set; get; }
        public static string Resolution { set; get; }
        public static string SearchName { set; get; }
        public static int States { set; get; }

        private static string sql = "";


        public static void checkEmpty(DataGridView dgv)
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (ScreenSize.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Resolution.Equals(""))
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
            sql = "select * from ScreenDisplay";
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
            dgv.Columns[1].HeaderText = "ຂະໜາດຈຳ";
            dgv.Columns[2].HeaderText = "ReSolution";
            dgv.Columns[3].HeaderText = "ວັນເດືອນປິ";
            dgv.Columns[4].HeaderText = "ວັນເດືອນປີແກ້ໄຂ";
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
                sql = "select max(screenId)+1 as id from ScreenDisplay";
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
                sql = "insert into ScreenDisplay values(@screen,@resolution,@createDate,@update)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("screen", ScreenSize);
                cmd.Parameters.AddWithValue("resolution", Resolution);
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
                sql = "update ScreenDisplay set screenSize=@screen,sResolution=@resolution,UpdateDate=@update where screenId=@id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("screen", ScreenSize);
                cmd.Parameters.AddWithValue("resolution", Resolution);
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
                sql = "delete from ScreenDisplay where screenId=@id ";
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                sql = " select * from ScreenDisplay where screenSize like @name";
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
