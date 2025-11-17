namespace InventoryManagementSystem
{
    partial class CashierMainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout_Btn = new System.Windows.Forms.Button();
            this.cOrder_btn = new System.Windows.Forms.Button();
            this.cDashBoard_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cashierDashboard1 = new InventoryManagementSystem.CashierDashboard();
            this.cashierOrder1 = new InventoryManagementSystem.CashierOrder();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1335, 45);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Super K | Cashier\'s Portal";
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Firebrick;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(1276, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(56, 25);
            this.close.TabIndex = 1;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.logout_Btn);
            this.panel2.Controls.Add(this.cOrder_btn);
            this.panel2.Controls.Add(this.cDashBoard_btn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 757);
            this.panel2.TabIndex = 2;
            // 
            // logout_Btn
            // 
            this.logout_Btn.BackColor = System.Drawing.Color.Black;
            this.logout_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logout_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logout_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_Btn.ForeColor = System.Drawing.Color.White;
            this.logout_Btn.Location = new System.Drawing.Point(10, 710);
            this.logout_Btn.Name = "logout_Btn";
            this.logout_Btn.Size = new System.Drawing.Size(174, 35);
            this.logout_Btn.TabIndex = 15;
            this.logout_Btn.Text = "Logout";
            this.logout_Btn.UseVisualStyleBackColor = false;
            this.logout_Btn.Click += new System.EventHandler(this.logout_Btn_Click);
            // 
            // cOrder_btn
            // 
            this.cOrder_btn.BackColor = System.Drawing.Color.Black;
            this.cOrder_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cOrder_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cOrder_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cOrder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cOrder_btn.ForeColor = System.Drawing.Color.White;
            this.cOrder_btn.Location = new System.Drawing.Point(10, 216);
            this.cOrder_btn.Name = "cOrder_btn";
            this.cOrder_btn.Size = new System.Drawing.Size(174, 52);
            this.cOrder_btn.TabIndex = 13;
            this.cOrder_btn.Text = "Order";
            this.cOrder_btn.UseVisualStyleBackColor = false;
            this.cOrder_btn.Click += new System.EventHandler(this.cOrder_btn_Click);
            // 
            // cDashBoard_btn
            // 
            this.cDashBoard_btn.BackColor = System.Drawing.Color.Black;
            this.cDashBoard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cDashBoard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cDashBoard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cDashBoard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDashBoard_btn.ForeColor = System.Drawing.Color.White;
            this.cDashBoard_btn.Location = new System.Drawing.Point(10, 274);
            this.cDashBoard_btn.Name = "cDashBoard_btn";
            this.cDashBoard_btn.Size = new System.Drawing.Size(174, 52);
            this.cDashBoard_btn.TabIndex = 3;
            this.cDashBoard_btn.Text = "Dashboard";
            this.cDashBoard_btn.UseVisualStyleBackColor = false;
            this.cDashBoard_btn.Click += new System.EventHandler(this.cDashBoard_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(102, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome,";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cashierOrder1);
            this.panel3.Controls.Add(this.cashierDashboard1);
            this.panel3.Location = new System.Drawing.Point(207, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1116, 738);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InventoryManagementSystem.Properties.Resources.User1;
            this.pictureBox1.Location = new System.Drawing.Point(50, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // cashierDashboard1
            // 
            this.cashierDashboard1.Location = new System.Drawing.Point(0, 0);
            this.cashierDashboard1.Name = "cashierDashboard1";
            this.cashierDashboard1.Size = new System.Drawing.Size(1117, 738);
            this.cashierDashboard1.TabIndex = 0;
            // 
            // cashierOrder1
            // 
            this.cashierOrder1.Location = new System.Drawing.Point(3, 3);
            this.cashierOrder1.Name = "cashierOrder1";
            this.cashierOrder1.Size = new System.Drawing.Size(1116, 738);
            this.cashierOrder1.TabIndex = 1;
            // 
            // CashierMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 801);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashierMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout_Btn;
        private System.Windows.Forms.Button cOrder_btn;
        private System.Windows.Forms.Button cDashBoard_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private CashierOrder cashierOrder1;
        private CashierDashboard cashierDashboard1;
    }
}