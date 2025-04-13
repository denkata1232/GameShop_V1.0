using GameShop_V1._0.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShop_V1._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            lbUsername.Visible = true;
            lbPassword.Visible = true;
            lbEmail.Visible = false;
            lbAdminPassword.Visible = false;

            tbUsername.Visible = true;
            tbPassword.Visible = true;
            tbEmail.Visible = false;
            tbAdminPassword.Visible = false;

            btnLogin.Visible = true;
            btnRegister.Visible = false;

            gb2.Visible = false;
        }

        private void rbRegister_CheckedChanged(object sender, EventArgs e)
        {
            lbUsername.Visible = true;
            lbPassword.Visible = true;
            lbEmail.Visible = true;
            lbAdminPassword.Visible = false;

            tbUsername.Visible = true;
            tbPassword.Visible = true;
            tbEmail.Visible = true;
            tbAdminPassword.Visible = false;

            btnLogin.Visible = false;
            btnRegister.Visible = true;

            gb2.Visible = true;
        }

        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            tbAdminPassword.Visible = false;
            lbAdminPassword.Visible = false;
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            tbAdminPassword.Visible = true;
            lbAdminPassword.Visible = true;
        }
    }
}
