using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Application.Exit();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();

            }
         
        }

        private void adminsDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void adminAddUsers1_Load(object sender, EventArgs e)
        {

        }

        private void adminAddProducts1_Load(object sender, EventArgs e)
        {

        }

        private void adminAddProducts1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dashBoard_btn_Click(object sender, EventArgs e)
        {
            adminsDashboard1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddSuppliers1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAllSales1.Visible = false;


        }

        private void addUser_btn_Click(object sender, EventArgs e)
        {
            adminsDashboard1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddSuppliers1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAllSales1.Visible = false;
        }

        private void suppliers_btn_Click(object sender, EventArgs e)
        {
            adminsDashboard1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddSuppliers1.Visible = true;
            adminAddProducts1.Visible = false;
            adminAllSales1.Visible = false;

        }

        private void addProducts_btn_Click(object sender, EventArgs e)
        {
            adminsDashboard1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddSuppliers1.Visible = false;
            adminAddProducts1.Visible = true;
            adminAllSales1.Visible = false;
        }

        private void allSale_btn_Click(object sender, EventArgs e)
        {
            adminsDashboard1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddSuppliers1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAllSales1.Visible = true;
        }
    }
}
