using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CashierDashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        Timer autoRefreshTimer = new Timer();

        public CashierDashboard()
        {
            InitializeComponent();
            LoadTodaysSales();
            LoadTodaysData();

            // Setup timer to refresh every 2 seconds
            autoRefreshTimer.Interval = 2000; // 2000 ms = 2 seconds
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
            connect.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT SUM(total_price) FROM customers WHERE order_date = CAST(GETDATE() AS DATE)", connect);
            object result = cmd.ExecuteScalar();

            double todaySales = 0;
            if (result != DBNull.Value)
                todaySales = Convert.ToDouble(result);

            tday_Sales.Text = "₱" + todaySales.ToString("N2");
            connect.Close();
        }

        private void LoadTodaysData()
        {
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM customers WHERE order_date = CAST(GETDATE() AS DATE)", connect);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;
            connect.Close();
        }

        private void tday_Sales_Click(object sender, EventArgs e)
        {
            // Nothing needed
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nothing needed
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            // Nothing needed
        }
    }
}
