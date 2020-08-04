using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobilephone
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            customerMenu();
        }

        private void customerMenu()
        {
            panelProduct.Visible = false;
            panelCustomer.Visible = false;
            panelSeller.Visible = false;
        }

        private void hideMenu()
        {
            if (panelProduct.Visible == true)
            {
                panelProduct.Visible = false;
            }
            if (panelCustomer.Visible == true)
            {
                panelCustomer.Visible = false;
            }
            if(panelSeller.Visible == true)
            {
                panelSeller.Visible = false;
            }

        }

        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void showColor(Button btn)
        {
            if (btn.ForeColor != System.Drawing.Color.Black && btn.ForeColor != System.Drawing.Color.Gainsboro)
            {
                defuaftForeColor();
                changeForeColor(btn);
            }
            else
            {
                defuaftForeColor();
            }
        }
        private void changeForeColor(Button btn)
        {
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.Gainsboro;
        }
        private void defuaftForeColor()
        {
            button3.ForeColor = Color.White;
            button3.BackColor = Color.RoyalBlue;
            button4.ForeColor = Color.White;
            button4.BackColor = Color.RoyalBlue;
            btnpBrands.ForeColor = Color.White;
            btnpBrands.BackColor = Color.RoyalBlue;
            btnpColor.ForeColor = Color.White;
            btnpColor.BackColor = Color.RoyalBlue;
            btnpUnit.ForeColor = Color.White;
            btnpUnit.BackColor = Color.RoyalBlue;
            btniOrder.ForeColor = Color.White;
            btniOrder.BackColor = Color.RoyalBlue;
            btniStock.ForeColor = Color.White;
            btniStock.BackColor = Color.RoyalBlue;
            btniSupplier.ForeColor = Color.White;
            btniSupplier.BackColor = Color.RoyalBlue;
            btnsCustomer.ForeColor = Color.White;
            btnsCustomer.BackColor = Color.RoyalBlue;
            btnsSeller.ForeColor = Color.White;
            btnsSeller.BackColor = Color.RoyalBlue;

        }

        private Form active;
        private void loadForm(Form choin,object btnClick,Panel control)
        {
         if(active != null)
            {
                active.Close();
            }
            active = choin;
            choin.TopLevel = false;
            choin.FormBorderStyle = FormBorderStyle.None;
            choin.Dock = DockStyle.Fill;
            control.Controls.Add(choin);
            control.Tag = choin;
            choin.BringToFront();
            choin.Show();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadForm(new backgroup(), sender, panelSubform);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            showMenu(panelProduct);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            showMenu(panelCustomer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showColor(button3);
            loadForm(new FormData.formProduct(), sender, panelSubform);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            showColor(button4);
            loadForm(new FormData.formSize(), sender, panelSubform);

        }

        private void btnpBrands_Click(object sender, EventArgs e)
        {
            showColor(btnpBrands);
            loadForm(new FormData.formBrands(), sender, panelSubform);


        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            showMenu(panelSeller);
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            hideMenu();
            loadForm(new FormData.formStaff(), sender, panelSubform);

        }

        private void btnpColor_Click(object sender, EventArgs e)
        {
            showColor(btnpColor);
            loadForm(new FormData.formColor(), sender, panelSubform);

        }

        private void btnpUnit_Click(object sender, EventArgs e)
        {
            showColor(btnpUnit);
            loadForm(new FormData.formUnit(), sender, panelSubform);

        }

        private void btniOrder_Click(object sender, EventArgs e)
        {
            showColor(btniOrder);
            loadForm(new FormData.formImportProduct(), sender, panelSubform);

        }

        private void btniStock_Click(object sender, EventArgs e)
        {
            showColor(btniStock);
            loadForm(new FormData.formStockIN(), sender, panelSubform);

        }

        private void btniSupplier_Click(object sender, EventArgs e)
        {
            showColor(btniSupplier);
            loadForm(new FormData.formSupplier(), sender, panelSubform);

        }

        private void btnsCustomer_Click(object sender, EventArgs e)
        {
            showColor(btnsCustomer);
            loadForm(new FormData.formCustomer(), sender, panelSubform);

        }

        private void btnsSeller_Click(object sender, EventArgs e)
        {
            showColor(btnsSeller);
            loadForm(new FormData.formProductsale(), sender, panelSubform);

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            hideMenu();
            loadForm(new FormData.formReport(), sender, panelSubform);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            hideMenu();
            loadForm(new backgroup(), sender, panelSubform);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new FormData.formDisplay(), sender, panelSubform);

        }
    }
}
