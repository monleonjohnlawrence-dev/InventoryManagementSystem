using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CashierDashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\InventoryManagementSystem\InventoryManagementSystem\DataBase\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        Timer autoRefreshTimer = new Timer();

        public CashierDashboard()
        {
            InitializeComponent();
            LoadTodaysSales();
            LoadTodaysData();

            autoRefreshTimer.Interval = 2000; // Refresh every 2 seconds
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;
            autoRefreshTimer.Start();
        }

        private void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadTodaysData();
            LoadTodaysSales();
        }

        private void LoadTodaysSales()
        {
            try
            {
                connect.Open();

                // Use transactionData table for completed payments
                SqlCommand cmd = new SqlCommand(
                    "SELECT SUM(total_amount) FROM transactionData WHERE CAST(transaction_date AS DATE) = CAST(GETDATE() AS DATE)", connect);
                object result = cmd.ExecuteScalar();

                double todaySales = 0;
                if (result != DBNull.Value)
                    todaySales = Convert.ToDouble(result);

                tday_Sales.Text = "₱" + todaySales.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's sales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void LoadTodaysData()
        {
            try
            {
                connect.Open();

                // Show only completed transactions from transactionData
                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT id AS TransactionID, customer_id AS CustomerID, total_amount AS Total, cash_paid AS CashPaid, change_amount AS Change, transaction_date AS Date FROM transactionData WHERE CAST(transaction_date AS DATE) = CAST(GETDATE() AS DATE)", connect);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void tday_Sales_Click(object sender, EventArgs e)
        {
            // Optional: show a message or refresh manually
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle clicks on transactions
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            // Already handled in constructor
        }
    }
}
