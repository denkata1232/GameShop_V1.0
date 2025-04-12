using Data;
using Data.Models;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            TypeProduct typeProduct =
                new TypeProduct { Name = "Game" };
            GameShopContext context = new GameShopContext();
            context.TypeProducts.Add(typeProduct);
            context.SaveChanges();

            List<TypeProduct> types = context.TypeProducts.ToList();
            dataGridView1.DataSource = types;
        }
    }
}
