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

namespace InventoryManagementSystem
{
    public partial class AdminAllSales : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAllSales()
        {
            InitializeComponent();
            DisplayData();
            ShowTotalIncome();
        }

        private void DisplayData()
        {
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM customers", connect);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();
        }

        private void ShowTotalIncome()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(total_price) FROM customers", connect);
            object result = cmd.ExecuteScalar();

            double totalIncome = 0;
            if (result != DBNull.Value)
                totalIncome = Convert.ToDouble(result);

            dashBoard_totalIncome.Text = "₱" + totalIncome.ToString("N2");
            connect.Close();
          
        }

        private void dashBoard_totalIncome_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowTotalIncome();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void deleteAllSales_clearBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM customers", connect);
            cmd.ExecuteNonQuery();
            connect.Close();

            DisplayData();
            ShowTotalIncome();
        }
    }
}
