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
    class RegisterCustomer:ConnectionDB
    {
        public static string ID { set; get; }
        public static string Gender { set; get; }
        public static string Name { set; get; }
        public static string LastName { set; get; }
        public static string Home { set; get; }
        public static string District { set; get; }
        public static string Provice { set; get; }
        public static string Tell { set; get; }
        public static string Email { set; get; }
        public static string Identity { set; get; }

        public static string SearchNamed { set; get; }
        public static string SearchLastName { set; get; }
        public static string SearchIdentityCard { set; get; }


        public static int States { set; get; }

        private static string sql = "";


        public static void checkEmpty(DataGridView dgv)
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (Identity.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Gender.Equals(""))
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
            sql = "select * from Customers";
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
            dgv.Columns[3].HeaderText = "ນາມສະກຸນ";
            dgv.Columns[4].HeaderText = "ບ້ານ";
            dgv.Columns[5].HeaderText = "ເມືອງ";
            dgv.Columns[6].HeaderText = "ແຂວງ";
            dgv.Columns[7].HeaderText = "ເບີໂທ";
            dgv.Columns[8].HeaderText = "ອີເມວ";
            dgv.Columns[9].HeaderText = "ເລກບັດປະຊາຊົນ";
            dgv.Columns[10].HeaderText = "ວັນເດືອນປິ";
            dgv.Columns[11].HeaderText = "ວັນເດືອນປີແກ້ໄຂ";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].Width = 120;
            dgv.Columns[4].Width = 120;
            dgv.Columns[5].Width = 120;
            dgv.Columns[6].Width = 120;
            dgv.Columns[7].Width = 130;
            dgv.Columns[8].Width = 140;
            dgv.Columns[9].Width = 100;
            dgv.Columns[10].Width = 130;
            dgv.Columns[11].Width = 130;



        }
        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(cusId)+1 as id from Customers";
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
                sql = "insert into Customers values(@gender,@name,@lastname,@home,@district,@provice,@tell,@email,@identity,@createDate,@update)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("gender", Gender);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("lastname", LastName);
                cmd.Parameters.AddWithValue("home", Home);
                cmd.Parameters.AddWithValue("district", District);
                cmd.Parameters.AddWithValue("provice", Provice);
                cmd.Parameters.AddWithValue("tell", Tell);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("identity",Identity);
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
                sql = "update Customers set cusGender=@gender,cusName=@name,cusLastname=@lastname,cusHome=@home,cusDistrict=@district,cusProvice=@provice,"
                    + "cusTell=@tell,cusEmial=@email,cusIdentityCard=@identity,UpdateDate=@update  where cusId=@id ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("gender", Gender);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("lastname", LastName);
                cmd.Parameters.AddWithValue("home", Home);
                cmd.Parameters.AddWithValue("district", District);
                cmd.Parameters.AddWithValue("provice", Provice);
                cmd.Parameters.AddWithValue("tell", Tell);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("identity", Identity);
                cmd.Parameters.AddWithValue("createDate", setDate);
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
                sql = "delete from customers where cusId=@id ";
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
            if (SearchNamed == "" || SearchIdentityCard == "" || SearchLastName =="")
            {
                dgv.Visible = true;
                setloadData(dgv);
            }
            else
            {
                ConnectDB();
                sql = "select * from customers where cusName=@name and cusLastname=@lastname and cusIdentityCard=@identity ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("name",SearchNamed);
                cmd.Parameters.AddWithValue("lastname", SearchLastName);
                cmd.Parameters.AddWithValue("identity", SearchIdentityCard);
                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dat.Fill(ds, "table");
                dgv.DataSource = ds;
                dgv.DataMember = "table";
                formatDatagridView(dgv);


            }
        }

        public static void searchCustomer(DataGridView dgv)
        {
            if (SearchNamed == "")
            {
                dgv.Visible = true;
                setloadData(dgv);
            }
            else
            {
                ConnectDB();
                sql = "select * from customers where cusName like @name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", "%"+SearchNamed+"%");
                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dat.Fill(ds, "table");
                dgv.DataSource = ds;
                dgv.DataMember = "table";
                formatDatagridView(dgv);


            }
        }

        public static void ResearchID(string id, TextBox str)
        {
            try
            {
                ConnectDB();
                sql = "select cusName from Customers where cusId=" + id;
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    str.Text = dr["cusName"].ToString();
                }

                if (str.Text == "")
                {
                    MessageBox.Show("Customer no Registert");
                    return;
                }

                dr.Close();
            }
            catch
            {
                MessageBox.Show("Customer no Registert");
                return;
            }
            
        }

    }
}
