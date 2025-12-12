using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace InventoryManagementSystem
{
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show receipt/print preview from the CashierOrder control.
            try
            {
                cashierOrder1.PrintAllOrders();
            }
            catch (MissingMethodException)
            {
                MessageBox.Show("PrintAllOrders() not found on cashierOrder1. Open CashierOrder and add a public PrintAllOrders() method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to show receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logout_Btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void cashierOrder1_Load(object sender, EventArgs e)
        {
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cDashBoard_btn_Click(object sender, EventArgs e)
        {
            cashierDashboard1.Visible = true;
            cashierOrder1.Visible = false;
        }

        private void cOrder_btn_Click(object sender, EventArgs e)
        {
            cashierDashboard1.Visible = false;
            cashierOrder1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void cashierOrder1_Load_1(object sender, EventArgs e) { }
    }
}