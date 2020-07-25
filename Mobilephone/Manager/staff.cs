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
    class staff : ConnectionDB
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
        public static string IdentityCard { set; get; }
        public static string BirthDay { set; get; }
        public static string Vender { set; get; }
        public static string User { set; get; }
        public static string Password { set; get; }
        public static string Gender { set; get; }
        public static string SearchName { set; get; }


        public static int option = 0;

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
            else if (IdentityCard.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (User.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Password.Equals(""))
            {
                MessageBox.Show("please input value to Gender ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Vender.Equals(""))
            {
                MessageBox.Show("please input value to Gender ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (BirthDay.Equals(""))
            {
                MessageBox.Show("please input value to Gender ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (option == 1)
                {
                    saveData(dgv);
                }
                if (option == 2)
                {
                    updateData(dgv);
                }

            }
        }

        public static void setloadData(DataGridView dgv)
        {
            ConnectDB();
            sql = "select * from staff";
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
            dgv.Columns[9].HeaderText = "ເລກບັດປະຊາຊົນ";
            dgv.Columns[10].HeaderText = "ວັນເດືອນປີເກີດ";
            dgv.Columns[11].HeaderText = "ຕຳແໜງ";
            dgv.Columns[12].HeaderText = "Users";
            dgv.Columns[13].HeaderText = "Password";
            dgv.Columns[14].HeaderText = "ວ້ນເດືອນປີ";
            dgv.Columns[15].HeaderText = "ວ້ນເດືອນປີແກ້ໄຂ";
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
            dgv.Columns[13].Width = 130;
            dgv.Columns[14].Width = 100;
            dgv.Columns[15].Width = 130;



        }
        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(staffId)+1 as id from staff";
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
                sql = "insert into staff values(@gender,@name,@lastname,@tell,@email,@home,@district,@provice,@identitycard,@birthday,@vender,@users,@password,@createDate,@update) ";
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
                cmd.Parameters.AddWithValue("identitycard", IdentityCard);
                cmd.Parameters.AddWithValue("birthday", BirthDay);
                cmd.Parameters.AddWithValue("vender", Vender);
                cmd.Parameters.AddWithValue("users", User);
                cmd.Parameters.AddWithValue("password", Password);
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
                sql = "update staff set staffGender=@gender,staffName=@name,staffLastname=@lastname,staffContact=@tell,staffEmaill=@email,staffHome=@home,staffDistrict=@district,"
                    + "staffProvice=@provice,staffIndentitycard=@identitycard,staffBirstday=@birthday,staffVender=@vender,Users=@users,Password=@password,UpdateDate=@update where staffId=@id ";
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
                cmd.Parameters.AddWithValue("identitycard", IdentityCard);
                cmd.Parameters.AddWithValue("birthday", BirthDay);
                cmd.Parameters.AddWithValue("vender", Vender);
                cmd.Parameters.AddWithValue("users", User);
                cmd.Parameters.AddWithValue("password", Password);
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
                sql = "delete from staff where staffId=@id";
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
                sql = " select * from staff where staffname like @name";
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
