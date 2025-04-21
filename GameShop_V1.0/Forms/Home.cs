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
using System.Data.Entity;
using GameShop_V1._0.ViewModels;
using Business.businessLogic;

namespace GameShop_V1._0.Forms
{
    public partial class Home : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private List<ProductViewModel> productViews;
        private bool sortAscending = true;

        private int quantity;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbCurrentUser.Text = GlobalInfo.CurrentUser.UserName;

            productViews = context.Products
                .Include(p => p.TypeProduct)
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    TypeProduct = p.TypeProduct.Name,
                    Price = p.Price + "$",
                    StockStatus = p.Quantity > 0 ? "In Stock" : "Out of Stock"
                })
                .ToList();

            dgvProducts.DataSource = productViews;
            dgvProducts.Columns["Name"].Width = 225;

            foreach (DataGridViewColumn column in dgvProducts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            dgvProducts.ColumnHeaderMouseClick += dgvProducts_ColumnHeaderMouseClick;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
        }

        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvProducts.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrEmpty(columnName)) return;

            var prop = typeof(ProductViewModel).GetProperty(columnName);
            if (prop == null) return;

            var sorted = sortAscending
                ? productViews.OrderBy(p => prop.GetValue(p)).ToList()
                : productViews.OrderByDescending(p => prop.GetValue(p)).ToList();

            dgvProducts.DataSource = sorted;
            sortAscending = !sortAscending;
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem == null)
                return;

            var selectedProduct = dgvProducts.CurrentRow.DataBoundItem as ProductViewModel;
            if (selectedProduct == null)
                return;

            tbName.Text = selectedProduct.Name;
            lbType.Text = selectedProduct.TypeProduct;
            lbPrice.Text = selectedProduct.Price;
            lbStock.Text = selectedProduct.StockStatus;
            Product product = productBusiness.GetProductByName(selectedProduct.Name);
            tbDescription.Text = product.Description;
        }


        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbType_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            GlobalInfo.CurrentUser = null;
            Login login = new Login();
            login.Show();
            login.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            quantity = int.Parse(tbQuantity.Text);
            if (quantity + 1 < 100)
            {
                quantity++;
            }
            tbQuantity.Text = quantity.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            quantity = int.Parse(tbQuantity.Text);
            if (quantity - 1 != 0)
            {
                quantity--;
            }
            tbQuantity.Text = quantity.ToString();
        }
    }
}
