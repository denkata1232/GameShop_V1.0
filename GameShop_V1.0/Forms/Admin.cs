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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameShop_V1._0.Forms
{
    /// <summary>
    /// Represents the main administrative form for managing products, orders, users, and product types in the GameShop application.
    /// </summary>
    public partial class Admin : Form
    {
        private GameShopContext context = new GameShopContext();
        private ProductBusiness productBusiness => new ProductBusiness(context);
        private TypeProductBusiness typeProductBusiness => new TypeProductBusiness(context);
        private OrderBusiness orderBusiness => new OrderBusiness(context);
        private UserBusiness userBusiness => new UserBusiness(context);
        private OrderProductBusiness orderProductBusiness => new OrderProductBusiness(context);

        private List<AdminProductViewModel> productViews = new List<AdminProductViewModel>();
        private List<TypeProduct> typeProducts = new List<TypeProduct>();
        private List<User> users = new List<User>();
        private List<AdminOrderViewModel> orderViews = new List<AdminOrderViewModel>();
        private List<string> productsInOrder = new List<string>();
        private List<string> ordersToDysplay = new List<string>();
        private decimal totalPrice = 0;

        private List<Control> controlsProducts = new List<Control>();
        private List<Control> controlsTypes = new List<Control>();
        private List<Control> controlsUsers = new List<Control>();
        private List<Control> controlsOrders = new List<Control>();

        private Timer timer;

        private bool sortAscending = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class and sets the current user's name on the form.
        /// </summary>
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

        /// <summary>
        /// Opens the Home form and closes the current Admin form.
        /// </summary>
        private void LoadHome()
        {
            Home home = new Home();
            home.Show();
            home.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        /// <summary>
        /// Logs out the current user, clears the cart, and navigates to the login form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
        /// Handles the load event of the Admin form, initializing UI controls and populating data grids.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
                tbQuantity,
                lbCopiesSold,
                tbSoldCopies
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
                btnFindOrdersBy,
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

        /// <summary>
        /// Generalized handler for DataGridView selection changes.
        /// </summary>
        /// <param name="gridView">The DataGridView being handled.</param>
        /// <param name="hasData">A predicate indicating whether the data context has relevant data.</param>
        /// <param name="onSelect">The action to execute when a valid selection occurs.</param>
        private void HandleSelectionChanged(DataGridView gridView, Func<bool> hasData, Action onSelect)
        {
            if (gridView.SelectedRows.Count == 0)
                return;

            if (hasData() && gridView.DataSource != null)
            {
                onSelect();
            }
        }
        /// <summary>
        /// DataGridView selection chage event dgvProducts.
        /// </summary>
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvProducts,
                           () => context.Products.Any(),
                           dvgProducts_SetSelectedProduct);
        }
        /// <summary>
        /// DataGridView selection chage event dgvTypeProducts.
        /// </summary>
        private void dgvTypeProduct_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvTypeProduct,
                           () => context.TypeProducts.Any(),
                           dvgTypeProducts_SetSelectedTypeProduct);
        }
        /// <summary>
        /// DataGridView selection chage event dgvUsers.
        /// </summary>
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvUsers,
                           () => context.Users.Any(),
                           dgvUsers_SetSelectedUser);
        }
        /// <summary>
        /// DataGridView selection chage event dgvOrders.
        /// </summary>
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged(dgvOrders,
                           () => context.Orders.Any(),
                           dgvOrders_SetSelectedOrder);
        }

        /// <summary>
        /// Sets the UI controls to reflect the currently selected product in the DataGridView.
        /// </summary>
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

                Product productInBase = productBusiness.GetProductByName(product.Name);

                if (orderProductBusiness.GetAllOrderProducts().Any(x => x.ProductId == productInBase.ProductId))
                {
                    tbSoldCopies.Text = productBusiness.GetSoldCopiesOfSpecificGame(productInBase).ToString();
                }
                else
                {
                    tbSoldCopies.Text = "0";
                }
            }
        }

        /// <summary>
        /// Sets the UI controls to reflect the currently selected typeProduct in the DataGridView.
        /// </summary>
        private void dvgTypeProducts_SetSelectedTypeProduct()
        {
            if (context.TypeProducts.Count() != 0)
            {
                TypeProduct typeProduct = dgvTypeProduct.SelectedRows[0].DataBoundItem as TypeProduct;
                tbTypeProductName.Text = typeProduct.Name;
            }
        }

        /// <summary>
        /// Sets the UI controls to reflect the currently selected user in the DataGridView.
        /// </summary>
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

        /// <summary>
        /// Sets the UI controls to reflect the currently selected order and updates the product list in that order.
        /// </summary>
        private void dgvOrders_SetSelectedOrder()
        {
            if (context.Orders.Count() != 0)
            {
                totalPrice = 0;
                productsInOrder = new List<string>();
                AdminOrderViewModel order = dgvOrders.SelectedRows[0].DataBoundItem as AdminOrderViewModel;
                tbUserNameOrder.Text = order.UserName;
                tbDate.Text = order.Date.ToString();

                UpdateListOrderProducts();
                CalculateTotalPrice();
                UpdateComboboProductToAddInOrder();
            }
        }

        /// <summary>
        /// Generic method for sorting a DataGridView column based on the column header click.
        /// </summary>
        /// <typeparam name="T">The type of objects in the grid's data source.</typeparam>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Mouse event data.</param>
        /// <param name="gridView">The DataGridView to sort.</param>
        /// <param name="dataSource">Reference to the data source to sort.</param>
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
        /// <summary>
        /// Sorting for dgvProducts using DataGridView_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e, DataGridView gridView, ref List<T> dataSource).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Mouse event data.</param>
        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvProducts, ref productViews);
        }
        /// <summary>
        /// Sorting for dgvTypeProducts using DataGridView_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e, DataGridView gridView, ref List<T> dataSource).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Mouse event data.</param>
        private void dgvTypeProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvTypeProduct, ref typeProducts);
        }
        /// <summary>
        /// Sorting for dgvUsers using DataGridView_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e, DataGridView gridView, ref List<T> dataSource).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Mouse event data.</param>
        private void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvUsers, ref users);
        }
        /// <summary>
        /// Sorting for dgvOrders using DataGridView_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e, DataGridView gridView, ref List<T> dataSource).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Mouse event data.</param>
        private void dgvOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_ColumnHeaderMouseClick(sender, e, dgvOrders, ref orderViews);
        }

        /// <summary>
        /// Displays the product-related controls and hides others.
        /// </summary>
        private void btnProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = true);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = false);
            UpdateDgvProducts();
        }

        /// <summary>
        /// Displays the type product-related controls and hides others.
        /// </summary>
        private void btnTypeProducts_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = true);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = false);
            UpdateDgvTypeProducts();
        }

        /// <summary>
        /// Displays the user-related controls and hides others.
        /// </summary>
        private void tbUsers_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = false);
            controlsUsers.ForEach(x => x.Visible = true);
        }

        /// <summary>
        /// Displays the order-related controls and hides others.
        /// </summary>
        private void btnOrders_Click(object sender, EventArgs e)
        {
            controlsProducts.ForEach(x => x.Visible = false);
            controlsTypes.ForEach(x => x.Visible = false);
            controlsOrders.ForEach(x => x.Visible = true);
            controlsUsers.ForEach(x => x.Visible = false);
            UpdateComboboProductToAddInOrder();
        }

        /// <summary>
        /// Updates the products grid view and refreshes the type product dropdown.
        /// </summary>
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

        /// <summary>
        /// Updates the TypeProduct grid view.
        /// </summary>
        private void UpdateDgvTypeProducts()
        {
            dgvTypeProduct.DataSource = null;
            typeProducts = context.TypeProducts.ToList();
            dgvTypeProduct.DataSource = typeProducts;
        }

        /// <summary>
        /// Updates the users grid view.
        /// </summary>
        private void UpdateDgvUsers()
        {
            dgvUsers.DataSource = null;
            users = context.Users.ToList();
            dgvUsers.DataSource = users;
        }

        /// <summary>
        /// Updates the orders grid view.
        /// </summary>
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

        /// <summary>
        /// Populates the list of products in the selected order and updates the UI.
        /// </summary>
        private void UpdateListOrderProducts()
        {
            lbOrderProducts.DataSource = null;
            Order orderInBase = orderBusiness.GetOrderById(Convert.ToInt32(dgvOrders.SelectedRows[0].Cells[0].Value));
            List<OrderProduct> orderProducts = orderInBase.OrderProducts.ToList();
            foreach (var orderProduct in orderProducts)
            {
                orderProduct.Product = productBusiness.GetProductById(orderProduct.ProductId);
                productsInOrder.Add($"{orderProduct.Product.Name} X {orderProduct.Quantity}");
            }
            lbOrderProducts.DataSource = productsInOrder;
        }

        /// <summary>
        /// Updates the combobox of products to add.
        /// </summary>
        private void UpdateComboboProductToAddInOrder()
        {
            cbProductToAddInOrder.DataSource = null;
            List<string> productsAsStrings = context.Products.Select(x => x.Name).ToList();
            cbProductToAddInOrder.DataSource = productsAsStrings;
        }

        /// <summary>
        /// Adds a selected product with quantity to the current order and updates the total price.
        /// Doesn't add it to the database. Just for display.
        /// </summary>
        private void btnAddProductToOrder_Click(object sender, EventArgs e)
        {
            string productName = cbProductToAddInOrder.Text;
            string quantity = tbQuantityOrder.Text;
            productsInOrder.Add($"{productName} X {quantity}");
            lbOrderProducts.DataSource = null;
            lbOrderProducts.DataSource = productsInOrder;
            CalculateTotalPrice();
        }

        /// <summary>
        /// Removes a selected product with quantity to the current order and updates the total price.
        /// Doesn't add it to the database. Just for display.
        /// </summary>
        private void btnRemoveFromOrder_Click(object sender, EventArgs e)
        {
            var selectedItems = lbOrderProducts.SelectedItems.Cast<string>().ToList();

            foreach (var item in selectedItems)
            {
                productsInOrder.Remove(item);
            }
            CalculateTotalPrice();

            lbOrderProducts.DataSource = null;
            lbOrderProducts.DataSource = productsInOrder;
        }

        /// <summary>
        /// Calculates and displays the total price of the current order.
        /// </summary>
        private void CalculateTotalPrice()
        {
            totalPrice = 0;

            foreach (var item in productsInOrder)
            {
                string[] tokens = item.ToString().Split(new[] { " X " }, StringSplitOptions.None).ToArray();
                Product product = productBusiness.GetProductByName(tokens[0]);
                int quantity = int.Parse(tokens[1]);
                totalPrice += product.Price * quantity;
            }
            tbTotalPrice.Text = totalPrice.ToString();
        }

        /// <summary>
        /// Clears form controls based on the currently visible section (Products, Types, Users, or Orders).
        /// </summary>
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
                dgvOrders.ClearSelection();
                productsInOrder.Clear();
                lbOrderProducts.DataSource = null;
                lbOrderProducts.DataSource = productsInOrder;
                tbByProduct.Text = "Product name";
                tbByUser.Text = "Username";
            }
        }

        /// <summary>
        /// Sets all TextBox and ComboBox controls in the provided list to empty.
        /// </summary>
        /// <param name="controls">List of controls to be cleared.</param>
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

        /// <summary>
        /// Adds a new product, type, user, or order based on the currently visible controls.
        /// </summary>
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
            else if (controlsOrders.Any(x => x.Visible))
            {
                lbOrdersQuerrie.DataSource = null;
                if (controlsOrders.GetRange(8, controlsOrders.Count - 8).Any(x => x.Text == ""))
                {
                    return;
                }

                if (productsInOrder.Count == 0)
                {
                    tbOutputMessage.Text = "No products in order!";
                    ShowOutputMessageFor3Seconds();
                    return;
                }

                string username = tbUserNameOrder.Text;

                if (userBusiness.GetUserByUsername(username) == null)
                {
                    tbOutputMessage.Text = "User does not exist!";
                    ShowOutputMessageFor3Seconds();
                    return;
                }

                DateTime date = DateTime.Parse(tbDate.Text);
                User user = userBusiness.GetUserByUsername(username);
                List<Product> products = new List<Product>();

                Order orderToAdd = new Order()
                {
                    User = user,
                    Date = date,
                    OrderProducts = new List<OrderProduct>()
                };

                foreach (var productInOrder in productsInOrder)
                {
                    string[] tokens = productInOrder.Split(new [] { " X " }, StringSplitOptions.None);
                    string productName = tokens[0];
                    int quantity = int.Parse(tokens[1]);
                    Product product = productBusiness.GetProductByName(productName);

                    orderBusiness.AddProductToOrder(orderToAdd, product, quantity);
                }

                tbOutputMessage.Text = $"New order {date} added with {orderToAdd.OrderProducts.Count} order products";
                UpdateDgvOrders();

                dgvOrders.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["UserName"].Value == orderToAdd.User.UserName)
                    .ToArray()[0]
                    .Selected = true;
            }
            ShowOutputMessageFor3Seconds();
        }

        /// <summary>
        /// Updates an existing product, type, user, or order based on the currently visible controls.
        /// </summary>
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
            else if (controlsOrders.Any(x => x.Visible))
            {
                lbOrdersQuerrie.DataSource = null;
                if (controlsOrders.GetRange(8, controlsOrders.Count - 8).Any(x => x.Text == ""))
                {
                    return;
                }

                string username = tbUserNameOrder.Text;

                if (userBusiness.GetUserByUsername(username) == null)
                {
                    tbOutputMessage.Text = "User does not exist!";
                    ShowOutputMessageFor3Seconds();
                    return;
                }

                DateTime date = DateTime.Parse(tbDate.Text);

                int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells[0].Value);

                Order orderToUpdate = new Order()
                {
                    OrderId = id,
                    User = userBusiness.GetUserByUsername(username),
                    UserId = userBusiness.GetUserByUsername(username).UserId,
                    Date = date,
                    OrderProducts = new List<OrderProduct>()
                };

                Order oldOrder = orderBusiness.GetOrderById(orderToUpdate.OrderId);
                List<OrderProduct> OldOrderProducts = oldOrder.OrderProducts.ToList();
                foreach (var orderProduct in OldOrderProducts)
                {
                    orderProductBusiness.DeleteOrderProduct(orderProduct);
                }

                foreach (var productInOrder in productsInOrder)
                {
                    string[] tokens = productInOrder.Split(new[] { " X " }, StringSplitOptions.None);
                    string productName = tokens[0];
                    int quantity = int.Parse(tokens[1]);
                    Product product = productBusiness.GetProductByName(productName);

                    orderBusiness.AddProductToOrder(orderToUpdate, product, quantity);
                }

                orderBusiness.UpdateOrder(orderToUpdate);

                Order order2 = orderBusiness.GetOrderById(id);
                orderBusiness.DeleteOrder(order2);

                UpdateDgvOrders();
                UpdateListOrderProducts();

                dgvOrders.Rows
                    .OfType<DataGridViewRow>()
                    .Where(x => (string)x.Cells["UserName"].Value == orderToUpdate.User.UserName)
                    .ToArray()[0]
                    .Selected = true;
            }
            ShowOutputMessageFor3Seconds();
        }

        /// <summary>
        /// Removes the selected product, type, user, or order from the system.
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (controlsProducts.Any(x => x.Visible))
            {
                AdminProductViewModel adminProductView = dgvProducts.SelectedRows[0].DataBoundItem as AdminProductViewModel;

                Product productToRemove = productBusiness.GetProductByName(adminProductView.Name);
                tbOutputMessage.Text = productBusiness.DeleteProduct(productToRemove);
                UpdateDgvProducts();
            }
            else if (controlsTypes.Any(x => x.Visible))
            {
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
            else if (controlsOrders.Any(x => x.Visible))
            {
                lbOrdersQuerrie.DataSource = null;
                AdminOrderViewModel orderToRemove = dgvOrders.SelectedRows[0].DataBoundItem as AdminOrderViewModel;
                int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells[0].Value);
                Order order = orderBusiness.GetOrderById(id);
                tbOutputMessage.Text = orderBusiness.DeleteOrder(order);
                UpdateDgvOrders();
                UpdateListOrderProducts();
            }
            ShowOutputMessageFor3Seconds();
        }

        /// <summary>
        /// Displays a temporary output message for 3 seconds using a timer.
        /// </summary>
        private void ShowOutputMessageFor3Seconds()
        {
            tbOutputMessage.Visible = true;

            // Create and configure the timer
            timer = new Timer();
            timer.Interval = 3000; // 3 seconds (3000 milliseconds)
            timer.Tick += Timer_Tick; // Event handler when timer ticks
            timer.Start();
        }

        /// <summary>
        /// Handles the tick event of the timer and hides the output message.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Hide the label after the timer ticks
            tbOutputMessage.Visible = false;

            // Stop the timer
            timer.Stop();
        }

        /// <summary>
        /// Finds all users who have purchased a product with the name entered in the input field.
        /// </summary>
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
            ShowOutputMessageFor3Seconds();
        }

        /// <summary>
        /// Selects a user in the DataGridView when a username is selected from the list.
        /// </summary>
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

        /// <summary>
        /// Enables the product search textbox and disables the user search textbox.
        /// </summary>
        private void rbByProduct_CheckedChanged(object sender, EventArgs e)
        {
            tbByProduct.Enabled = true;
            tbByUser.Enabled = false;
        }

        /// <summary>
        /// Enables the user search textbox and disables the product search textbox.
        /// </summary>
        private void rbByUser_CheckedChanged(object sender, EventArgs e)
        {
            tbByProduct.Enabled = false;
            tbByUser.Enabled = true;
        }

        /// <summary>
        /// Finds and displays orders filtered by either product or user.
        /// </summary>
        private void btnFindOrdersBy_Click(object sender, EventArgs e)
        {
            ordersToDysplay = new List<string>();
            List<Order> orders = new List<Order>();
            string name;
            if (rbByProduct.Checked)
            {
                name = tbByProduct.Text;
                if (productBusiness.GetAllProducts().Any(x => x.Name == name))
                {
                    orders = orderBusiness.GetAllOrdersContainingAGameOfChoise(name);
                }
                else
                {
                    tbOutputMessage.Text = "Invalid product name!";
                    ShowOutputMessageFor3Seconds();
                }             
            }
            else if (rbByUser.Checked)
            {
                name = tbByUser.Text;
                if (userBusiness.GetAllUsers().Any(x => x.UserName != name))
                {
                    orders = orderBusiness.GetAllOrdersByUser(tbByUser.Text);
                }
                else
                {
                    tbOutputMessage.Text = "Invalid username!";
                    ShowOutputMessageFor3Seconds();
                }               
            }

            foreach (var order in orders)
            {
                ordersToDysplay.Add($"OrderId: {order.OrderId} User: {order.User.UserName} Date: {order.Date}");
            }

            UpdateLbOrdersQuerrie();
        }

        /// <summary>
        /// Highlights the selected order in the DataGridView based on the list selection.
        /// </summary>
        private void lbOrdersQuerrie_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbOrdersQuerrie.DataSource = ordersToDysplay;
            if (lbOrdersQuerrie.SelectedItems.Count == 0)
            {
                return;
            }
            string[] tokens = lbOrdersQuerrie.SelectedItems[0].ToString().Split().ToArray();
            int OrderId = int.Parse(tokens[1]);
            dgvOrders.Rows
                .OfType<DataGridViewRow>()
                .Where(x => (int)x.Cells["OrderId"].Value == OrderId)
                .ToArray<DataGridViewRow>()[0]
                .Selected = true;
        }

        /// <summary>
        /// Refreshes the list of queried orders displayed in the ListBox.
        /// </summary>
        private void UpdateLbOrdersQuerrie()
        {
            lbOrdersQuerrie.DataSource = null;
            lbOrdersQuerrie.DataSource = ordersToDysplay;
        }
    }
}
