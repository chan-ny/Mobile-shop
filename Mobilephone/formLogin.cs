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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rAdmin.Checked == true)
            {
                Manager.Login.loginAdmain(txtAdmin.Text, txtpwd.Text, new formLogin());
                txtAdmin.Text = "";
                txtpwd.Text = "";
                //this.Hide();
            }
            if(rVender.Checked== true)
            {
                Manager.Login.loginUser(txtAdmin.Text, txtpwd.Text, new formLogin());
                txtAdmin.Text = "";
                txtpwd.Text = "";
                //this.Hide();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
