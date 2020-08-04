using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mobilephone.DataProduct
{
    public partial class formDataProduct : Form
    {
        public formDataProduct()
        {
            InitializeComponent();
        }
        public int States = 1;
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void formDataProduct_Load(object sender, EventArgs e)
        {
            if(States == 1)
            {
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                Manager.DataProduct.setComboBox("select * from color", cbColor, "colorname", "colorid");
                Manager.DataProduct.setComboBox("select * from brands", cbBrands, "branname", "brandid");
                Manager.DataProduct.setComboBox("select * from size", cbSize, "sizename", "sizeid");
                Manager.DataProduct.setComboBox("select * from ScreenDisplay", cbSrceenDisplay, "screenSize", "screenId");
                Manager.DataProduct.setComboBox("select * from unit", cbUnit, "uname", "usid");
                Manager.DataProduct.AutoID(txtCode);
            }
            if(States == 2)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                byte[] array = Manager.DataProduct.Photo;
                MemoryStream img = new MemoryStream(array);
                picPhoto.Image = Image.FromStream(img);

                txtCode.Text = Manager.DataProduct.ID.ToString();
                txtName.Text = Manager.DataProduct.Name.ToString();

                string color = Manager.DataProduct.Colors.ToString();
                Manager.DataProduct.sentComboBox("color", color, cbColor, "colorName", "colorId");

                string brand = Manager.DataProduct.Brands.ToString();
                Manager.DataProduct.sentComboBox("Brands", brand, cbBrands, "branName", "brandId");

                string size = Manager.DataProduct.Size.ToString();
                Manager.DataProduct.sentComboBox("Size", size, cbSize, "sizeName", "sizeId");

                string screen = Manager.DataProduct.ScrennSize.ToString();
                Manager.DataProduct.sentComboBox("ScreenDisplay", screen, cbSrceenDisplay, "screenSize", "screenId");

                string units = Manager.DataProduct.Units.ToString();
                Manager.DataProduct.sentComboBox("Unit", units, cbUnit, "uName", "usId");


                txtNetwork.Text = Manager.DataProduct.Networks.ToString();
                txtAnnounced.Text = Manager.DataProduct.Annouced.ToString();
                txtSim.Text = Manager.DataProduct.Sim.ToString();
                txtBlutood.Text = Manager.DataProduct.Blutooth.ToString();
                txtGPS.Text = Manager.DataProduct.GPS.ToString();
                txtBattery.Text = Manager.DataProduct.Battery.ToString();
                txtOS.Text = Manager.DataProduct.OS.ToString();
                txtChipset.Text = Manager.DataProduct.Chipset.ToString();
                txtCPU.Text = Manager.DataProduct.CPU.ToString();
                txtGPU.Text = Manager.DataProduct.GPS.ToString();
                txtRAM.Text = Manager.DataProduct.RAM.ToString();
                txtMemory.Text = Manager.DataProduct.Memory.ToString();
                txtFrontCamera.Text = Manager.DataProduct.FrontCamera.ToString();
                txtFrontVideo.Text = Manager.DataProduct.FrontVideo.ToString();
                txtBackCamera.Text = Manager.DataProduct.RearCamera.ToString();
                txtBackVideo.Text = Manager.DataProduct.RearVideo.ToString();
                txtPrice.Text = Manager.DataProduct.Price.ToString();
                txtON.Text = Manager.DataProduct.StockON.ToString();
                txtOFF.Text = Manager.DataProduct.StockOFF.ToString();
                txtAmonut.Text = Manager.DataProduct.AmountQty.ToString();
                txtSellerPrice.Text = Manager.DataProduct.SalePrice.ToString();
                txtProfit.Text = Manager.DataProduct.Profit.ToString();
               
            }

        }


        private void cleamData()
        {
            Manager.DataProduct.cleatData(txtName);
            Manager.DataProduct.cleatData(txtNetwork);
            Manager.DataProduct.cleatData(txtAnnounced);
            Manager.DataProduct.cleatData(txtSim);
            Manager.DataProduct.cleatData(txtBlutood);
            Manager.DataProduct.cleatData(txtGPS);
            Manager.DataProduct.cleatData(txtBattery);
            Manager.DataProduct.cleatData(txtOS);
            Manager.DataProduct.cleatData(txtChipset);
            Manager.DataProduct.cleatData(txtGPU);
            Manager.DataProduct.cleatData(txtCPU);
            Manager.DataProduct.cleatData(txtRAM);
            Manager.DataProduct.cleatData(txtMemory);
            Manager.DataProduct.cleatData(txtFrontCamera);
            Manager.DataProduct.cleatData(txtFrontVideo);
            Manager.DataProduct.cleatData(txtBackCamera);
            Manager.DataProduct.cleatData(txtBackVideo);
            Manager.DataProduct.cleatData(txtPrice);
            Manager.DataProduct.cleatData(txtON);
            Manager.DataProduct.cleatData(txtOFF);
            Manager.DataProduct.cleatData(txtAmonut);
            Manager.DataProduct.cleatData(txtSellerPrice);
            Manager.DataProduct.cleatData(txtProfit);
            picPhoto.Image = null;


            Manager.DataProduct.setComboBox("select * from color", cbColor, "colorname", "colorid");
            Manager.DataProduct.setComboBox("select * from brands", cbBrands, "branname", "brandid");
            Manager.DataProduct.setComboBox("select * from size", cbSize, "sizename", "sizeid");
            Manager.DataProduct.setComboBox("select * from ScreenDisplay", cbSrceenDisplay, "screenSize", "screenId");
            Manager.DataProduct.setComboBox("select * from unit", cbUnit, "uname", "usid");
            Manager.DataProduct.AutoID(txtCode);
           

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(picPhoto.Image == null)
            {
                MessageBox.Show("photo emtpy ???");
                return;
            }
            else
            {
                Manager.ImageClass img = new Manager.ImageClass();

                Manager.DataProduct.ID = txtCode.Text;
                Manager.DataProduct.Name = txtName.Text;
                Manager.DataProduct.Colors = cbColor.SelectedValue.ToString();
                Manager.DataProduct.Brands = cbBrands.SelectedValue.ToString();
                Manager.DataProduct.Size = cbSize.SelectedValue.ToString();
                Manager.DataProduct.ScrennSize = cbSrceenDisplay.SelectedValue.ToString();
                Manager.DataProduct.Units = cbUnit.SelectedValue.ToString();
                Manager.DataProduct.Networks = txtNetwork.Text;
                Manager.DataProduct.Annouced = txtAnnounced.Text;
                Manager.DataProduct.Sim = txtSim.Text;
                Manager.DataProduct.Blutooth = txtBlutood.Text;
                Manager.DataProduct.GPS = txtGPS.Text;
                Manager.DataProduct.Battery = txtBattery.Text;
                Manager.DataProduct.OS = txtOS.Text;
                Manager.DataProduct.Chipset = txtChipset.Text;
                Manager.DataProduct.CPU = txtCPU.Text;
                Manager.DataProduct.GPU = txtGPU.Text;
                Manager.DataProduct.RAM = txtRAM.Text;
                Manager.DataProduct.Memory = txtMemory.Text;
                Manager.DataProduct.FrontCamera = txtFrontCamera.Text;
                Manager.DataProduct.FrontVideo = txtFrontVideo.Text;
                Manager.DataProduct.RearCamera = txtBackCamera.Text;
                Manager.DataProduct.RearVideo = txtBackVideo.Text;
                Manager.DataProduct.Price = txtPrice.Text;
                Manager.DataProduct.StockON = txtON.Text;
                Manager.DataProduct.StockOFF = txtOFF.Text;
                Manager.DataProduct.AmountQty = txtAmonut.Text;
                Manager.DataProduct.SalePrice = txtSellerPrice.Text;
                Manager.DataProduct.Profit = txtProfit.Text;
                Manager.DataProduct.Photo = img.setImage(picPhoto);
                Manager.DataProduct.States = 1;
                Manager.DataProduct.checkEmpty();
                cleamData();
                this.Close();
            }

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            Manager.ImageClass.getImage(picPhoto);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.ImageClass img = new Manager.ImageClass();

            Manager.DataProduct.ID = txtCode.Text;
            Manager.DataProduct.Name = txtName.Text;
            Manager.DataProduct.Colors = cbColor.SelectedValue.ToString();
            Manager.DataProduct.Brands = cbBrands.SelectedValue.ToString();
            Manager.DataProduct.Size = cbSize.SelectedValue.ToString();
            Manager.DataProduct.ScrennSize = cbSrceenDisplay.SelectedValue.ToString();
            Manager.DataProduct.Units = cbUnit.SelectedValue.ToString();
            Manager.DataProduct.Networks = txtNetwork.Text;
            Manager.DataProduct.Annouced = txtAnnounced.Text;
            Manager.DataProduct.Sim = txtSim.Text;
            Manager.DataProduct.Blutooth = txtBlutood.Text;
            Manager.DataProduct.GPS = txtGPS.Text;
            Manager.DataProduct.Battery = txtBattery.Text;
            Manager.DataProduct.OS = txtOS.Text;
            Manager.DataProduct.Chipset = txtChipset.Text;
            Manager.DataProduct.CPU = txtCPU.Text;
            Manager.DataProduct.GPU = txtGPU.Text;
            Manager.DataProduct.RAM = txtRAM.Text;
            Manager.DataProduct.Memory = txtMemory.Text;
            Manager.DataProduct.FrontCamera = txtFrontCamera.Text;
            Manager.DataProduct.FrontVideo = txtFrontVideo.Text;
            Manager.DataProduct.RearCamera = txtBackCamera.Text;
            Manager.DataProduct.RearVideo = txtBackVideo.Text;
            Manager.DataProduct.Price = txtPrice.Text;
            Manager.DataProduct.StockON = txtON.Text;
            Manager.DataProduct.StockOFF = txtOFF.Text;
            Manager.DataProduct.AmountQty = txtAmonut.Text;
            Manager.DataProduct.SalePrice = txtSellerPrice.Text;
            Manager.DataProduct.Profit = txtProfit.Text;
            Manager.DataProduct.Photo = null;
            Manager.DataProduct.Photo = img.setImage(picPhoto);
            Manager.DataProduct.States = 2;
            Manager.DataProduct.checkEmpty();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleamData();
        }

        private void txtON_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOFF.Text == "" || txtON.Text == "")
                {
                    return;
                }

                int x, y, z;
                x = Convert.ToInt32(txtOFF.Text);
                y = Convert.ToInt32(txtON.Text);

                z = x + y;
                txtAmonut.Text = z.ToString();
            }
            catch
            {
                return;
            }

        }

        private void txtOFF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOFF.Text == "" || txtON.Text == "")
                {
                    return;
                }

                int x, y, z;
                x = Convert.ToInt32(txtOFF.Text);
                y = Convert.ToInt32(txtON.Text);

                z = x + y;
                txtAmonut.Text = z.ToString();
            }
            catch
            {
                MessageBox.Show("input value Integer");
                return;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                return;
            }

            double x, y, z;
            x = Convert.ToDouble(txtPrice.Text);
            y = 1.5;

            z = x * y;
            txtSellerPrice.Text = z.ToString();
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSrceenDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbColor_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setComboBox("select * from color", cbColor, "colorname", "colorid");

        }

        private void cbBrands_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setComboBox("select * from brands", cbBrands, "branname", "brandid");

        }

        private void cbSize_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setComboBox("select * from size", cbSize, "sizename", "sizeid");

        }

        private void cbSrceenDisplay_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setComboBox("select * from ScreenDisplay", cbSrceenDisplay, "screenSize", "screenId");

        }

        private void cbUnit_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setComboBox("select * from unit", cbUnit, "uname", "usid");

        }
    }
}
