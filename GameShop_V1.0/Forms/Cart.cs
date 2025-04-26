using GameShop_V1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShop_V1._0.Forms
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
            lbCurrentUser.Text = GlobalInfo.CurrentUser.UserName;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            GlobalInfo.Cart = new List<CartProductViewModel>();
            GlobalInfo.CurrentUser = null;
            Login login = new Login();
            login.Show();
            login.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = GlobalInfo.Cart;
            dgvProducts.Columns["Name"].Width = 225;
        }
    }
}
