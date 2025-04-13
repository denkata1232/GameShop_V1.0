using Business.businessLogic;
using Data;
using Data.Models;
using GameShop_V1._0.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GameShop_V1._0
{
    public partial class Login : Form
    {
        private UserBusiness userBusiness = new UserBusiness(new GameShopContext());

        public Login()
        {
            InitializeComponent();
        }

        private void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            lbUsername.Visible = true;
            lbPassword.Visible = true;
            lbEmail.Visible = false;

            tbUsername.Visible = true;
            tbPassword.Visible = true;
            tbEmail.Visible = false;

            btnLogin.Visible = true;
            btnRegister.Visible = false;

        }

        private void rbRegister_CheckedChanged(object sender, EventArgs e)
        {
            lbUsername.Visible = true;
            lbPassword.Visible = true;
            lbEmail.Visible = true;

            tbUsername.Visible = true;
            tbPassword.Visible = true;
            tbEmail.Visible = true;

            btnLogin.Visible = false;
            btnRegister.Visible = true;

        }

        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string email = tbEmail.Text;
            User user = new User()
            {
                UserName = username,
                Password = password,
                Email = email
            };

            if (tbPassword.Text == GlobalInfo.SecretAdminPassword)
            {
                user.IsAdmin = true;
            }

            MessageBox.Show(userBusiness.AddUser(user));

            Login login = new Login();
            login.Show();
            login.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            User user = userBusiness.GetUser(username, password);

            if (user == null)
            {
                MessageBox.Show($"User: {username} doesn't exist!");
                return;
            }

            MessageBox.Show($"Successfully loged in as {username}");

            GlobalInfo.CurrentUser = user;

            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }
    }
}
