namespace InventoryManagementSystem
{
    partial class AdminAddProducts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddProducts_dataGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.AddProducts_prodID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddProducts_prodName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddProducts_clearBtn = new System.Windows.Forms.Button();
            this.AddProducts_removeBtn = new System.Windows.Forms.Button();
            this.AddProducts_updatetBtn = new System.Windows.Forms.Button();
            this.AddProducts_addBtn = new System.Windows.Forms.Button();
            this.AddProducts_importBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddProducts_status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddProducts_supplier = new System.Windows.Forms.ComboBox();
            this.AddProducts_stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddProducts_price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddProducts_imageView = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddProducts_dataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddProducts_imageView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AddProducts_dataGrid);
            this.panel1.Location = new System.Drawing.Point(15, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 403);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Products";
            // 
            // AddProducts_dataGrid
            // 
            this.AddProducts_dataGrid.AllowUserToAddRows = false;
            this.AddProducts_dataGrid.AllowUserToDeleteRows = false;
            this.AddProducts_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AddProducts_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddProducts_dataGrid.Location = new System.Drawing.Point(16, 41);
            this.AddProducts_dataGrid.Name = "AddProducts_dataGrid";
            this.AddProducts_dataGrid.ReadOnly = true;
            this.AddProducts_dataGrid.RowHeadersVisible = false;
            this.AddProducts_dataGrid.Size = new System.Drawing.Size(1047, 348);
            this.AddProducts_dataGrid.TabIndex = 0;
            this.AddProducts_dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddProducts_dataGrid_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product ID:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AddProducts_prodID
            // 
            this.AddProducts_prodID.Location = new System.Drawing.Point(113, 33);
            this.AddProducts_prodID.Name = "AddProducts_prodID";
            this.AddProducts_prodID.Size = new System.Drawing.Size(155, 20);
            this.AddProducts_prodID.TabIndex = 1;
            this.AddProducts_prodID.TextChanged += new System.EventHandler(this.AddProducts_prodID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name:";
            // 
            // AddProducts_prodName
            // 
            this.AddProducts_prodName.Location = new System.Drawing.Point(113, 72);
            this.AddProducts_prodName.Name = "AddProducts_prodName";
            this.AddProducts_prodName.Size = new System.Drawing.Size(155, 20);
            this.AddProducts_prodName.TabIndex = 3;
            this.AddProducts_prodName.TextChanged += new System.EventHandler(this.AddProducts_prodName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Supplier Name:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AddProducts_clearBtn);
            this.panel2.Controls.Add(this.AddProducts_removeBtn);
            this.panel2.Controls.Add(this.AddProducts_updatetBtn);
            this.panel2.Controls.Add(this.AddProducts_addBtn);
            this.panel2.Controls.Add(this.AddProducts_importBtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.AddProducts_status);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.AddProducts_supplier);
            this.panel2.Controls.Add(this.AddProducts_stock);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.AddProducts_price);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.AddProducts_prodName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.AddProducts_prodID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(15, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 299);
            this.panel2.TabIndex = 1;
            // 
            // AddProducts_clearBtn
            // 
            this.AddProducts_clearBtn.BackColor = System.Drawing.Color.Black;
            this.AddProducts_clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProducts_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AddProducts_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddProducts_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProducts_clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProducts_clearBtn.ForeColor = System.Drawing.Color.White;
            this.AddProducts_clearBtn.Location = new System.Drawing.Point(563, 188);
            this.AddProducts_clearBtn.Name = "AddProducts_clearBtn";
            this.AddProducts_clearBtn.Size = new System.Drawing.Size(131, 31);
            this.AddProducts_clearBtn.TabIndex = 20;
            this.AddProducts_clearBtn.Text = "Clear";
            this.AddProducts_clearBtn.UseVisualStyleBackColor = false;
            this.AddProducts_clearBtn.Click += new System.EventHandler(this.AddProducts_clearBtn_Click);
            // 
            // AddProducts_removeBtn
            // 
            this.AddProducts_removeBtn.BackColor = System.Drawing.Color.Black;
            this.AddProducts_removeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProducts_removeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AddProducts_removeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddProducts_removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProducts_removeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProducts_removeBtn.ForeColor = System.Drawing.Color.White;
            this.AddProducts_removeBtn.Location = new System.Drawing.Point(403, 188);
            this.AddProducts_removeBtn.Name = "AddProducts_removeBtn";
            this.AddProducts_removeBtn.Size = new System.Drawing.Size(131, 31);
            this.AddProducts_removeBtn.TabIndex = 19;
            this.AddProducts_removeBtn.Text = "Remove";
            this.AddProducts_removeBtn.UseVisualStyleBackColor = false;
            this.AddProducts_removeBtn.Click += new System.EventHandler(this.AddProducts_removeBtn_Click);
            // 
            // AddProducts_updatetBtn
            // 
            this.AddProducts_updatetBtn.BackColor = System.Drawing.Color.Black;
            this.AddProducts_updatetBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProducts_updatetBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AddProducts_updatetBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddProducts_updatetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProducts_updatetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProducts_updatetBtn.ForeColor = System.Drawing.Color.White;
            this.AddProducts_updatetBtn.Location = new System.Drawing.Point(244, 188);
            this.AddProducts_updatetBtn.Name = "AddProducts_updatetBtn";
            this.AddProducts_updatetBtn.Size = new System.Drawing.Size(131, 31);
            this.AddProducts_updatetBtn.TabIndex = 18;
            this.AddProducts_updatetBtn.Text = "Update";
            this.AddProducts_updatetBtn.UseVisualStyleBackColor = false;
            this.AddProducts_updatetBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddProducts_addBtn
            // 
            this.AddProducts_addBtn.BackColor = System.Drawing.Color.Black;
            this.AddProducts_addBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProducts_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AddProducts_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddProducts_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProducts_addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProducts_addBtn.ForeColor = System.Drawing.Color.White;
            this.AddProducts_addBtn.Location = new System.Drawing.Point(84, 188);
            this.AddProducts_addBtn.Name = "AddProducts_addBtn";
            this.AddProducts_addBtn.Size = new System.Drawing.Size(131, 31);
            this.AddProducts_addBtn.TabIndex = 17;
            this.AddProducts_addBtn.Text = "Add";
            this.AddProducts_addBtn.UseVisualStyleBackColor = false;
            this.AddProducts_addBtn.Click += new System.EventHandler(this.AddProducts_addBtn_Click);
            // 
            // AddProducts_importBtn
            // 
            this.AddProducts_importBtn.BackColor = System.Drawing.Color.Black;
            this.AddProducts_importBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProducts_importBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AddProducts_importBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddProducts_importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProducts_importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProducts_importBtn.ForeColor = System.Drawing.Color.White;
            this.AddProducts_importBtn.Location = new System.Drawing.Point(904, 159);
            this.AddProducts_importBtn.Name = "AddProducts_importBtn";
            this.AddProducts_importBtn.Size = new System.Drawing.Size(131, 31);
            this.AddProducts_importBtn.TabIndex = 16;
            this.AddProducts_importBtn.Text = "Import";
            this.AddProducts_importBtn.UseVisualStyleBackColor = false;
            this.AddProducts_importBtn.Click += new System.EventHandler(this.AddProducts_importBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.AddProducts_imageView);
            this.panel3.Location = new System.Drawing.Point(904, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(131, 125);
            this.panel3.TabIndex = 15;
            // 
            // AddProducts_status
            // 
            this.AddProducts_status.FormattingEnabled = true;
            this.AddProducts_status.Items.AddRange(new object[] {
            "Available",
            "Not Available"});
            this.AddProducts_status.Location = new System.Drawing.Point(442, 111);
            this.AddProducts_status.Name = "AddProducts_status";
            this.AddProducts_status.Size = new System.Drawing.Size(155, 21);
            this.AddProducts_status.TabIndex = 14;
            this.AddProducts_status.SelectedIndexChanged += new System.EventHandler(this.AddProducts_status_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Status:";
            // 
            // AddProducts_supplier
            // 
            this.AddProducts_supplier.FormattingEnabled = true;
            this.AddProducts_supplier.Location = new System.Drawing.Point(113, 111);
            this.AddProducts_supplier.Name = "AddProducts_supplier";
            this.AddProducts_supplier.Size = new System.Drawing.Size(155, 21);
            this.AddProducts_supplier.TabIndex = 12;
            this.AddProducts_supplier.SelectedIndexChanged += new System.EventHandler(this.AddProducts_supplier_SelectedIndexChanged);
            // 
            // AddProducts_stock
            // 
            this.AddProducts_stock.Location = new System.Drawing.Point(442, 73);
            this.AddProducts_stock.Name = "AddProducts_stock";
            this.AddProducts_stock.Size = new System.Drawing.Size(155, 20);
            this.AddProducts_stock.TabIndex = 9;
            this.AddProducts_stock.TextChanged += new System.EventHandler(this.AddProducts_stock_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stock:";
            // 
            // AddProducts_price
            // 
            this.AddProducts_price.Location = new System.Drawing.Point(442, 34);
            this.AddProducts_price.Name = "AddProducts_price";
            this.AddProducts_price.Size = new System.Drawing.Size(155, 20);
            this.AddProducts_price.TabIndex = 7;
            this.AddProducts_price.TextChanged += new System.EventHandler(this.AddProducts_price_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(385, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Price $:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // AddProducts_imageView
            // 
            this.AddProducts_imageView.Location = new System.Drawing.Point(0, 0);
            this.AddProducts_imageView.Name = "AddProducts_imageView";
            this.AddProducts_imageView.Size = new System.Drawing.Size(128, 122);
            this.AddProducts_imageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddProducts_imageView.TabIndex = 0;
            this.AddProducts_imageView.TabStop = false;
            // 
            // AdminAddProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminAddProducts";
            this.Size = new System.Drawing.Size(1116, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddProducts_dataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddProducts_imageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView AddProducts_dataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddProducts_prodID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AddProducts_prodName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox AddProducts_stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AddProducts_price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox AddProducts_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox AddProducts_supplier;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button AddProducts_importBtn;
        private System.Windows.Forms.PictureBox AddProducts_imageView;
        private System.Windows.Forms.Button AddProducts_clearBtn;
        private System.Windows.Forms.Button AddProducts_removeBtn;
        private System.Windows.Forms.Button AddProducts_updatetBtn;
        private System.Windows.Forms.Button AddProducts_addBtn;
    }
}
