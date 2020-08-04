using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Mobilephone.FormData
{
    public partial class formSale : Form
    {
        private string sql = "";
        string color = "";
        byte[] photo;
        public string cID = "";
        public formSale()
        {
            InitializeComponent();
        }

        private void SearchID(string ID)
        {
           if(txtCodeProduct.Text == "")
            {
                return;
            }
            else
            {
                if(txtCodeProduct.Text.Length > 1)
                {
                    Manager.ConnectionDB.ConnectDB();
                    sql = "select ProductMobile.productId,ProductMobile.productName,Color.colorName,Unit.uName,ProductMobile.productSalePrice,Photo.img from ProductMobile "
                        + "inner join  Color on ProductMobile.colorId=Color.colorId inner join Unit on ProductMobile.unitId=Unit.usId right join Photo on Photo.productId =ProductMobile.productId "
                        + "where ProductMobile.productAmountQTY > 0 and ProductMobile.productId = @id";
                    Manager.ConnectionDB.cmd = new SqlCommand(sql, Manager.ConnectionDB.con);
                    Manager.ConnectionDB.cmd.Parameters.Clear();
                    Manager.ConnectionDB.cmd.Parameters.AddWithValue("id",ID);
                    Manager.ConnectionDB.dr = Manager.ConnectionDB.cmd.ExecuteReader();
                    Manager.ConnectionDB.dr.Read();
                    if (Manager.ConnectionDB.dr.HasRows)
                    {
                        txtProductName.Text = Manager.ConnectionDB.dr["productName"].ToString();
                        txtUnit.Text = Manager.ConnectionDB.dr["uName"].ToString();
                        txtPrice.Text = Manager.ConnectionDB.dr["productSalePrice"].ToString();
                        color = Manager.ConnectionDB.dr["colorName"].ToString();

                        photo = (byte[])Manager.ConnectionDB.dr["img"];
                        MemoryStream img = new MemoryStream(photo);
                        dataPicturePhone.Image = Image.FromStream(img);

                    }

                    if (txtProductName.Text =="" || txtUnit.Text =="" || txtPrice.Text =="" || txtAmount.Text == "")
                    {
                        MessageBox.Show("ID not founds and Do you wnat to Error. Fuck you ???? ","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        String[] add = new string[] { txtCodeProduct.Text, txtProductName.Text, color.ToString(), txtUnit.Text, txtPrice.Text, txtNumber.Value.ToString(),
                        txtAmount.Text };
                        dgvSale.Rows.Add(add);
                    }
                }
            }
        }

        private void loadColumns()
        {
            dgvSale.ColumnCount = 7;
            dgvSale.Columns[0].Name = "ລະຫັດສີນຄ້າ";
            dgvSale.Columns[1].Name = "ຊື່ສີນຄ້າ";
            dgvSale.Columns[2].Name = "ປະເພດສີ";
            dgvSale.Columns[3].Name = "ຫົວໜວ່ຍ";
            dgvSale.Columns[4].Name = "ລາຄາ";
            dgvSale.Columns[5].Name = "ຈຳນວນ";
            dgvSale.Columns[6].Name = "ລວມ";

            dgvSale.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSale.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSale.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSale.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSale.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSale.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



        }

        private void cbStaff()
        {
            Manager.ConnectionDB.ConnectDB();
            sql = " select * from Staff";
            Manager.ConnectionDB.cmd = new SqlCommand(sql, Manager.ConnectionDB.con);
            Manager.ConnectionDB.dat = new SqlDataAdapter(Manager.ConnectionDB.cmd);
            Manager.ConnectionDB.ds = new DataSet();
            Manager.ConnectionDB.dat.Fill(Manager.ConnectionDB.ds);

            cbVender.DataSource = Manager.ConnectionDB.ds.Tables[0];
            cbVender.DisplayMember = "staffName";
            cbVender.ValueMember = "staffId";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formRegisterCustomer open = new formRegisterCustomer();
            open.ShowDialog();
            string id = open.id.ToString();

            Manager.RegisterCustomer.ResearchID(id, txtCustomer);
            cID = id;

            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddYears(1);
            string x = d1.ToString("yyyy-MM-dd");
            string y = d2.ToString("yyyy-MM-dd");

            lbDateSuport.Text = x + " to " + y;
        }

        public  void AutoID(TextBox txt)
        {
            Manager.ConnectionDB.ConnectDB();
            try
            {
                sql = "select max(salebillId)+1 as id from SaleBill";
                Manager.ConnectionDB.cmd = new SqlCommand(sql, Manager.ConnectionDB.con);
                Manager.ConnectionDB.dr = Manager.ConnectionDB.cmd.ExecuteReader();

                while (Manager.ConnectionDB.dr.Read())
                {
                    txt.Text = Manager.ConnectionDB.dr["id"].ToString();
                }
                Manager.ConnectionDB.dr.Close();
            }
            catch
            {
                MessageBox.Show("can not Load Value ID ?");
            }
            finally
            {
                Manager.ConnectionDB.con.Close();
            }
        }

        private void formSale_Load(object sender, EventArgs e)
        {
            loadColumns();
            cbStaff();
            double str = Convert.ToDouble(lbMoney.Text);
            lbMoney.Text = String.Format("{0:0,0}", str);
            lbSenMoney.Text = "0";
            AutoID(txtCodeBill);


        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if(txtMoney.Text == "")
            {
                lbSenMoney.Text = "0";
                return;
            }
            else
            {
                double inputMoney = 0;
                double outMoney = 0;
                double result = 0;

                inputMoney = Convert.ToDouble(txtMoney.Text);
                outMoney = Convert.ToDouble(lbMoney.Text);
                result = inputMoney - outMoney;
                if (result == 0)
                {
                    lbSenMoney.Text = "0";
                    return;
                }
                var value = String.Format("{0:##,###}", result);
                lbSenMoney.Text = value;
            }
        }
        private void lbMoney_TextChanged(object sender, EventArgs e)
        {
            double str = Convert.ToDouble(lbMoney.Text);
            lbMoney.Text = String.Format("{0:0,0}", str);
            if (txtMoney.Text == "")
            {
                lbSenMoney.Text = "0";
                return;
            }
            else
            {
                double inputMoney = 0;
                double outMoney = 0;
                double result = 0;

                inputMoney = Convert.ToDouble(txtMoney.Text);
                outMoney = Convert.ToDouble(lbMoney.Text);
                result = inputMoney - outMoney;
                if(result == 0)
                {
                    lbSenMoney.Text = "0";
                    return;
                }
                var value = String.Format("{0:##,###}", result);
                lbSenMoney.Text = value;
            }
        }

        private void txtMoney_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Enter)
            {
                double str = Convert.ToDouble(txtMoney.Text);
                txtMoney.Text = String.Format("{0:0,0}", str);
            }
        }

        private void txtCodeProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeProduct.Text == "" || txtCodeProduct.Text.Length == 1)
            {
                txtProductName.Text = "";
                txtUnit.Text = "";
                txtPrice.Text = "";
                txtAmount.Text = "";
                return;
            }
            else
            {
                SearchID(txtCodeProduct.Text);
                if(txtCodeProduct.Text.Length > 1)
                {
                    txtCodeProduct.SelectAll();
                }
              
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text == ""){

                return;
            }
            else
            {
                double price = Convert.ToDouble(txtPrice.Text);
                double qty = Convert.ToDouble(txtNumber.Value.ToString());
                double result = price * qty;
                txtAmount.Text = String.Format("{0:0,0}", result);
            }
        }

        private void dgvSale_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (txtCodeProduct.Text == "")
            {
                return;
            }
            else
            {
                double Qty, Price, Amountprice = 0.0, AmonutQty = 0.0;
                string id = "";

                for (int i = 0; i < dgvSale.Rows.Count - 1; i++)
                {
                    Qty = Convert.ToDouble(dgvSale.Rows[i].Cells[5].Value);
                    Price = Convert.ToDouble(dgvSale.Rows[i].Cells[6].Value);
                    Amountprice += Price;
                    AmonutQty += Qty;

                    lbMoney.Text = String.Format("{0:0,0}", Amountprice);
                    txtAmountMoney.Text = String.Format("{0:0,0}", Amountprice);
                    txtListOrder.Text = String.Format("{0:0,0}", AmonutQty);
                    /// getvalueID
                    /// 
                    id = dgvSale.Rows[i].Cells[0].Value.ToString();
                }

                if (dgvSale.Rows.Count > 1)
                {

                    Manager.ConnectionDB.ConnectDB();
                    sql = "SELect  productId, img, screenSize, sResolution, productFrontCamera, productFrontVIdeo, productRAM, productChipset, productBattery,"
                        + "productName, productAnnounced, productOS, productCPU FROM tb_abountphone where productId=" + id;
                    Manager.ConnectionDB.cmd = new SqlCommand(sql, Manager.ConnectionDB.con);
                    Manager.ConnectionDB.dr = Manager.ConnectionDB.cmd.ExecuteReader();
                    Manager.ConnectionDB.dr.Read();
                    if (Manager.ConnectionDB.dr.HasRows)
                    {
                        lbSreenSize.Text = Manager.ConnectionDB.dr["screenSize"].ToString();
                        lbsreenRelution.Text = Manager.ConnectionDB.dr["sResolution"].ToString();
                        lbfrontCamera.Text = Manager.ConnectionDB.dr["productFrontCamera"].ToString();
                        lbfronVideo.Text = Manager.ConnectionDB.dr["productFrontVIdeo"].ToString();
                        lbRam.Text = Manager.ConnectionDB.dr["productRAM"].ToString();
                        lbChipset.Text = Manager.ConnectionDB.dr["productChipset"].ToString();
                        lbBattery.Text = Manager.ConnectionDB.dr["productBattery"].ToString();
                        lbTitleNamePhone.Text = Manager.ConnectionDB.dr["productName"].ToString();
                        lbLaunch.Text = "Launch: " + Manager.ConnectionDB.dr["productAnnounced"].ToString();
                        lbOS.Text = "OS: " + Manager.ConnectionDB.dr["productOS"].ToString();
                        lbCPU.Text = "CPU: " + Manager.ConnectionDB.dr["productCPU"].ToString();

                        byte[] array = (byte[])Manager.ConnectionDB.dr["img"];
                        MemoryStream img = new MemoryStream(array);
                        dataPicturePhone.Image = Image.FromStream(img);
                    }


                }

            }
        }
        private void txtCodeProduct_Leave(object sender, EventArgs e)
        {
            txtCodeProduct.Text = "";
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            dgvSale.Rows.Clear();
            lbMoney.Text = "0";
            lbSenMoney.Text = "0";
            txtListOrder.Text = "";
            txtAmountMoney.Text = "";
            AutoID(txtCodeBill);
            txtMoney.Text = "";
            txtCustomer.Text = "";
            lbDateSuport.Text = "";

        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            double chang = Convert.ToDouble(lbSenMoney.Text);

            if (txtCustomer.Text == "")
            {
                MessageBox.Show("Are you to Register Member now..");
                return;
            }
            else if (chang < 0)
            {
                MessageBox.Show("pleas Add Money More..");
                return;
            }
            else if (txtMoney.Text != "")
            {
                double x, y;
                x = Convert.ToDouble(txtMoney.Text);
                y = Convert.ToDouble(lbMoney.Text);

                if (x >= y)
                {
                    double lbm = Convert.ToDouble(lbMoney.Text);
                    string slm = "";
                    slm = String.Format( "{0:000}",lbm);
                    AutoID(txtCodeBill);
                    if (dgvSale.Rows.Count > 1)
                    {
                        Manager.Seller.BillID = txtCodeBill.Text;
                        Manager.Seller.productID = txtCodeBill.Text;

                        Manager.Seller.Staff = cbVender.SelectedValue.ToString();
                        Manager.Seller.CustomerID = cID;
                        Manager.Seller.Price = slm;
                        Manager.Seller.Qty = txtListOrder.Text;
                        Manager.Seller.Amount = slm;
                        Manager.Seller.AmountMoney = slm;

                        Manager.Seller.saveData(dgvSale);

                        Manager.ReportingTable.billId = txtCodeBill.Text;
                        Reports.formBill open = new Reports.formBill();
                        open.ShowDialog();

                        dgvSale.Rows.Clear();
                        lbMoney.Text = "0";
                        lbSenMoney.Text = "0";
                        txtListOrder.Text = "";
                        txtAmountMoney.Text = "";
                        AutoID(txtCodeBill);
                        txtMoney.Text = "";
                        txtCustomer.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("please input Value to DATA ");
                        dgvSale.Rows.Clear();
                        lbMoney.Text = "0";
                        lbSenMoney.Text = "0";
                        txtListOrder.Text = "";
                        txtAmountMoney.Text = "";
                        AutoID(txtCodeBill);
                        txtMoney.Text = "";
                        txtCustomer.Text = "";

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Add Money ...");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Add Money ...");
                return;
            }


            this.Controls.Clear();
            this.InitializeComponent();
            loadColumns();
            cbStaff();
            double str = Convert.ToDouble(lbMoney.Text);
            lbMoney.Text = String.Format("{0:0,0}", str);
            lbSenMoney.Text = "0";
            AutoID(txtCodeBill);
            lbDateSuport.Text = "";
        }

        private void dgvSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvSale.CurrentRow.Cells[0].Value.ToString();

            if(dgvSale.Rows.Count > 1)
            {
               
                Manager.ConnectionDB.ConnectDB();
                sql = "SELect  productId, img, screenSize, sResolution, productFrontCamera, productFrontVIdeo, productRAM, productChipset, productBattery,"
                    + "productName, productAnnounced, productOS, productCPU FROM tb_abountphone where productId="+id;
                Manager.ConnectionDB.cmd = new SqlCommand(sql, Manager.ConnectionDB.con);
                Manager.ConnectionDB.dr = Manager.ConnectionDB.cmd.ExecuteReader();
                Manager.ConnectionDB.dr.Read();
                if (Manager.ConnectionDB.dr.HasRows)
                {
                    lbSreenSize.Text = Manager.ConnectionDB.dr["screenSize"].ToString();
                    lbsreenRelution.Text = Manager.ConnectionDB.dr["sResolution"].ToString();
                    lbfrontCamera.Text = Manager.ConnectionDB.dr["productFrontCamera"].ToString();
                    lbfronVideo.Text = Manager.ConnectionDB.dr["productFrontVIdeo"].ToString();
                    lbRam.Text = Manager.ConnectionDB.dr["productRAM"].ToString();
                    lbChipset.Text = Manager.ConnectionDB.dr["productChipset"].ToString();
                    lbBattery.Text = Manager.ConnectionDB.dr["productBattery"].ToString();
                    lbTitleNamePhone.Text = Manager.ConnectionDB.dr["productName"].ToString();
                    lbLaunch.Text = "Launch: " + Manager.ConnectionDB.dr["productAnnounced"].ToString();
                    lbOS.Text = "OS: "+ Manager.ConnectionDB.dr["productOS"].ToString();
                    lbCPU.Text = "CPU: " + Manager.ConnectionDB.dr["productCPU"].ToString();

                    byte[] array = (byte[])Manager.ConnectionDB.dr["img"];
                    MemoryStream img = new MemoryStream(array);
                    dataPicturePhone.Image = Image.FromStream(img);
                }
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomer.Text == "")
            {
                btnOpenCustomer.Enabled = true;
                return;
            }
            else
            {
                btnOpenCustomer.Enabled = false;
                return;
            }
        }
    }
}
