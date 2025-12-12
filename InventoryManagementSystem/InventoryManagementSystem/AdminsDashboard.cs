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
using System.Drawing.Printing;

namespace InventoryManagementSystem
{
    public partial class AdminsDashboard : UserControl
    {
        // Database connection string (adjust path if needed)
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\InventoryManagementSystem\InventoryManagementSystem\DataBase\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        // ------------------ PRINTING VARIABLES ------------------
        PrintDocument printDocument = new PrintDocument();
        int currentRow = 0;
        // ---------------------------------------------------------

        public AdminsDashboard()
        {
            InitializeComponent();

            // Load all dashboard data on initialization
            displayTodayCustomers();
            displayAllUsers();
            displayAllCustomer();
            displayTodaysIncome();
            displayTotalIncome();

            // Attach print event (ADDED)
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        // ✅ Checks if connection is working
        private bool checkConnection()
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                    connect.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ✅ Display customers who ordered today
        public void displayTodayCustomers()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    DateTime today = DateTime.Today;
                    string selectData = "SELECT * FROM customers WHERE CONVERT(date, order_date) = @date";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@date", today);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customers: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Display total number of active users
        public void displayAllUsers()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT COUNT(id) FROM users WHERE status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@status", "Active");
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashBoard_AU.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Display total number of customers
        public void displayAllCustomer()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT COUNT(id) FROM customers";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashBoard_AC.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Display today’s total income
        public void displayTodaysIncome()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT SUM(total_price) FROM customers WHERE CONVERT(date, order_date) = @date";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@date", today);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            object value = reader[0];
                            if (value != DBNull.Value)
                            {
                                decimal total = Convert.ToDecimal(value);
                                dashBoard_TI.Text = total.ToString("C2");
                            }
                            else
                            {
                                dashBoard_TI.Text = "$0.00";
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Display total income (all time)
        public void displayTotalIncome()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT SUM(total_price) FROM customers";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            object value = reader[0];
                            if (value != DBNull.Value)
                            {
                                decimal total = Convert.ToDecimal(value);
                                dashBoard_totalIncome.Text = total.ToString("C2");
                            }
                            else
                            {
                                dashBoard_totalIncome.Text = "$0.00";
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // --- UI Events (if needed) ---
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dashBoard_AU_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        // ---------------- PRINT BUTTON ----------------
        private void print_Btn_Click(object sender, EventArgs e)
        {
            currentRow = 0;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument;
            preview.ShowDialog();
        }

        // ---------------- PRINTING LOGIC ----------------
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int margin = 50; // 0.5 inch
            int x = margin;
            int y = margin;

            Font font = new Font("Arial", 10);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            int rowHeight = 30;

            int printableWidth = e.PageBounds.Width - (margin * 2);
            int colWidth = printableWidth / dataGridView1.Columns.Count;

            // ============================
            // CENTERED MAIN HEADER
            // ============================
            string headerText = "ALL SALES FOR TODAY";
            SizeF headerSize = e.Graphics.MeasureString(headerText, headerFont);
            float headerX = (e.PageBounds.Width - headerSize.Width) / 2;

            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, headerX, y);
            y += (int)headerSize.Height + 20;

            // ============================
            // TABLE HEADER
            // ============================
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                e.Graphics.DrawString(
                    dataGridView1.Columns[i].HeaderText,
                    font,
                    Brushes.Black,
                    x + (i * colWidth),
                    y
                );
            }

            y += rowHeight;

            // ============================
            // PRINT ROWS
            // ============================
            while (currentRow < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[currentRow];

                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    object value = row.Cells[i].Value;
                    string cellText = value == null ? "" : value.ToString();

                    e.Graphics.DrawString(
                        cellText,
                        font,
                        Brushes.Black,
                        x + (i * colWidth),
                        y
                    );
                }

                y += rowHeight;
                currentRow++;
            }

            e.HasMorePages = false;
        }

    }
}
