namespace GameShop_V1._0.Forms
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTypeProducts = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.lbAdminText = new System.Windows.Forms.Label();
            this.lbCurrentUser = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbCompany = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tbOutputMessage = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvTypeProduct = new System.Windows.Forms.DataGridView();
            this.lbTypeProductName = new System.Windows.Forms.Label();
            this.tbTypeProductName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.chbIsAdmin = new System.Windows.Forms.CheckBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lbUserWithProducts = new System.Windows.Forms.ListBox();
            this.lbAllUsersWithAgame = new System.Windows.Forms.Label();
            this.tbAllUsersWithAgame = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lbUserNameOrder = new System.Windows.Forms.Label();
            this.tbUserNameOrder = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbOrderProducts = new System.Windows.Forms.ListBox();
            this.btnRemoveFromOrder = new System.Windows.Forms.Button();
            this.cbProductToAddInOrder = new System.Windows.Forms.ComboBox();
            this.btnAddProductToOrder = new System.Windows.Forms.Button();
            this.lblProductsOrder = new System.Windows.Forms.Label();
            this.tbQuantityOrder = new System.Windows.Forms.TextBox();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.lbOrdersByDate = new System.Windows.Forms.ListBox();
            this.btnFindOrdersByDate = new System.Windows.Forms.Button();
            this.rbByDate = new System.Windows.Forms.RadioButton();
            this.rbByDateRange = new System.Windows.Forms.RadioButton();
            this.tbDateToFind = new System.Windows.Forms.TextBox();
            this.tbStartDateToFind = new System.Windows.Forms.TextBox();
            this.tbEndDateToFind = new System.Windows.Forms.TextBox();
            this.lbFindOrder = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.btnTypeProducts);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnOrders);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Controls.Add(this.lbAdminText);
            this.panel1.Controls.Add(this.lbCurrentUser);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 52);
            this.panel1.TabIndex = 1;
            // 
            // btnTypeProducts
            // 
            this.btnTypeProducts.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnTypeProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeProducts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTypeProducts.Location = new System.Drawing.Point(586, 7);
            this.btnTypeProducts.Name = "btnTypeProducts";
            this.btnTypeProducts.Size = new System.Drawing.Size(82, 38);
            this.btnTypeProducts.TabIndex = 18;
            this.btnTypeProducts.Text = "Types";
            this.btnTypeProducts.UseVisualStyleBackColor = false;
            this.btnTypeProducts.Click += new System.EventHandler(this.btnTypeProducts_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUsers.Location = new System.Drawing.Point(674, 7);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(82, 38);
            this.btnUsers.TabIndex = 17;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.tbUsers_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOrders.Location = new System.Drawing.Point(762, 7);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(82, 38);
            this.btnOrders.TabIndex = 16;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProducts.Location = new System.Drawing.Point(498, 7);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(82, 38);
            this.btnProducts.TabIndex = 15;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // lbAdminText
            // 
            this.lbAdminText.AutoSize = true;
            this.lbAdminText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAdminText.ForeColor = System.Drawing.Color.DarkRed;
            this.lbAdminText.Location = new System.Drawing.Point(265, 12);
            this.lbAdminText.Name = "lbAdminText";
            this.lbAdminText.Size = new System.Drawing.Size(192, 31);
            this.lbAdminText.TabIndex = 14;
            this.lbAdminText.Text = "Admin control";
            // 
            // lbCurrentUser
            // 
            this.lbCurrentUser.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCurrentUser.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lbCurrentUser.Location = new System.Drawing.Point(699, 15);
            this.lbCurrentUser.Multiline = true;
            this.lbCurrentUser.Name = "lbCurrentUser";
            this.lbCurrentUser.ReadOnly = true;
            this.lbCurrentUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbCurrentUser.Size = new System.Drawing.Size(257, 28);
            this.lbCurrentUser.TabIndex = 13;
            this.lbCurrentUser.Text = "username";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogOut.Location = new System.Drawing.Point(962, 7);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(124, 38);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(212, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 39);
            this.label3.TabIndex = 7;
            this.label3.Text = "🎮";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(120, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shop";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Game";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 78);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(568, 520);
            this.dgvProducts.TabIndex = 2;
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbProductName.Location = new System.Drawing.Point(639, 78);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(435, 24);
            this.tbProductName.TabIndex = 3;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(639, 108);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(174, 21);
            this.cbType.TabIndex = 4;
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCompany.Location = new System.Drawing.Point(639, 135);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(231, 24);
            this.tbCompany.TabIndex = 5;
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDescription.Location = new System.Drawing.Point(639, 165);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(435, 94);
            this.tbDescription.TabIndex = 6;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPrice.Location = new System.Drawing.Point(639, 265);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(102, 24);
            this.tbPrice.TabIndex = 7;
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProductName.Location = new System.Drawing.Point(586, 81);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(52, 18);
            this.lbProductName.TabIndex = 8;
            this.lbProductName.Text = "Name:";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbType.Location = new System.Drawing.Point(586, 111);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(44, 18);
            this.lbType.TabIndex = 9;
            this.lbType.Text = "Type:";
            // 
            // lbCompany
            // 
            this.lbCompany.AutoSize = true;
            this.lbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCompany.Location = new System.Drawing.Point(586, 141);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(53, 18);
            this.lbCompany.TabIndex = 10;
            this.lbCompany.Text = "Comp:";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDescription.Location = new System.Drawing.Point(586, 168);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(47, 18);
            this.lbDescription.TabIndex = 11;
            this.lbDescription.Text = "Desc:";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPrice.Location = new System.Drawing.Point(583, 268);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(46, 18);
            this.lbPrice.TabIndex = 12;
            this.lbPrice.Text = "Price:";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbQuantity.Location = new System.Drawing.Point(583, 298);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(52, 18);
            this.lbQuantity.TabIndex = 14;
            this.lbQuantity.Text = "Quant:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuantity.Location = new System.Drawing.Point(639, 295);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(102, 24);
            this.tbQuantity.TabIndex = 13;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(775, 339);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 38);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(905, 339);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(124, 38);
            this.btnRemove.TabIndex = 20;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tbOutputMessage
            // 
            this.tbOutputMessage.BackColor = System.Drawing.Color.Azure;
            this.tbOutputMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbOutputMessage.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOutputMessage.ForeColor = System.Drawing.Color.Red;
            this.tbOutputMessage.Location = new System.Drawing.Point(586, 383);
            this.tbOutputMessage.Name = "tbOutputMessage";
            this.tbOutputMessage.ReadOnly = true;
            this.tbOutputMessage.Size = new System.Drawing.Size(483, 19);
            this.tbOutputMessage.TabIndex = 21;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(645, 339);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 38);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Location = new System.Drawing.Point(586, 339);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(53, 38);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvTypeProduct
            // 
            this.dgvTypeProduct.AllowUserToOrderColumns = true;
            this.dgvTypeProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeProduct.Location = new System.Drawing.Point(12, 78);
            this.dgvTypeProduct.MultiSelect = false;
            this.dgvTypeProduct.Name = "dgvTypeProduct";
            this.dgvTypeProduct.ReadOnly = true;
            this.dgvTypeProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypeProduct.Size = new System.Drawing.Size(568, 520);
            this.dgvTypeProduct.TabIndex = 24;
            this.dgvTypeProduct.Visible = false;
            // 
            // lbTypeProductName
            // 
            this.lbTypeProductName.AutoSize = true;
            this.lbTypeProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTypeProductName.Location = new System.Drawing.Point(586, 81);
            this.lbTypeProductName.Name = "lbTypeProductName";
            this.lbTypeProductName.Size = new System.Drawing.Size(52, 18);
            this.lbTypeProductName.TabIndex = 26;
            this.lbTypeProductName.Text = "Name:";
            this.lbTypeProductName.Visible = false;
            // 
            // tbTypeProductName
            // 
            this.tbTypeProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTypeProductName.Location = new System.Drawing.Point(639, 78);
            this.tbTypeProductName.Name = "tbTypeProductName";
            this.tbTypeProductName.Size = new System.Drawing.Size(435, 24);
            this.tbTypeProductName.TabIndex = 25;
            this.tbTypeProductName.Visible = false;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserName.Location = new System.Drawing.Point(587, 81);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(81, 18);
            this.lbUserName.TabIndex = 28;
            this.lbUserName.Text = "Username:";
            this.lbUserName.Visible = false;
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserName.Location = new System.Drawing.Point(674, 78);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(401, 24);
            this.tbUserName.TabIndex = 27;
            this.tbUserName.Visible = false;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPassword.Location = new System.Drawing.Point(589, 111);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(79, 18);
            this.lbPassword.TabIndex = 30;
            this.lbPassword.Text = "Password:";
            this.lbPassword.Visible = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(674, 108);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(401, 24);
            this.tbPassword.TabIndex = 29;
            this.tbPassword.Visible = false;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmail.Location = new System.Drawing.Point(590, 138);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(49, 18);
            this.lbEmail.TabIndex = 32;
            this.lbEmail.Text = "Email:";
            this.lbEmail.Visible = false;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmail.Location = new System.Drawing.Point(674, 138);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(401, 24);
            this.tbEmail.TabIndex = 31;
            this.tbEmail.Visible = false;
            // 
            // chbIsAdmin
            // 
            this.chbIsAdmin.AutoSize = true;
            this.chbIsAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsAdmin.Location = new System.Drawing.Point(589, 168);
            this.chbIsAdmin.Name = "chbIsAdmin";
            this.chbIsAdmin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbIsAdmin.Size = new System.Drawing.Size(79, 22);
            this.chbIsAdmin.TabIndex = 34;
            this.chbIsAdmin.Text = "IsAdmin";
            this.chbIsAdmin.UseVisualStyleBackColor = true;
            this.chbIsAdmin.Visible = false;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 78);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(568, 520);
            this.dgvUsers.TabIndex = 35;
            this.dgvUsers.Visible = false;
            // 
            // lbUserWithProducts
            // 
            this.lbUserWithProducts.FormattingEnabled = true;
            this.lbUserWithProducts.Location = new System.Drawing.Point(593, 464);
            this.lbUserWithProducts.Name = "lbUserWithProducts";
            this.lbUserWithProducts.Size = new System.Drawing.Size(481, 134);
            this.lbUserWithProducts.TabIndex = 36;
            this.lbUserWithProducts.Visible = false;
            this.lbUserWithProducts.SelectedIndexChanged += new System.EventHandler(this.lbUserWithProducts_SelectedIndexChanged);
            // 
            // lbAllUsersWithAgame
            // 
            this.lbAllUsersWithAgame.AutoSize = true;
            this.lbAllUsersWithAgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAllUsersWithAgame.Location = new System.Drawing.Point(589, 415);
            this.lbAllUsersWithAgame.Name = "lbAllUsersWithAgame";
            this.lbAllUsersWithAgame.Size = new System.Drawing.Size(151, 18);
            this.lbAllUsersWithAgame.TabIndex = 37;
            this.lbAllUsersWithAgame.Text = "All users with a game:";
            this.lbAllUsersWithAgame.Visible = false;
            // 
            // tbAllUsersWithAgame
            // 
            this.tbAllUsersWithAgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAllUsersWithAgame.Location = new System.Drawing.Point(743, 412);
            this.tbAllUsersWithAgame.Name = "tbAllUsersWithAgame";
            this.tbAllUsersWithAgame.Size = new System.Drawing.Size(331, 24);
            this.tbAllUsersWithAgame.TabIndex = 38;
            this.tbAllUsersWithAgame.Text = "Name of a game";
            this.tbAllUsersWithAgame.Visible = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFind.Location = new System.Drawing.Point(592, 436);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(482, 27);
            this.btnFind.TabIndex = 39;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lbUserNameOrder
            // 
            this.lbUserNameOrder.AutoSize = true;
            this.lbUserNameOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserNameOrder.Location = new System.Drawing.Point(587, 81);
            this.lbUserNameOrder.Name = "lbUserNameOrder";
            this.lbUserNameOrder.Size = new System.Drawing.Size(81, 18);
            this.lbUserNameOrder.TabIndex = 40;
            this.lbUserNameOrder.Text = "Username:";
            this.lbUserNameOrder.Visible = false;
            // 
            // tbUserNameOrder
            // 
            this.tbUserNameOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserNameOrder.Location = new System.Drawing.Point(674, 78);
            this.tbUserNameOrder.Name = "tbUserNameOrder";
            this.tbUserNameOrder.Size = new System.Drawing.Size(401, 24);
            this.tbUserNameOrder.TabIndex = 41;
            this.tbUserNameOrder.Visible = false;
            // 
            // tbDate
            // 
            this.tbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDate.Location = new System.Drawing.Point(674, 108);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(401, 24);
            this.tbDate.TabIndex = 43;
            this.tbDate.Visible = false;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDate.Location = new System.Drawing.Point(587, 111);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(43, 18);
            this.lbDate.TabIndex = 42;
            this.lbDate.Text = "Date:";
            this.lbDate.Visible = false;
            // 
            // lbOrderProducts
            // 
            this.lbOrderProducts.FormattingEnabled = true;
            this.lbOrderProducts.Location = new System.Drawing.Point(590, 141);
            this.lbOrderProducts.Name = "lbOrderProducts";
            this.lbOrderProducts.Size = new System.Drawing.Size(485, 95);
            this.lbOrderProducts.TabIndex = 44;
            this.lbOrderProducts.Visible = false;
            // 
            // btnRemoveFromOrder
            // 
            this.btnRemoveFromOrder.Location = new System.Drawing.Point(991, 239);
            this.btnRemoveFromOrder.Name = "btnRemoveFromOrder";
            this.btnRemoveFromOrder.Size = new System.Drawing.Size(84, 29);
            this.btnRemoveFromOrder.TabIndex = 45;
            this.btnRemoveFromOrder.Text = "Remove";
            this.btnRemoveFromOrder.UseVisualStyleBackColor = true;
            this.btnRemoveFromOrder.Visible = false;
            // 
            // cbProductToAddInOrder
            // 
            this.cbProductToAddInOrder.FormattingEnabled = true;
            this.cbProductToAddInOrder.Location = new System.Drawing.Point(674, 247);
            this.cbProductToAddInOrder.Name = "cbProductToAddInOrder";
            this.cbProductToAddInOrder.Size = new System.Drawing.Size(186, 21);
            this.cbProductToAddInOrder.TabIndex = 46;
            this.cbProductToAddInOrder.Visible = false;
            // 
            // btnAddProductToOrder
            // 
            this.btnAddProductToOrder.Location = new System.Drawing.Point(901, 239);
            this.btnAddProductToOrder.Name = "btnAddProductToOrder";
            this.btnAddProductToOrder.Size = new System.Drawing.Size(84, 29);
            this.btnAddProductToOrder.TabIndex = 47;
            this.btnAddProductToOrder.Text = "Add";
            this.btnAddProductToOrder.UseVisualStyleBackColor = true;
            this.btnAddProductToOrder.Visible = false;
            // 
            // lblProductsOrder
            // 
            this.lblProductsOrder.AutoSize = true;
            this.lblProductsOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductsOrder.Location = new System.Drawing.Point(587, 250);
            this.lblProductsOrder.Name = "lblProductsOrder";
            this.lblProductsOrder.Size = new System.Drawing.Size(72, 18);
            this.lblProductsOrder.TabIndex = 48;
            this.lblProductsOrder.Text = "Products:";
            this.lblProductsOrder.Visible = false;
            // 
            // tbQuantityOrder
            // 
            this.tbQuantityOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuantityOrder.Location = new System.Drawing.Point(866, 244);
            this.tbQuantityOrder.Name = "tbQuantityOrder";
            this.tbQuantityOrder.Size = new System.Drawing.Size(29, 24);
            this.tbQuantityOrder.TabIndex = 49;
            this.tbQuantityOrder.Text = "1";
            this.tbQuantityOrder.Visible = false;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTotalPrice.Location = new System.Drawing.Point(587, 286);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(81, 18);
            this.lbTotalPrice.TabIndex = 50;
            this.lbTotalPrice.Text = "Total price:";
            this.lbTotalPrice.Visible = false;
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTotalPrice.Location = new System.Drawing.Point(674, 283);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            this.tbTotalPrice.Size = new System.Drawing.Size(87, 24);
            this.tbTotalPrice.TabIndex = 51;
            this.tbTotalPrice.Visible = false;
            // 
            // lbOrdersByDate
            // 
            this.lbOrdersByDate.FormattingEnabled = true;
            this.lbOrdersByDate.Location = new System.Drawing.Point(590, 464);
            this.lbOrdersByDate.Name = "lbOrdersByDate";
            this.lbOrdersByDate.Size = new System.Drawing.Size(485, 134);
            this.lbOrdersByDate.TabIndex = 52;
            this.lbOrdersByDate.Visible = false;
            // 
            // btnFindOrdersByDate
            // 
            this.btnFindOrdersByDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFindOrdersByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindOrdersByDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindOrdersByDate.Location = new System.Drawing.Point(590, 436);
            this.btnFindOrdersByDate.Name = "btnFindOrdersByDate";
            this.btnFindOrdersByDate.Size = new System.Drawing.Size(485, 27);
            this.btnFindOrdersByDate.TabIndex = 53;
            this.btnFindOrdersByDate.Text = "Find";
            this.btnFindOrdersByDate.UseVisualStyleBackColor = false;
            this.btnFindOrdersByDate.Visible = false;
            // 
            // rbByDate
            // 
            this.rbByDate.AutoSize = true;
            this.rbByDate.Checked = true;
            this.rbByDate.Location = new System.Drawing.Point(593, 414);
            this.rbByDate.Name = "rbByDate";
            this.rbByDate.Size = new System.Drawing.Size(61, 17);
            this.rbByDate.TabIndex = 54;
            this.rbByDate.TabStop = true;
            this.rbByDate.Text = "By date";
            this.rbByDate.UseVisualStyleBackColor = true;
            this.rbByDate.Visible = false;
            // 
            // rbByDateRange
            // 
            this.rbByDateRange.AutoSize = true;
            this.rbByDateRange.Location = new System.Drawing.Point(789, 415);
            this.rbByDateRange.Name = "rbByDateRange";
            this.rbByDateRange.Size = new System.Drawing.Size(91, 17);
            this.rbByDateRange.TabIndex = 55;
            this.rbByDateRange.Text = "By date range";
            this.rbByDateRange.UseVisualStyleBackColor = true;
            this.rbByDateRange.Visible = false;
            // 
            // tbDateToFind
            // 
            this.tbDateToFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDateToFind.Location = new System.Drawing.Point(650, 413);
            this.tbDateToFind.Name = "tbDateToFind";
            this.tbDateToFind.Size = new System.Drawing.Size(91, 20);
            this.tbDateToFind.TabIndex = 56;
            this.tbDateToFind.Text = "date - dd.mm.yyyy";
            this.tbDateToFind.Visible = false;
            // 
            // tbStartDateToFind
            // 
            this.tbStartDateToFind.Enabled = false;
            this.tbStartDateToFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStartDateToFind.Location = new System.Drawing.Point(886, 413);
            this.tbStartDateToFind.Name = "tbStartDateToFind";
            this.tbStartDateToFind.Size = new System.Drawing.Size(91, 20);
            this.tbStartDateToFind.TabIndex = 57;
            this.tbStartDateToFind.Text = "start date";
            this.tbStartDateToFind.Visible = false;
            // 
            // tbEndDateToFind
            // 
            this.tbEndDateToFind.Enabled = false;
            this.tbEndDateToFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEndDateToFind.Location = new System.Drawing.Point(983, 413);
            this.tbEndDateToFind.Name = "tbEndDateToFind";
            this.tbEndDateToFind.Size = new System.Drawing.Size(91, 20);
            this.tbEndDateToFind.TabIndex = 58;
            this.tbEndDateToFind.Text = "end date ";
            this.tbEndDateToFind.Visible = false;
            // 
            // lbFindOrder
            // 
            this.lbFindOrder.AutoSize = true;
            this.lbFindOrder.Location = new System.Drawing.Point(587, 402);
            this.lbFindOrder.Name = "lbFindOrder";
            this.lbFindOrder.Size = new System.Drawing.Size(57, 13);
            this.lbFindOrder.TabIndex = 59;
            this.lbFindOrder.Text = "Find order:";
            this.lbFindOrder.Visible = false;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 78);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(568, 520);
            this.dgvOrders.TabIndex = 60;
            this.dgvOrders.Visible = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1098, 626);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lbFindOrder);
            this.Controls.Add(this.tbEndDateToFind);
            this.Controls.Add(this.tbStartDateToFind);
            this.Controls.Add(this.tbDateToFind);
            this.Controls.Add(this.rbByDateRange);
            this.Controls.Add(this.rbByDate);
            this.Controls.Add(this.btnFindOrdersByDate);
            this.Controls.Add(this.lbOrdersByDate);
            this.Controls.Add(this.tbTotalPrice);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.tbQuantityOrder);
            this.Controls.Add(this.lblProductsOrder);
            this.Controls.Add(this.btnAddProductToOrder);
            this.Controls.Add(this.cbProductToAddInOrder);
            this.Controls.Add(this.btnRemoveFromOrder);
            this.Controls.Add(this.lbOrderProducts);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.tbUserNameOrder);
            this.Controls.Add(this.lbUserNameOrder);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbAllUsersWithAgame);
            this.Controls.Add(this.lbAllUsersWithAgame);
            this.Controls.Add(this.lbUserWithProducts);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.chbIsAdmin);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbTypeProductName);
            this.Controls.Add(this.tbTypeProductName);
            this.Controls.Add(this.dgvTypeProduct);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbOutputMessage);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbCompany);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panel1);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox lbCurrentUser;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lbAdminText;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbCompany;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnTypeProducts;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox tbOutputMessage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvTypeProduct;
        private System.Windows.Forms.Label lbTypeProductName;
        private System.Windows.Forms.TextBox tbTypeProductName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.CheckBox chbIsAdmin;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ListBox lbUserWithProducts;
        private System.Windows.Forms.Label lbAllUsersWithAgame;
        private System.Windows.Forms.TextBox tbAllUsersWithAgame;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lbUserNameOrder;
        private System.Windows.Forms.TextBox tbUserNameOrder;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.ListBox lbOrderProducts;
        private System.Windows.Forms.Button btnRemoveFromOrder;
        private System.Windows.Forms.ComboBox cbProductToAddInOrder;
        private System.Windows.Forms.Button btnAddProductToOrder;
        private System.Windows.Forms.Label lblProductsOrder;
        private System.Windows.Forms.TextBox tbQuantityOrder;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.ListBox lbOrdersByDate;
        private System.Windows.Forms.Button btnFindOrdersByDate;
        private System.Windows.Forms.RadioButton rbByDate;
        private System.Windows.Forms.RadioButton rbByDateRange;
        private System.Windows.Forms.TextBox tbDateToFind;
        private System.Windows.Forms.TextBox tbStartDateToFind;
        private System.Windows.Forms.TextBox tbEndDateToFind;
        private System.Windows.Forms.Label lbFindOrder;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}