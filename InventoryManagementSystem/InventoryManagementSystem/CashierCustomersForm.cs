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
    public partial class CashierCustomersForm : UserControl
    {
        public CashierCustomersForm()
        {
            InitializeComponent();
            displayCustomers();
        }

        public void displayCustomers()
        {
            CustomersData cData = new CustomersData();
            List<CustomersData> listData = cData.allCustomers();
            dataGridView1.DataSource = listData;
        }

        private void CashierCustomersForm_Load(object sender, EventArgs e)
        {
            // You can also call displayCustomers() here if needed
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: handle label click event if needed
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click event if needed
        }
    }
}
