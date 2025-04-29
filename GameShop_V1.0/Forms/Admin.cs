using Business.businessLogic;
using Data;
using Data.Models;
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
    public partial class Admin : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private TypeProductBusiness TypeProductBusiness => new TypeProductBusiness(context);
        OrderBusiness orderBusiness => new OrderBusiness(context);
        private UserBusiness userBusiness => new UserBusiness(context);
        private List<AdminProductViewModel> productViews = new List<AdminProductViewModel>();
        List<Control> controlsProducts = new List<Control>();

        private bool sortAscending = true;

        public Admin()
        {
            InitializeComponent();
            lbCurrentUser.Text = GlobalInfo.CurrentUser.UserName;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoadHome();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoadHome();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LoadHome();
        }

        private void LoadHome()
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
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

        private void Admin_Load(object sender, EventArgs e)
        {
            controlsProducts.AddRange(new List<Control>() 
            { 
                dgvProducts,
                lbProductName,
                lbType,
                lbDescription,
                lbCompany,
                lbPrice,
                lbQuantity,
                tbProductName,
                cbType,
                tbDescription,
                tbCompany,
                tbPrice,
                tbQuantity
            });

            productViews = context.Products
                .Select(x => new AdminProductViewModel
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Company = x.Company,
                    Description = x.Description,
                    TypeProduct = x.TypeProduct.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList();

            dgvProducts.DataSource = productViews;
            cbType.DataSource = context.TypeProducts.Select(x => x.Name).ToList();
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            dvgProducts_SetSelectedProduct();
            dgvProducts.ColumnHeaderMouseClick += dgvProducts_ColumnHeaderMouseClick;

            
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                return;
            }

            if (context.Products.Count() != 0 && dgvProducts.DataSource != null)
            {
                dvgProducts_SetSelectedProduct();
            }
        }

        private void dvgProducts_SetSelectedProduct()
        {
            if (context.Products.Count() != 0)
            {
                AdminProductViewModel product = dgvProducts.SelectedRows[0].DataBoundItem as AdminProductViewModel;
                tbProductName.Text = product.Name;
                tbCompany.Text = product.Company;
                tbDescription.Text = product.Description;
                tbPrice.Text = product.Price.ToString();
                tbQuantity.Text = product.Quantity.ToString();
                cbType.SelectedItem = product.TypeProduct;
            }
        }

        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvProducts.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrEmpty(columnName)) return;

            var prop = typeof(AdminProductViewModel).GetProperty(columnName);
            if (prop == null) return;

            var sorted = sortAscending
                ? productViews.OrderBy(p => prop.GetValue(p)).ToList()
                : productViews.OrderByDescending(p => prop.GetValue(p)).ToList();

            dgvProducts.DataSource = sorted;
            sortAscending = !sortAscending;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = true);
        }

        private void btnTypeProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
        }

        private void tbUsers_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
        }
    }
}
