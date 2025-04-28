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
using System.Threading;
using System.Timers;

namespace GameShop_V1._0.Forms
{
    public partial class Home : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private List<ProductViewModel> productViews;
        private bool sortAscending = true;
        private System.Windows.Forms.Timer timer;

        private int quantity = 1;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbCurrentUser.Text = GlobalInfo.CurrentUser.UserName;

            if (GlobalInfo.CurrentUser.IsAdmin)
            {
                btnAdmin.Enabled = true;
                btnAdmin.Visible = true;
            }
            else
            {
                btnAdmin.Enabled = false;
                btnAdmin.Visible = false;
            }

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
            dvgProducts_SetSelectedProduct();
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
            dvgProducts_SetSelectedProduct();
        }

        private void dvgProducts_SetSelectedProduct()
        {
            var selectedProduct = dgvProducts.CurrentRow.DataBoundItem as ProductViewModel;

            tbName.Text = selectedProduct.Name;
            lbType.Text = selectedProduct.TypeProduct;
            lbPrice.Text = selectedProduct.Price;
            lbStock.Text = selectedProduct.StockStatus;
            Product product = productBusiness.GetProductByName(selectedProduct.Name);
            tbDescription.Text = product.Description + $"{Environment.NewLine}Developed by {product.Company}";
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbType_Click(object sender, EventArgs e)
        {

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

        private void btnCart_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            cart.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var selectedProductView = dgvProducts.CurrentRow.DataBoundItem as ProductViewModel;
            Product product = productBusiness.GetProductByName(selectedProductView.Name);

            CartProductViewModel cartProductView = new CartProductViewModel()
            {
                Name = product.Name,
                Type = product.TypeProduct.Name,
                Price = product.Price,
                Quantity = quantity,
            };

            if (GlobalInfo.Cart.Any(x => x.Name == cartProductView.Name))
            {
                CartProductViewModel productToUpdate = GlobalInfo.Cart.FirstOrDefault(x => x.Name == cartProductView.Name);
                productToUpdate.Quantity += cartProductView.Quantity;
            }
            else
            {
                GlobalInfo.Cart.Add(cartProductView);
            }          
            ShowAddedToCartFor2Seconds();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            admin.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        private void ShowAddedToCartFor2Seconds()
        {
            lbAddedToCartMessage.Visible = true;

            // Create and configure the timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000; // 2 seconds (2000 milliseconds)
            timer.Tick += Timer_Tick; // Event handler when timer ticks
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Hide the label after the timer ticks
            lbAddedToCartMessage.Visible = false;

            // Stop the timer
            timer.Stop();
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(tbQuantity.Text, out num))
            {
                if (int.Parse(tbQuantity.Text) > 99)
                {
                    num = 99;
                    tbQuantity.Text = num.ToString();
                    quantity = num;
                    return;
                }

                if (int.Parse(tbQuantity.Text) <= 0)
                {
                    num = 1;
                    tbQuantity.Text = num.ToString();
                    quantity = num;
                    return;
                }
            }
        }
    }
}
