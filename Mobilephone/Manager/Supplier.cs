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
    class Supplier:ConnectionDB

    {

        private static string sql = "";
        public static string ID { set; get; }
        public static string Name { set; get; }
        public static string LastName { set; get; }
        public static string Tell { set; get; }
        public static string Email { set; get; }
        public static string Home { set; get; }
        public static string District { set; get; }
        public static string Provice { set; get; }
        public static string Company { set; get; }
        public static string County { set; get; }
        public static string SearchName { set; get; }
        public static string Gender { set; get; }

        public static int option = 0;

        public static void checkEmpty(DataGridView dgv)
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Name.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (LastName.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Tell.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Email.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Home.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (District.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Provice.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Company.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (County.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Gender.Equals(""))
            {
                MessageBox.Show("please input value to Gender ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(option == 1)
                {
                    saveData(dgv);
                }
                if(option == 2)
                {
                    updateData(dgv);
                }
                
            }
        }
        public static void setloadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from supplier";
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
            dgv.Columns[1].HeaderText = "ເພດ";
            dgv.Columns[2].HeaderText = "ຊື່";
            dgv.Columns[3].HeaderText = "ນາມສະກູນ";
            dgv.Columns[4].HeaderText = "ເບີໂທ";
            dgv.Columns[5].HeaderText = "ອີເມວ";
            dgv.Columns[6].HeaderText = "ບ້ານ";
            dgv.Columns[7].HeaderText = "ເມືອງ";
            dgv.Columns[8].HeaderText = "ແຂວງ";
            dgv.Columns[9].HeaderText = "ບໍລີສັດ";
            dgv.Columns[10].HeaderText = "ປະເທດ";
            dgv.Columns[11].HeaderText = "ວ້ນເດືອນປີ";
            dgv.Columns[12].HeaderText = "ວ້ນເດືອນປີແກ້ໄຂ";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 100;
            dgv.Columns[5].Width = 100;
            dgv.Columns[6].Width = 100;
            dgv.Columns[7].Width = 100;
            dgv.Columns[8].Width = 100;
            dgv.Columns[9].Width = 100;
            dgv.Columns[10].Width = 100;
            dgv.Columns[11].Width = 100;
            dgv.Columns[12].Width = 130;

        }
        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(subid)+1 as id from supplier";
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
                sql = "insert into supplier values(@gender,@name,@lastname,@tell,@email,@home,@district,@provice,@company,@county,@createDate,@update) ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("gender", Gender);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("lastname", LastName);
                cmd.Parameters.AddWithValue("tell", Tell);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("home", Home);
                cmd.Parameters.AddWithValue("district", District);
                cmd.Parameters.AddWithValue("provice", Provice);
                cmd.Parameters.AddWithValue("company", Company);
                cmd.Parameters.AddWithValue("county", County);
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
                sql = "update supplier set subGender=@gender,subName=@name,subLastname=@lastname,subContact=@tell,subEmail=@email,subHome=@home,subDistrict=@district,subProvice=@provice,Conpanyname=@company,subCounty=@county,UpdateDate=@update where subId=@id ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("gender", Gender);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("lastname", LastName);
                cmd.Parameters.AddWithValue("tell", Tell);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("home", Home);
                cmd.Parameters.AddWithValue("district", District);
                cmd.Parameters.AddWithValue("provice", Provice);
                cmd.Parameters.AddWithValue("company", Company);
                cmd.Parameters.AddWithValue("county", County);
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
                sql = "delete from supplier where subId=@id";
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
            catch(Exception e)
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
                sql = " select * from supplier where subname like @name";
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
