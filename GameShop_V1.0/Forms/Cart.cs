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
using System.Xml.Linq;

namespace GameShop_V1._0.Forms
{
    public partial class Cart : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private OrderBusiness orderBusiness => new OrderBusiness(context);
        private OrderProductBusiness orderProductBusiness => new OrderProductBusiness(context);
        private int quantity;
        public Cart()
        {
            InitializeComponent();
            lbCurrentUser.Text = GlobalInfo.CurrentUser.UserName;
        }

        /// <summary>
        /// On click of the log out button, clears the cart and current user, shows the login form and hides the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            GlobalInfo.Cart = new List<CartProductViewModel>();
            GlobalInfo.CurrentUser = null;
            Login login = new Login();
            login.Show();
            login.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        /// <summary>
        /// On click of the home labels, shows the home form and hides the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// On click of the home button, shows the home form and hides the current form
        /// </summary>

        private void LoadHome()
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        /// <summary>
        /// On form load, sets the data source of the DataGridView to the cart, sets the column width, and updates the total price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Cart_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = GlobalInfo.Cart;
            dgvProducts.Columns["Name"].Width = 225;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            dvgProducts_SetSelectedProduct();
            UpdateTotalPrice();
        }

        /// <summary>
        /// On click of the confirm purchase button,
        /// creates an order with the current user and date,
        /// adds products to the order, updates the product quantities in the database,
        /// shows a success message and clears the cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConfirmPurchase_Click(object sender, EventArgs e)
        {

            Order order = new Order()
            {
                User = GlobalInfo.CurrentUser,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>()
            };

            string message = string.Empty;
            foreach (var product in GlobalInfo.Cart)
            {
                Product productInBase = productBusiness.GetProductByName(product.Name);
                message = orderBusiness.AddProductToOrder(order, productInBase, product.Quantity);

                if (message == "Quantity is out of bound!")
                {
                    MessageBox.Show($"Not enough quantity in stock for product: {product.Name}");
                    return;
                }
            }

            foreach (var product in GlobalInfo.Cart)
            {
                Product productToUpdate = productBusiness.GetProductByName(product.Name);
                productToUpdate.Quantity -= product.Quantity;
                productBusiness.UpdateProduct(productToUpdate);
            }

            MessageBox.Show(orderBusiness.OrderToString(order), "Successfull order!");
            GlobalInfo.Cart.Clear();
            LoadHome();

        }

        /// <summary>
        /// On click of the remove from cart button, removes the selected product from the cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.Cart.Count != 0 && dgvProducts.SelectedRows[0] != null)
            {
                var selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as CartProductViewModel;

                GlobalInfo.Cart.Remove(selectedProduct);
                dgvProducts.SelectedRows[0].Selected = false;
                dgvProducts.DataSource = null;
                dgvProducts.Refresh();
                dgvProducts.DataSource = GlobalInfo.Cart;
                dgvProducts.Columns["Name"].Width = 225;
                UpdateTotalPrice();


                if (!GlobalInfo.Cart.Any())
                {
                    lbType.Text = "Type";
                    tbName.Text = "Title";
                    lbPrice.Text = "00.00$";
                    tbQuantity.Text = "1";
                }
            }
                
        }

        /// <summary>
        /// On click of the plus or minus button, increases or decreses (respectfully) the quantity of the selected product in the cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.Cart.Count != 0)
            {
                quantity = int.Parse(tbQuantity.Text);
                if (quantity + 1 < 100)
                {
                    quantity++;
                }
                tbQuantity.Text = quantity.ToString();
                NewQuantity(tbName.Text);
                dvgProducts_SetSelectedProduct();
                dgvProducts.Refresh();
                UpdateTotalPrice();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.Cart.Count != 0)
            {
                quantity = int.Parse(tbQuantity.Text);
                if (quantity - 1 != 0)
                {
                    quantity--;
                }
                tbQuantity.Text = quantity.ToString();
                NewQuantity(tbName.Text);
                dvgProducts_SetSelectedProduct();
                dgvProducts.Refresh();
                UpdateTotalPrice();
            }
        }

        /// <summary>
        /// Sets the selected product in the DataGridView to the text boxes and labels
        /// </summary>

        private void dvgProducts_SetSelectedProduct()
        {
            if (GlobalInfo.Cart.Count > 0 && dgvProducts.SelectedRows[0].Index >= 0)
            {
                var selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as CartProductViewModel;
                tbName.Text = selectedProduct.Name;
                lbType.Text = selectedProduct.Type;
                lbPrice.Text = (selectedProduct.Price * selectedProduct.Quantity).ToString() + "$";
                tbQuantity.Text = selectedProduct.Quantity.ToString();
                quantity = selectedProduct.Quantity;
            }       
        }

        /// <summary>
        /// Makes sure that the selected product in the DataGridView is set to the text boxes and labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                return;
            }

            if (GlobalInfo.Cart.Count != 0 && dgvProducts.DataSource != null)
            {
                dvgProducts_SetSelectedProduct();
            }      
        }

        /// <summary>
        /// Updates the quantity of the selected product in the cart
        /// </summary>
        /// <param name="name"></param>

        private void NewQuantity(string name)
        {
            CartProductViewModel product = GlobalInfo.Cart.FirstOrDefault(p => p.Name == name);
            product.Quantity = quantity;
        }

        /// <summary>
        /// Updates the total price label with the sum of all products in the cart
        /// </summary>

        private void UpdateTotalPrice()
        {
            lbTotalPrice.Text = (GlobalInfo.Cart.Sum(x => x.Quantity * x.Price)).ToString() + "$";
        }   
    }
}
