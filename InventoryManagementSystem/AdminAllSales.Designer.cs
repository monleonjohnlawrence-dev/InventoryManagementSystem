namespace InventoryManagementSystem
{
    partial class AdminAllSales
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dashBoard_totalIncome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteAllSales_clearBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 177);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 222);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(679, 500);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dashBoard_totalIncome);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(389, 288);
            this.panel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(98, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Income:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dashBoard_totalIncome
            // 
            this.dashBoard_totalIncome.AutoSize = true;
            this.dashBoard_totalIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoard_totalIncome.ForeColor = System.Drawing.Color.White;
            this.dashBoard_totalIncome.Location = new System.Drawing.Point(59, 156);
            this.dashBoard_totalIncome.Name = "dashBoard_totalIncome";
            this.dashBoard_totalIncome.Size = new System.Drawing.Size(82, 31);
            this.dashBoard_totalIncome.TabIndex = 1;
            this.dashBoard_totalIncome.Text = "$0.00";
            this.dashBoard_totalIncome.Click += new System.EventHandler(this.dashBoard_totalIncome_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "ALL SALES!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(424, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 42);
            this.label1.TabIndex = 7;
            this.label1.Text = "STORE NAME";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(676, 500);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(707, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 291);
            this.panel2.TabIndex = 2;
            // 
            // deleteAllSales_clearBtn
            // 
            this.deleteAllSales_clearBtn.BackColor = System.Drawing.Color.Black;
            this.deleteAllSales_clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteAllSales_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.deleteAllSales_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.deleteAllSales_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAllSales_clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllSales_clearBtn.ForeColor = System.Drawing.Color.White;
            this.deleteAllSales_clearBtn.Location = new System.Drawing.Point(710, 675);
            this.deleteAllSales_clearBtn.Name = "deleteAllSales_clearBtn";
            this.deleteAllSales_clearBtn.Size = new System.Drawing.Size(389, 47);
            this.deleteAllSales_clearBtn.TabIndex = 21;
            this.deleteAllSales_clearBtn.Text = "Clear all Sales";
            this.deleteAllSales_clearBtn.UseVisualStyleBackColor = false;
            this.deleteAllSales_clearBtn.Click += new System.EventHandler(this.deleteAllSales_clearBtn_Click);
            // 
            // AdminAllSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteAllSales_clearBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "AdminAllSales";
            this.Size = new System.Drawing.Size(1117, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dashBoard_totalIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button deleteAllSales_clearBtn;
    }
}
