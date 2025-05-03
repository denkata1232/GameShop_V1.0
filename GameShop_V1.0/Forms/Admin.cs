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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShop_V1._0.Forms
{
    public partial class Admin : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private TypeProductBusiness typeProductBusiness => new TypeProductBusiness(context);
        private OrderBusiness orderBusiness => new OrderBusiness(context);
        private UserBusiness userBusiness => new UserBusiness(context);

        private List<AdminProductViewModel> productViews = new List<AdminProductViewModel>();
        private List<TypeProduct> typeProducts = new List<TypeProduct>();
        private List<User> users = new List<User>();
        private List<AdminOrderViewModel> orderViews = new List<AdminOrderViewModel>();

        List<Control> controlsProducts = new List<Control>();
        List<Control> controlsTypes = new List<Control>();
        List<Control> controlsUsers = new List<Control>();
        List<Control> controlsOrders = new List<Control>();

        private Timer timer;

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

            controlsTypes.AddRange(new List<Control>()
            {
                dgvTypeProduct,
                tbTypeProductName,
                lbTypeProductName
            });

            controlsUsers.AddRange(new List<Control>()
            {
                lbAllUsersWithAgame,
                tbAllUsersWithAgame,
                lbUserWithProducts,
                btnFind,
                dgvUsers,
                lbUserName,
                lbPassword,
                lbEmail,
                tbUserName,
                tbPassword,
                tbEmail,
                chbIsAdmin
            });

            controlsOrders.AddRange(new List<Control>()
            {
                lbFindOrder,
                rbByProduct,
                rbByUser,
                tbByProduct,
                tbByUser,
                lbOrdersQuerrie,
                btnFindOrdersByDate,
                dgvOrders,
                lbUserNameOrder,
                lbDate,
                lbOrderProducts,
                lblProductsOrder,
                lbTotalPrice,
                tbUserNameOrder,
                tbDate,
                cbProductToAddInOrder,
                tbQuantityOrder,
                btnAddProductToOrder,
                btnRemoveFromOrder,
                tbTotalPrice
            });

            /// updating products grid view
            UpdateDgvProducts();

            dgvProducts.ClearSelection();
            
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            dgvProducts.ColumnHeaderMouseClick += dgvProducts_ColumnHeaderMouseClick;

            /// updating typeProducts grid view
            UpdateDgvTypeProducts();

            dgvTypeProduct.ClearSelection();

            dgvTypeProduct.SelectionChanged += dgvTypeProduct_SelectionChanged;
            dgvTypeProduct.ColumnHeaderMouseClick += dgvTypeProducts_ColumnHeaderMouseClick;

            /// updating users grid view
            UpdateDgvUsers();

            dgvUsers.ClearSelection();

            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.ColumnHeaderMouseClick += dgvUsers_ColumnHeaderMouseClick;

            /// updating orders grid view
            UpdateDgvOrders();

            dgvOrders.ClearSelection();

            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            dgvOrders.ColumnHeaderMouseClick += dgvOrders_ColumnHeaderMouseClick;
        }

        private void HandleSelectionChanged(DataGridView gridView, Func<bool> hasData, Action onSelect)
        {
            if (gridView.SelectedRows.Count == 0)
                return;

            if (hasData() && gridView.DataSource != null)
            {
                onSelect();
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvProducts,
                           () => context.Products.Any(),
                           dvgProducts_SetSelectedProduct);
        }

        private void dgvTypeProduct_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvTypeProduct,
                           () => context.TypeProducts.Any(),
                           dvgTypeProducts_SetSelectedTypeProduct);
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvUsers,
                           () => context.Users.Any(),
                           dgvUsers_SetSelectedUser);
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvOrders,
                           () => context.Orders.Any(),
                           dgvOrders_SetSelectedOrder);
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

        private void dvgTypeProducts_SetSelectedTypeProduct()
        {
            if (context.TypeProducts.Count() != 0)
            {
                TypeProduct typeProduct = dgvTypeProduct.SelectedRows[0].DataBoundItem as TypeProduct;
                tbTypeProductName.Text = typeProduct.Name;
            }
        }

        private void dgvUsers_SetSelectedUser()
        {
            if (context.Users.Count() != 0)
            {
                User user = dgvUsers.SelectedRows[0].DataBoundItem as User;
                tbUserName.Text = user.UserName;
                tbPassword.Text = user.Password;
                tbEmail.Text = user.Email;
                chbIsAdmin.Checked = user.IsAdmin;
            }
        }

        private void dgvOrders_SetSelectedOrder()
        {
            if (context.Orders.Count() != 0)
            {
                AdminOrderViewModel order = dgvOrders.SelectedRows[0].DataBoundItem as AdminOrderViewModel;
                tbUserNameOrder.Text = order.UserName;
                tbDate.Text = order.Date.ToString();

                Order orderInBase = orderBusiness.GetOrderById(order.OrderId);

                decimal totalPrice = 0;
                List<OrderProduct> orderProducts = orderInBase.OrderProducts.ToList();
                List<string> productsInOrder = new List<string>();
                foreach (var orderProduct in orderProducts)
                {
                    orderProduct.Product = productBusiness.GetProductById(orderProduct.ProductId);
                    productsInOrder.Add($"{orderProduct.Product.Name} X {orderProduct.Quantity}");
                    totalPrice += orderProduct.Product.Price * orderProduct.Quantity;
                }
                lbOrderProducts.DataSource = productsInOrder;
                tbTotalPrice.Text = totalPrice.ToString();

                List<string> productsAsStrings = context.Products.Select(x => x.Name).ToList();
                cbProductToAddInOrder.DataSource = productsAsStrings;
            }
        }

        private void DataGridView_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e, DataGridView gridView, ref List<T> dataSource)
        {
            string columnName = gridView.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrEmpty(columnName)) return;

            var prop = typeof(T).GetProperty(columnName);
            if (prop == null) return;

            var sorted = sortAscending
                ? dataSource.OrderBy(p => prop.GetValue(p)).ToList()
                : dataSource.OrderByDescending(p => prop.GetValue(p)).ToList();

            gridView.DataSource = sorted;
            sortAscending = !sortAscending;
        }

        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvProducts, ref productViews);
        }

        private void dgvTypeProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvTypeProduct, ref typeProducts);
        }

        private void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvUsers, ref users);
        }
        private void dgvOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvOrders, ref orderViews);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = true);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = false);
            UpdateDgvProducts();
        }

        private void btnTypeProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = true);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = false);
            UpdateDgvTypeProducts();
        }

        private void tbUsers_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = true);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = true);
            controlsUsers.ForEach(x => x.Visible = false);
        }

        private void UpdateDgvProducts()
        {
            dgvProducts.DataSource = null;
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
            dgvProducts.Columns[0].Width = 20;
            dgvProducts.Columns["Price"].Width = 45;
            dgvProducts.Columns["Quantity"].Width = 45;

            cbType.DataSource = null;
            cbType.DataSource = context.TypeProducts.Select(x => x.Name).ToList();
        }

        private void UpdateDgvTypeProducts()
        {
            dgvTypeProduct.DataSource = null;
            typeProducts = context.TypeProducts.ToList();
            dgvTypeProduct.DataSource = typeProducts;
        }

        private void UpdateDgvUsers()
        {
            dgvUsers.DataSource = null;
            users = context.Users.ToList();
            dgvUsers.DataSource = users;
        }

        private void UpdateDgvOrders()
        {
            dgvOrders.DataSource = null;
            orderViews = context.Orders
                .Select(x => new AdminOrderViewModel()
                {
                    OrderId = x.OrderId,
                    UserName = x.User.UserName,
                    Date = x.Date,
                    ProductCount = x.OrderProducts.Count
                }).ToList();

            dgvOrders.DataSource = orderViews;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (controlsProducts.Any(x => x.Visible))
            {
                SetControlsToEmpty(controlsProducts);
                dgvProducts.ClearSelection();
            }
            else if (controlsTypes.Any(x => x.Visible))
            {
                SetControlsToEmpty(controlsTypes);
                dgvTypeProduct.ClearSelection();
            }
            else if (controlsUsers.Any(x => x.Visible))
            {
                SetControlsToEmpty(controlsUsers);
                dgvUsers.ClearSelection();
                chbIsAdmin.Checked = false;
                lbUserWithProducts.Items.Clear();
            }
            else if (controlsOrders.Any(x => x.Visible))
            {
                SetControlsToEmpty(controlsOrders);
            }
        }

        private void SetControlsToEmpty(List<Control> controls)
        {
            foreach (var control in controls)
            {
                if (control.GetType() == typeof(TextBox) || control.GetType() == typeof(ComboBox))
                {
                    control.Text = "";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (controlsProducts.Any(x => x.Visible))
            {
                if (controlsProducts.GetRange(1, controlsProducts.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                string name = tbProductName.Text;
                TypeProduct type = context.TypeProducts.FirstOrDefault(x => x.Name == cbType.Text);
                string company = tbCompany.Text;
                string description = tbDescription.Text;
                decimal price = decimal.Parse(tbPrice.Text);
                int quantity = int.Parse(tbQuantity.Text);

                Product productToAdd = new Product()
                {
                    Name = name,
                    Company = company,
                    TypeProduct = type,
                    Description = description,
                    Price = price,
                    Quantity = quantity,
                };

                tbOutputMessage.Text = productBusiness.AddProduct(productToAdd);
                UpdateDgvProducts();

                dgvProducts.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["Name"].Value == productToAdd.Name)
                    .ToArray()[0]
                    .Selected = true;
            }
            else if (controlsTypes.Any(x => x.Visible))
            {
                if (controlsTypes.GetRange(1, controlsTypes.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                string name = tbTypeProductName.Text;

                TypeProduct typeProductToAdd = new TypeProduct()
                {
                    Name = name
                };

                tbOutputMessage.Text = typeProductBusiness.AddTypeProduct(typeProductToAdd);
                UpdateDgvTypeProducts();

                dgvTypeProduct.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["Name"].Value == typeProductToAdd.Name)
                    .ToArray()[0]
                    .Selected = true;
            }
            else if (controlsUsers.Any(x => x.Visible))
            {
                if (controlsUsers.GetRange(5, controlsUsers.Count - 5).Any(x => x.Text == ""))
                {
                    return;
                }

                string username = tbUserName.Text;
                string password = tbPassword.Text;
                string email = tbEmail.Text;
                bool isAdmin = chbIsAdmin.Checked;

                User userToAdd = new User()
                {
                    UserName = username,
                    Password = password,
                    Email = email,
                    IsAdmin = isAdmin
                };

                tbOutputMessage.Text = userBusiness.AddUser(userToAdd);
                UpdateDgvUsers();

                dgvUsers.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["UserName"].Value == userToAdd.UserName)
                    .ToArray()[0]
                    .Selected = true;
            }
            ShowOutputMessageFor3Seconds();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (controlsProducts.Any(x => x.Visible))
            {
                if (controlsProducts.GetRange(1, controlsProducts.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value);
                string name = tbProductName.Text;
                TypeProduct type = context.TypeProducts.FirstOrDefault(x => x.Name == cbType.Text);
                int typeProductId = context.TypeProducts.FirstOrDefault(x => x.TypeProductId == type.TypeProductId).TypeProductId;
                string company = tbCompany.Text;
                string description = tbDescription.Text;
                decimal price = decimal.Parse(tbPrice.Text);
                int quantity = int.Parse(tbQuantity.Text);

                Product updatedProduct = new Product()
                {
                    ProductId = id,
                    Name = name,
                    TypeProductId = typeProductId,
                    TypeProduct = type,
                    Company = company,
                    Description = description,
                    Price = price,
                    Quantity = quantity
                };

                tbOutputMessage.Text = productBusiness.UpdateProduct(updatedProduct);
                UpdateDgvProducts();

                dgvProducts.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["Name"].Value == updatedProduct.Name)
                    .ToArray()[0]
                    .Selected = true;
            }
            else if (controlsTypes.Any(x => x.Visible))
            {
                if (controlsTypes.GetRange(1, controlsTypes.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                int id = Convert.ToInt32(dgvTypeProduct.SelectedRows[0].Cells[0].Value);
                string name = tbTypeProductName.Text;

                TypeProduct updatedTypeProduct = new TypeProduct()
                {
                    TypeProductId = id,
                    Name = name
                };

                tbOutputMessage.Text = typeProductBusiness.UpdateTypeProduct(updatedTypeProduct);
                UpdateDgvTypeProducts();

                dgvTypeProduct.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["Name"].Value == updatedTypeProduct.Name)
                    .ToArray()[0]
                    .Selected = true;
            }
            else if (controlsUsers.Any(x => x.Visible))
            {
                if (controlsUsers.GetRange(5, controlsUsers.Count - 5).Any(x => x.Text == ""))
                {
                    return;
                }

                int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                string username = tbUserName.Text;
                string password = tbPassword.Text;
                string email = tbEmail.Text;
                bool isAdmin = chbIsAdmin.Checked;

                User updatedUser = new User()
                {
                    UserId = id,
                    UserName = username,
                    Password = password,
                    Email = email,
                    IsAdmin = isAdmin
                };

                tbOutputMessage.Text = userBusiness.UpdateUser(updatedUser);
                UpdateDgvUsers();

                dgvUsers.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["UserName"].Value == updatedUser.UserName)
                    .ToArray()[0]
                    .Selected = true;
            }
            ShowOutputMessageFor3Seconds();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (controlsProducts.Any(x => x.Visible))
            {
                if (controlsProducts.GetRange(1, controlsProducts.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                AdminProductViewModel adminProductView = dgvProducts.SelectedRows[0].DataBoundItem as AdminProductViewModel;

                Product productToRemove = productBusiness.GetProductByName(adminProductView.Name);
                tbOutputMessage.Text = productBusiness.DeleteProduct(productToRemove);
                UpdateDgvProducts();
            }
            else if (controlsTypes.Any(x => x.Visible))
            {
                if (controlsTypes.GetRange(1, controlsTypes.Count - 1).Any(x => x.Text == ""))
                {
                    return;
                }

                TypeProduct typeProductToRemove = dgvTypeProduct.SelectedRows[0].DataBoundItem as TypeProduct;
                tbOutputMessage.Text = typeProductBusiness.DeleteTypeProduct(typeProductToRemove);
                UpdateDgvTypeProducts();
            }
            else if (controlsUsers.Any(x => x.Visible))
            {
                if (controlsUsers.GetRange(5, controlsUsers.Count - 5).Any(x => x.Text == ""))
                {
                    return;
                }

                User userToRemove = dgvUsers.SelectedRows[0].DataBoundItem as User;
                tbOutputMessage.Text = userBusiness.DeleteUser(userToRemove);
                UpdateDgvUsers();
            }
            ShowOutputMessageFor3Seconds();
        }
        private void ShowOutputMessageFor3Seconds()
        {
            tbOutputMessage.Visible = true;

            // Create and configure the timer
            timer = new Timer();
            timer.Interval = 3000; // 3 seconds (3000 milliseconds)
            timer.Tick += Timer_Tick; // Event handler when timer ticks
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Hide the label after the timer ticks
            tbOutputMessage.Visible = false;

            // Stop the timer
            timer.Stop();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Product product = productBusiness.GetProductByName(tbAllUsersWithAgame.Text); 
            if (product != null)
            {
                List<User> usersWithGame = userBusiness.GetAllUsersWithAGameOfChoice(product);
                lbUserWithProducts.DataSource = usersWithGame.Select(x => x.UserName).ToList();
                tbOutputMessage.Text = $"All users that have bought {product.Name}.";
                ShowOutputMessageFor3Seconds();
                return;
            }
            tbOutputMessage.Text = "Invalid input!";
        }

        private void lbUserWithProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = lbUserWithProducts.Text;

            dgvUsers.Rows
                .OfType<DataGridViewRow>()
                .Where(x => (string)x.Cells["UserName"].Value == username)
                .ToArray<DataGridViewRow>()[0]
                .Selected = true;

            dgvUsers_SetSelectedUser();
        }
    }
}
