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
            this.lbCurrentUser = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lbAdminText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.dgvProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(568, 520);
            this.dgvProducts.TabIndex = 2;
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
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1098, 626);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panel1);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

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
    }
}