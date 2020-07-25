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
            panelReport.Visible = false;
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
            if(panelReport.Visible == true)
            {
                panelReport.Visible = false;
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
            btnrCustomer.ForeColor = Color.White;
            btnrCustomer.BackColor = Color.RoyalBlue;
            btnrImport.ForeColor = Color.White;
            btnrImport.BackColor = Color.RoyalBlue;
            btnrProduct.ForeColor = Color.White;
            btnrProduct.BackColor = Color.RoyalBlue;
            btnrSale.ForeColor = Color.White;
            btnrSale.BackColor = Color.RoyalBlue;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showColor(button4);
        }

        private void btnpBrands_Click(object sender, EventArgs e)
        {
            showColor(btnpBrands);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            showMenu(panelSeller);
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btnpColor_Click(object sender, EventArgs e)
        {
            showColor(btnpColor);
        }

        private void btnpUnit_Click(object sender, EventArgs e)
        {
            showColor(btnpUnit);
        }

        private void btniOrder_Click(object sender, EventArgs e)
        {
            showColor(btniOrder);
        }

        private void btniStock_Click(object sender, EventArgs e)
        {
            showColor(btniStock);
        }

        private void btniSupplier_Click(object sender, EventArgs e)
        {
            showColor(btniSupplier);
        }

        private void btnsCustomer_Click(object sender, EventArgs e)
        {
            showColor(btnsCustomer);
        }

        private void btnsSeller_Click(object sender, EventArgs e)
        {
            showColor(btnsSeller);
        }

        private void btnrProduct_Click(object sender, EventArgs e)
        {
            showColor(btnrProduct);
        }

        private void btnrCustomer_Click(object sender, EventArgs e)
        {
            showColor(btnrCustomer);
        }

        private void btnrSale_Click(object sender, EventArgs e)
        {
            showColor(btnrSale);
        }

        private void btnrImport_Click(object sender, EventArgs e)
        {
            showColor(btnrImport);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            showMenu(panelReport);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            hideMenu();
        }
    }
}
