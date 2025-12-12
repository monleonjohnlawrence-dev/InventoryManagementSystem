namespace InventoryManagementSystem
{
    partial class AdminAddSuppliers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addSuppliers_contact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addSupplier_clearBtn = new System.Windows.Forms.Button();
            this.addSupplier_removeBtn = new System.Windows.Forms.Button();
            this.addSupplier_updateBtn = new System.Windows.Forms.Button();
            this.addSuplpliers_addBtn = new System.Windows.Forms.Button();
            this.addSuppliers_supply = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(695, 654);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(360, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 718);
            this.panel2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Suppliers List";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.addSuppliers_contact);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.addSupplier_clearBtn);
            this.panel1.Controls.Add(this.addSupplier_removeBtn);
            this.panel1.Controls.Add(this.addSupplier_updateBtn);
            this.panel1.Controls.Add(this.addSuplpliers_addBtn);
            this.panel1.Controls.Add(this.addSuppliers_supply);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(52, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 512);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // addSuppliers_contact
            // 
            this.addSuppliers_contact.BackColor = System.Drawing.Color.White;
            this.addSuppliers_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuppliers_contact.ForeColor = System.Drawing.Color.Black;
            this.addSuppliers_contact.Location = new System.Drawing.Point(25, 164);
            this.addSuppliers_contact.Name = "addSuppliers_contact";
            this.addSuppliers_contact.Size = new System.Drawing.Size(191, 31);
            this.addSuppliers_contact.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Contact no.";
            // 
            // addSupplier_clearBtn
            // 
            this.addSupplier_clearBtn.BackColor = System.Drawing.Color.Black;
            this.addSupplier_clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addSupplier_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSupplier_clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplier_clearBtn.ForeColor = System.Drawing.Color.White;
            this.addSupplier_clearBtn.Location = new System.Drawing.Point(36, 439);
            this.addSupplier_clearBtn.Name = "addSupplier_clearBtn";
            this.addSupplier_clearBtn.Size = new System.Drawing.Size(162, 54);
            this.addSupplier_clearBtn.TabIndex = 11;
            this.addSupplier_clearBtn.Text = "Clear";
            this.addSupplier_clearBtn.UseVisualStyleBackColor = false;
            this.addSupplier_clearBtn.Click += new System.EventHandler(this.addSupplier_clearBtn_Click);
            // 
            // addSupplier_removeBtn
            // 
            this.addSupplier_removeBtn.BackColor = System.Drawing.Color.Black;
            this.addSupplier_removeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addSupplier_removeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_removeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSupplier_removeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplier_removeBtn.ForeColor = System.Drawing.Color.White;
            this.addSupplier_removeBtn.Location = new System.Drawing.Point(36, 368);
            this.addSupplier_removeBtn.Name = "addSupplier_removeBtn";
            this.addSupplier_removeBtn.Size = new System.Drawing.Size(162, 54);
            this.addSupplier_removeBtn.TabIndex = 10;
            this.addSupplier_removeBtn.Text = "Remove";
            this.addSupplier_removeBtn.UseVisualStyleBackColor = false;
            this.addSupplier_removeBtn.Click += new System.EventHandler(this.addSupplier_removeBtn_Click);
            // 
            // addSupplier_updateBtn
            // 
            this.addSupplier_updateBtn.BackColor = System.Drawing.Color.Black;
            this.addSupplier_updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addSupplier_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSupplier_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSupplier_updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplier_updateBtn.ForeColor = System.Drawing.Color.White;
            this.addSupplier_updateBtn.Location = new System.Drawing.Point(36, 296);
            this.addSupplier_updateBtn.Name = "addSupplier_updateBtn";
            this.addSupplier_updateBtn.Size = new System.Drawing.Size(162, 54);
            this.addSupplier_updateBtn.TabIndex = 9;
            this.addSupplier_updateBtn.Text = "Update";
            this.addSupplier_updateBtn.UseVisualStyleBackColor = false;
            this.addSupplier_updateBtn.Click += new System.EventHandler(this.addSupplier_updateBtn_Click);
            // 
            // addSuplpliers_addBtn
            // 
            this.addSuplpliers_addBtn.BackColor = System.Drawing.Color.Black;
            this.addSuplpliers_addBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addSuplpliers_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSuplpliers_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSuplpliers_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSuplpliers_addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuplpliers_addBtn.ForeColor = System.Drawing.Color.White;
            this.addSuplpliers_addBtn.Location = new System.Drawing.Point(36, 226);
            this.addSuplpliers_addBtn.Name = "addSuplpliers_addBtn";
            this.addSuplpliers_addBtn.Size = new System.Drawing.Size(162, 54);
            this.addSuplpliers_addBtn.TabIndex = 8;
            this.addSuplpliers_addBtn.Text = "Add";
            this.addSuplpliers_addBtn.UseVisualStyleBackColor = false;
            this.addSuplpliers_addBtn.Click += new System.EventHandler(this.addUsers_addBtn_Click);
            // 
            // addSuppliers_supply
            // 
            this.addSuppliers_supply.BackColor = System.Drawing.Color.White;
            this.addSuppliers_supply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuppliers_supply.ForeColor = System.Drawing.Color.Black;
            this.addSuppliers_supply.Location = new System.Drawing.Point(25, 71);
            this.addSuppliers_supply.Name = "addSuppliers_supply";
            this.addSuppliers_supply.Size = new System.Drawing.Size(191, 31);
            this.addSuppliers_supply.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier ";
            // 
            // AdminAddSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminAddSuppliers";
            this.Size = new System.Drawing.Size(1116, 738);
            this.Load += new System.EventHandler(this.AdminAddSuppliers_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addSupplier_clearBtn;
        private System.Windows.Forms.Button addSupplier_removeBtn;
        private System.Windows.Forms.Button addSupplier_updateBtn;
        private System.Windows.Forms.Button addSuplpliers_addBtn;
        private System.Windows.Forms.TextBox addSuppliers_supply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addSuppliers_contact;
        private System.Windows.Forms.Label label2;
    }
}
