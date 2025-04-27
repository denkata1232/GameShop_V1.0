namespace GameShop_V1._0.Forms
{
    partial class Cart
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
            this.lbCurrentUser = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbTotalPriceText = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbPriceText = new System.Windows.Forms.Label();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.btnConfirmPurchase = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.lbCurrentUser);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 52);
            this.panel1.TabIndex = 0;
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
            this.dgvProducts.Location = new System.Drawing.Point(12, 75);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(568, 275);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.DataSourceChanged += new System.EventHandler(this.dgvProducts_DataSourceChanged);
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbTotalPrice.Location = new System.Drawing.Point(957, 281);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(76, 29);
            this.lbTotalPrice.TabIndex = 7;
            this.lbTotalPrice.Text = "00.00";
            // 
            // lbTotalPriceText
            // 
            this.lbTotalPriceText.AutoSize = true;
            this.lbTotalPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPriceText.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTotalPriceText.Location = new System.Drawing.Point(808, 280);
            this.lbTotalPriceText.Name = "lbTotalPriceText";
            this.lbTotalPriceText.Size = new System.Drawing.Size(148, 29);
            this.lbTotalPriceText.TabIndex = 6;
            this.lbTotalPriceText.Text = "Total Price:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.Azure;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Swis721 Blk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(609, 94);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(469, 61);
            this.tbName.TabIndex = 9;
            this.tbName.Text = "TITLE";
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Honeydew;
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMinus.Location = new System.Drawing.Point(613, 179);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(28, 29);
            this.btnMinus.TabIndex = 17;
            this.btnMinus.Text = "<";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.Honeydew;
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlus.Location = new System.Drawing.Point(680, 179);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(28, 29);
            this.btnPlus.TabIndex = 14;
            this.btnPlus.Text = ">";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(647, 179);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(27, 29);
            this.tbQuantity.TabIndex = 16;
            this.tbQuantity.Text = "1";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbType.ForeColor = System.Drawing.Color.Chocolate;
            this.lbType.Location = new System.Drawing.Point(606, 75);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(43, 16);
            this.lbType.TabIndex = 15;
            this.lbType.Text = "Type";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPrice.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbPrice.Location = new System.Drawing.Point(659, 151);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(54, 20);
            this.lbPrice.TabIndex = 13;
            this.lbPrice.Text = "00.00";
            // 
            // lbPriceText
            // 
            this.lbPriceText.AutoSize = true;
            this.lbPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPriceText.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbPriceText.Location = new System.Drawing.Point(609, 151);
            this.lbPriceText.Name = "lbPriceText";
            this.lbPriceText.Size = new System.Drawing.Size(54, 20);
            this.lbPriceText.TabIndex = 12;
            this.lbPriceText.Text = "Price:";
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.Azure;
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromCart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(609, 214);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(470, 38);
            this.btnRemoveFromCart.TabIndex = 14;
            this.btnRemoveFromCart.Text = "Remove from cart";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // btnConfirmPurchase
            // 
            this.btnConfirmPurchase.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConfirmPurchase.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirmPurchase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirmPurchase.Location = new System.Drawing.Point(796, 312);
            this.btnConfirmPurchase.Name = "btnConfirmPurchase";
            this.btnConfirmPurchase.Size = new System.Drawing.Size(287, 38);
            this.btnConfirmPurchase.TabIndex = 18;
            this.btnConfirmPurchase.Text = "Confirm Purchase";
            this.btnConfirmPurchase.UseVisualStyleBackColor = false;
            this.btnConfirmPurchase.Click += new System.EventHandler(this.btnConfirmPurchase_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1098, 362);
            this.Controls.Add(this.btnConfirmPurchase);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbPriceText);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.lbTotalPriceText);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panel1);
            this.Name = "Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox lbCurrentUser;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbTotalPriceText;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbPriceText;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnConfirmPurchase;
    }
}