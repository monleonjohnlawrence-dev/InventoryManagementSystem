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
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryManagementSystem
{
    public partial class AdminAllSales : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\InventoryManagementSystem\InventoryManagementSystem\DataBase\inventory.mdf;Integrated Security=True");

        public AdminAllSales()
        {
            InitializeComponent();
            LoadYears();
        }

        // -----------------------------
        // Load Years into Dropdown
        // -----------------------------
        private void LoadYears()
        {
            Year.Items.Clear();

            for (int yr = 2020; yr <= DateTime.Now.Year; yr++)
            {
                Year.Items.Add(yr);
            }

            Year.SelectedItem = DateTime.Now.Year;
        }

        // -----------------------------
        // WHEN YEAR CHANGES → Reload Charts
        // -----------------------------
        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Year.SelectedItem == null) return;

            int selectedYear = Convert.ToInt32(Year.SelectedItem);

            LoadBestSelling(selectedYear);
            LoadMonthlySales(selectedYear);
            LoadYearlySales();
        }

        // ---------------------------------------------------------------
        // CHART 1 — BEST SELLING PRODUCTS (Pie) — USING transactionItems
        // ---------------------------------------------------------------
        private void LoadBestSelling(int year)
        {
            connect.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT prod_name, SUM(qty) AS TotalQty
                FROM transactionItems
                WHERE YEAR(order_date) = @yr
                GROUP BY prod_name
                ORDER BY TotalQty DESC", connect);

            cmd.Parameters.AddWithValue("@yr", year);

            SqlDataReader dr = cmd.ExecuteReader();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("Area1"));

            Series series = chart1.Series.Add("BestSelling");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            bool hasData = false;

            while (dr.Read())
            {
                hasData = true;
                series.Points.AddXY(
                    dr["prod_name"].ToString(),
                    Convert.ToInt32(dr["TotalQty"])
                );
            }

            connect.Close();

            if (!hasData)
            {
                series.Points.AddXY("No Data", 1);
            }
        }

        // ---------------------------------------------------------------
        // CHART 2 — MONTHLY SALES (Column) — USING transactionData
        // ---------------------------------------------------------------
        private void LoadMonthlySales(int year)
        {
            connect.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    DATENAME(month, transaction_date) AS MonthName,
                    MONTH(transaction_date) AS MonthNum,
                    SUM(total_amount) AS TotalSales
                FROM transactionData
                WHERE YEAR(transaction_date) = @yr
                GROUP BY DATENAME(month, transaction_date), MONTH(transaction_date)
                ORDER BY MonthNum", connect);

            cmd.Parameters.AddWithValue("@yr", year);

            SqlDataReader dr = cmd.ExecuteReader();

            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.ChartAreas.Add(new ChartArea("Area2"));

            Series series = chart2.Series.Add("MonthlySales");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            string[] months =
            {
                "January","February","March","April","May","June",
                "July","August","September","October","November","December"
            };

            Dictionary<string, decimal> monthData = new Dictionary<string, decimal>();

            foreach (string m in months)
                monthData[m] = 0;

            while (dr.Read())
            {
                string monthName = dr["MonthName"].ToString();
                decimal total = Convert.ToDecimal(dr["TotalSales"]);
                monthData[monthName] = total;
            }

            connect.Close();

            foreach (string m in months)
            {
                series.Points.AddXY(m.Substring(0, 3), monthData[m]);
            }

            chart2.ChartAreas[0].AxisX.Title = "Months";
            chart2.ChartAreas[0].AxisY.Title = "Sales Amount (₱)";
            chart2.Titles.Clear();
            chart2.Titles.Add("Monthly Sales (Jan–Dec)");
        }

        // ---------------------------------------------------------------
        // CHART 3 — YEARLY SALES (Line) — USING transactionData
        // ---------------------------------------------------------------
        private void LoadYearlySales()
        {
            connect.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT YEAR(transaction_date) AS YearNum,
                       SUM(total_amount) AS TotalSales
                FROM transactionData
                GROUP BY YEAR(transaction_date)
                ORDER BY YearNum", connect);

            SqlDataReader dr = cmd.ExecuteReader();

            chart3.Series.Clear();
            chart3.ChartAreas.Clear();
            chart3.ChartAreas.Add(new ChartArea("Area3"));

            Series series = chart3.Series.Add("YearlySales");
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;

            while (dr.Read())
            {
                series.Points.AddXY(
                    dr["YearNum"].ToString(),
                    Convert.ToDecimal(dr["TotalSales"])
                );
            }

            connect.Close();
        }

        // -----------------------------
        // Empty Handlers (Keep them)
        // -----------------------------
        private void Month_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chart1_Click(object sender, EventArgs e) { }
        private void chart2_Click(object sender, EventArgs e) { }
        private void chart3_Click(object sender, EventArgs e) { }
    }
}
