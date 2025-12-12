namespace InventoryManagementSystem
{
    partial class CashierOrder
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.cashierOrder_change = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cashierOrder_ammount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cashierOrder_totalPrice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5cashierOrder_ProdName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cashierOrder_qty = new System.Windows.Forms.NumericUpDown();
            this.cashierOrder_clearBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cashierOrder_removeBtn = new System.Windows.Forms.Button();
            this.cashierOrder_addBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cashierOrder_searchBox = new System.Windows.Forms.TextBox();
            this.cashierOrder_price = new System.Windows.Forms.Label();
            this.cashierOrder_productID = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cashierOrder_payOrders = new System.Windows.Forms.Button();
            this.cashierOrder_discountBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrder_qty)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 364);
            this.panel1.TabIndex = 0;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(11, 41);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.Size = new System.Drawing.Size(596, 310);
            this.DataGridView1.TabIndex = 1;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Products";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cashierOrder_discountBtn);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.cashierOrder_payOrders);
            this.panel3.Controls.Add(this.cashierOrder_change);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cashierOrder_ammount);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cashierOrder_totalPrice);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(641, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 709);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(436, 310);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(6, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 32);
            this.label14.TabIndex = 1;
            this.label14.Text = "All Order\'s";
            // 
            // cashierOrder_change
            // 
            this.cashierOrder_change.AutoSize = true;
            this.cashierOrder_change.Font = new System.Drawing.Font("Arial", 15.75F);
            this.cashierOrder_change.Location = new System.Drawing.Point(182, 494);
            this.cashierOrder_change.Name = "cashierOrder_change";
            this.cashierOrder_change.Size = new System.Drawing.Size(52, 24);
            this.cashierOrder_change.TabIndex = 27;
            this.cashierOrder_change.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label13.Location = new System.Drawing.Point(68, 494);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 24);
            this.label13.TabIndex = 26;
            this.label13.Text = "Change:";
            // 
            // cashierOrder_ammount
            // 
            this.cashierOrder_ammount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cashierOrder_ammount.Location = new System.Drawing.Point(186, 433);
            this.cashierOrder_ammount.Name = "cashierOrder_ammount";
            this.cashierOrder_ammount.Size = new System.Drawing.Size(176, 26);
            this.cashierOrder_ammount.TabIndex = 25;
            this.cashierOrder_ammount.TextChanged += new System.EventHandler(this.cashierOrder_ammount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label12.Location = new System.Drawing.Point(63, 435);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Amount ($):";
            // 
            // cashierOrder_totalPrice
            // 
            this.cashierOrder_totalPrice.AutoSize = true;
            this.cashierOrder_totalPrice.Font = new System.Drawing.Font("Arial", 15.75F);
            this.cashierOrder_totalPrice.Location = new System.Drawing.Point(221, 379);
            this.cashierOrder_totalPrice.Name = "cashierOrder_totalPrice";
            this.cashierOrder_totalPrice.Size = new System.Drawing.Size(52, 24);
            this.cashierOrder_totalPrice.TabIndex = 23;
            this.cashierOrder_totalPrice.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label10.Location = new System.Drawing.Point(68, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Total Price ($):";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(59, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(43, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "PRODUCT PRICE :";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(356, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "PRODUCT QUANTITY";
            // 
            // label5cashierOrder_ProdName
            // 
            this.label5cashierOrder_ProdName.Location = new System.Drawing.Point(59, 43);
            this.label5cashierOrder_ProdName.Name = "label5cashierOrder_ProdName";
            this.label5cashierOrder_ProdName.Size = new System.Drawing.Size(100, 23);
            this.label5cashierOrder_ProdName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 8;
            // 
            // cashierOrder_qty
            // 
            this.cashierOrder_qty.Location = new System.Drawing.Point(361, 110);
            this.cashierOrder_qty.Name = "cashierOrder_qty";
            this.cashierOrder_qty.Size = new System.Drawing.Size(203, 31);
            this.cashierOrder_qty.TabIndex = 7;
            this.cashierOrder_qty.ValueChanged += new System.EventHandler(this.cashierOrder_qty_ValueChanged);
            // 
            // cashierOrder_clearBtn
            // 
            this.cashierOrder_clearBtn.BackColor = System.Drawing.Color.Black;
            this.cashierOrder_clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cashierOrder_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrder_clearBtn.Location = new System.Drawing.Point(475, 274);
            this.cashierOrder_clearBtn.Name = "cashierOrder_clearBtn";
            this.cashierOrder_clearBtn.Size = new System.Drawing.Size(132, 54);
            this.cashierOrder_clearBtn.TabIndex = 6;
            this.cashierOrder_clearBtn.Text = "CLEAR";
            this.cashierOrder_clearBtn.UseVisualStyleBackColor = false;
            this.cashierOrder_clearBtn.Click += new System.EventHandler(this.cashierOrder_clearBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cashierOrder_removeBtn);
            this.panel2.Controls.Add(this.cashierOrder_addBtn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cashierOrder_searchBox);
            this.panel2.Controls.Add(this.cashierOrder_price);
            this.panel2.Controls.Add(this.cashierOrder_productID);
            this.panel2.Controls.Add(this.cashierOrder_clearBtn);
            this.panel2.Controls.Add(this.cashierOrder_qty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5cashierOrder_ProdName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(12, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 339);
            this.panel2.TabIndex = 1;
            // 
            // cashierOrder_removeBtn
            // 
            this.cashierOrder_removeBtn.BackColor = System.Drawing.Color.Black;
            this.cashierOrder_removeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cashierOrder_removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrder_removeBtn.Location = new System.Drawing.Point(185, 274);
            this.cashierOrder_removeBtn.Name = "cashierOrder_removeBtn";
            this.cashierOrder_removeBtn.Size = new System.Drawing.Size(132, 54);
            this.cashierOrder_removeBtn.TabIndex = 0;
            this.cashierOrder_removeBtn.Text = "REMOVE";
            this.cashierOrder_removeBtn.UseVisualStyleBackColor = false;
            this.cashierOrder_removeBtn.Click += new System.EventHandler(this.cashierOrder_removeBtn_Click);
            // 
            // cashierOrder_addBtn
            // 
            this.cashierOrder_addBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashierOrder_addBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cashierOrder_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrder_addBtn.Location = new System.Drawing.Point(11, 274);
            this.cashierOrder_addBtn.Name = "cashierOrder_addBtn";
            this.cashierOrder_addBtn.Size = new System.Drawing.Size(132, 54);
            this.cashierOrder_addBtn.TabIndex = 1;
            this.cashierOrder_addBtn.Text = "ADD";
            this.cashierOrder_addBtn.UseVisualStyleBackColor = false;
            this.cashierOrder_addBtn.Click += new System.EventHandler(this.cashierOrder_addBtn_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "SEARCH PRODUCT";
            // 
            // cashierOrder_searchBox
            // 
            this.cashierOrder_searchBox.Location = new System.Drawing.Point(40, 110);
            this.cashierOrder_searchBox.Name = "cashierOrder_searchBox";
            this.cashierOrder_searchBox.Size = new System.Drawing.Size(199, 31);
            this.cashierOrder_searchBox.TabIndex = 3;
            this.cashierOrder_searchBox.TextChanged += new System.EventHandler(this.cashierOrder_searchBox_TextChanged);
            // 
            // cashierOrder_price
            // 
            this.cashierOrder_price.ForeColor = System.Drawing.Color.Black;
            this.cashierOrder_price.Location = new System.Drawing.Point(245, 201);
            this.cashierOrder_price.Name = "cashierOrder_price";
            this.cashierOrder_price.Size = new System.Drawing.Size(102, 23);
            this.cashierOrder_price.TabIndex = 4;
            this.cashierOrder_price.Text = "₱";
            // 
            // cashierOrder_productID
            // 
            this.cashierOrder_productID.Location = new System.Drawing.Point(41, 147);
            this.cashierOrder_productID.Name = "cashierOrder_productID";
            this.cashierOrder_productID.Size = new System.Drawing.Size(198, 31);
            this.cashierOrder_productID.TabIndex = 5;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // cashierOrder_payOrders
            // 
            this.cashierOrder_payOrders.BackColor = System.Drawing.Color.Black;
            this.cashierOrder_payOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrder_payOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cashierOrder_payOrders.ForeColor = System.Drawing.Color.White;
            this.cashierOrder_payOrders.Location = new System.Drawing.Point(12, 650);
            this.cashierOrder_payOrders.Name = "cashierOrder_payOrders";
            this.cashierOrder_payOrders.Size = new System.Drawing.Size(436, 48);
            this.cashierOrder_payOrders.TabIndex = 22;
            this.cashierOrder_payOrders.Text = "Pay Orders";
            this.cashierOrder_payOrders.UseVisualStyleBackColor = false;
            this.cashierOrder_payOrders.Click += new System.EventHandler(this.cashierOrder_payOrders_Click);
            // 
            // cashierOrder_discountBtn
            // 
            this.cashierOrder_discountBtn.BackColor = System.Drawing.Color.Black;
            this.cashierOrder_discountBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cashierOrder_discountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrder_discountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrder_discountBtn.ForeColor = System.Drawing.Color.White;
            this.cashierOrder_discountBtn.Location = new System.Drawing.Point(12, 559);
            this.cashierOrder_discountBtn.Name = "cashierOrder_discountBtn";
            this.cashierOrder_discountBtn.Size = new System.Drawing.Size(132, 54);
            this.cashierOrder_discountBtn.TabIndex = 28;
            this.cashierOrder_discountBtn.Text = "20% DISCOUNT";
            this.cashierOrder_discountBtn.UseVisualStyleBackColor = false;
            this.cashierOrder_discountBtn.Click += new System.EventHandler(this.cashierOrder_discountBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(181, 572);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 25);
            this.label8.TabIndex = 29;
            this.label8.Text = ".......";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // CashierOrder
            // 
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CashierOrder";
            this.Size = new System.Drawing.Size(1116, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrder_qty)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5cashierOrder_ProdName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown cashierOrder_qty;
        private System.Windows.Forms.Button cashierOrder_clearBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label cashierOrder_totalPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label cashierOrder_change;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cashierOrder_ammount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox cashierOrder_productID;
        private System.Windows.Forms.Label cashierOrder_price;
        private System.Windows.Forms.TextBox cashierOrder_searchBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cashierOrder_addBtn;
        private System.Windows.Forms.Button cashierOrder_removeBtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button cashierOrder_payOrders;
        private System.Windows.Forms.Button cashierOrder_discountBtn;
        private System.Windows.Forms.Label label8;
    }
}
