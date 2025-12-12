using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CashierOrder : UserControl
    {
        private readonly string _connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\InventoryManagementSystem\InventoryManagementSystem\DataBase\inventory.mdf;Integrated Security=True;Connect Timeout=30";

        // Receipt state after successful payment
        private List<(string prodName, int qty, double unitPrice, double totalPrice)> lastTransactionItems
            = new List<(string, int, double, double)>();

        private double lastTransactionPaid = 0;
        private double lastTransactionChange = 0;
        private string lastCustomerId = "";

        // Receipt formatting state
        private int receiptY;
        private readonly int receiptLeft = 20;
        private readonly int receiptWidth = 260;

        public CashierOrder()
        {
            InitializeComponent();

            if (IsInDesignMode())
                return;

            EnsureTransactionItemsTable();
            displayallAvailableProducts();
            DisplayAllOrders();
            CalculateTotalPrice();

            printDocument1.BeginPrint += printDocument1_BeginPrint;
            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        private void EnsureTransactionItemsTable()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = @"
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='transactionItems')
BEGIN
    CREATE TABLE transactionItems(
        id INT IDENTITY(1,1) PRIMARY KEY,
        transaction_id INT NOT NULL,
        prod_id INT NOT NULL,
        prod_name VARCHAR(MAX),
        qty INT,
        orig_price DECIMAL(18,2),
        total_price DECIMAL(18,2),
        order_date DATETIME
    );
END";
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch { }
        }

        // ---------------------------------------------------------------
        // LOAD ALL PRODUCTS
        // ---------------------------------------------------------------
        public void displayallAvailableProducts()
        {
            if (IsInDesignMode()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        "SELECT id, prod_name, price, stock FROM products WHERE status='Available'", conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataGridView1.DataSource = dt;

                    if (DataGridView1.Columns.Contains("price"))
                        DataGridView1.Columns["price"].DefaultCellStyle.Format = "₱ #,##0.00";

                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DataGridView1.ReadOnly = true;
                    DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Load Error: " + ex.Message);
            }
        }

        private void SearchProducts()
        {
            if (IsInDesignMode()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
@"SELECT id, prod_name, price FROM products 
  WHERE status='Available' AND prod_name LIKE @s + '%'", conn);

                    cmd.Parameters.AddWithValue("@s", cashierOrder_searchBox.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cashierOrder_productID.Text =
                DataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

            label5cashierOrder_ProdName.Text =
                DataGridView1.Rows[e.RowIndex].Cells["prod_name"].Value.ToString();

            cashierOrder_price.Text =
                DataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
        }

        private void cashierOrder_searchBox_TextChanged(object sender, EventArgs e)
        {
            SearchProducts();
        }

        // ---------------------------------------------------------------
        // ADD ORDER  (fixed version)
        // ---------------------------------------------------------------
        private void cashierOrder_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cashierOrder_productID.Text))
            {
                MessageBox.Show("Select a product first.");
                return;
            }

            int qty = (int)cashierOrder_qty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }

            if (!double.TryParse(cashierOrder_price.Text, out double price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            double total = qty * price;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        // Check stock
                        SqlCommand stockCmd = new SqlCommand(
                            "SELECT stock FROM products WHERE id=@id", conn, tran);
                        stockCmd.Parameters.AddWithValue("@id", cashierOrder_productID.Text);

                        int stock = Convert.ToInt32(stockCmd.ExecuteScalar());
                        if (qty > stock)
                        {
                            MessageBox.Show($"Not enough stock. Available: {stock}");
                            tran.Rollback();
                            return;
                        }

                        // Insert into orders
                        SqlCommand insertCmd = new SqlCommand(
@"INSERT INTO orders (prod_id, prod_name, qty, orig_price, total_price, order_date)
  VALUES (@id, @name, @qty, @price, @total, @date)", conn, tran);

                        insertCmd.Parameters.AddWithValue("@id", cashierOrder_productID.Text);
                        insertCmd.Parameters.AddWithValue("@name", label5cashierOrder_ProdName.Text);
                        insertCmd.Parameters.AddWithValue("@qty", qty);
                        insertCmd.Parameters.AddWithValue("@price", price);
                        insertCmd.Parameters.AddWithValue("@total", total);
                        insertCmd.Parameters.AddWithValue("@date", DateTime.Now);
                        insertCmd.ExecuteNonQuery();

                        // Deduct stock
                        SqlCommand updateCmd = new SqlCommand(
                            "UPDATE products SET stock = stock - @q WHERE id=@id", conn, tran);
                        updateCmd.Parameters.AddWithValue("@q", qty);
                        updateCmd.Parameters.AddWithValue("@id", cashierOrder_productID.Text);
                        updateCmd.ExecuteNonQuery();

                        tran.Commit();
                    }
                }

                DisplayAllOrders();
                displayallAvailableProducts();

                cashierOrder_qty.Value = 1;
                cashierOrder_productID.Clear();
                label5cashierOrder_ProdName.Text = "";
                cashierOrder_price.Text = "0";

                DataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }
        // ---------------------------------------------------------------
        // DISPLAY ORDERS & TOTAL
        // ---------------------------------------------------------------
        private void DisplayAllOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM orders", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.ReadOnly = true;

                    // HIDE COLUMNS SAFELY (Only if they exist)
                    if (dataGridView2.Columns.Contains("id"))
                        dataGridView2.Columns["id"].Visible = false;

                    if (dataGridView2.Columns.Contains("customer_id"))
                        dataGridView2.Columns["customer_id"].Visible = false;

                    if (dataGridView2.Columns.Contains("order_date"))
                        dataGridView2.Columns["order_date"].Visible = false;
                }

                CalculateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load orders error: " + ex.Message);
            }
        }



        private void CalculateTotalPrice()
        {
            double total = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                if (double.TryParse(row.Cells["total_price"].Value?.ToString(), out double value))
                    total += value;
            }

            cashierOrder_totalPrice.Text = "₱ " + total.ToString("N2");
        }

        // ---------------------------------------------------------------
        // REMOVE ORDER (Fully Fixed)
        // ---------------------------------------------------------------
        private void cashierOrder_removeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order to remove.");
                return;
            }

            DataGridViewRow row = dataGridView2.SelectedRows[0];

            int orderId = Convert.ToInt32(row.Cells["id"].Value);
            int qty = Convert.ToInt32(row.Cells["qty"].Value);
            int prodID = Convert.ToInt32(row.Cells["prod_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        // Restore stock
                        SqlCommand stockCmd = new SqlCommand(
                            "UPDATE products SET stock = stock + @q WHERE id=@id", conn, tran);
                        stockCmd.Parameters.AddWithValue("@q", qty);
                        stockCmd.Parameters.AddWithValue("@id", prodID);
                        stockCmd.ExecuteNonQuery();

                        // Delete the order
                        SqlCommand deleteCmd = new SqlCommand(
                            "DELETE FROM orders WHERE id=@id", conn, tran);
                        deleteCmd.Parameters.AddWithValue("@id", orderId);
                        deleteCmd.ExecuteNonQuery();

                        tran.Commit();
                    }
                }

                DisplayAllOrders();
                displayallAvailableProducts();

                MessageBox.Show("Order removed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Remove error: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------
        // CLEAR ALL ORDERS (RESTORE STOCK)
        // ---------------------------------------------------------------
        private void cashierOrder_clearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        SqlCommand restoreCmd = new SqlCommand(@"
UPDATE products SET stock = stock + o.qty
FROM products p
INNER JOIN orders o ON p.id = o.prod_id;", conn, tran);
                        restoreCmd.ExecuteNonQuery();

                        SqlCommand clearCmd = new SqlCommand(
                            "DELETE FROM orders", conn, tran);
                        clearCmd.ExecuteNonQuery();

                        tran.Commit();
                    }
                }

                DisplayAllOrders();
                displayallAvailableProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clear error: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------
        // PAYMENT PROCESS  (Fully Fixed)
        // ---------------------------------------------------------------
        private void cashierOrder_payOrders_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("There are no orders to pay.");
                return;
            }

            if (!double.TryParse(cashierOrder_totalPrice.Text.Replace("₱", "").Trim(), out double totalAmount))
            {
                MessageBox.Show("Invalid total amount.");
                return;
            }

            if (!double.TryParse(cashierOrder_ammount.Text.Trim(), out double cashPaid))
            {
                MessageBox.Show("Invalid cash amount.");
                return;
            }

            if (cashPaid < totalAmount)
            {
                MessageBox.Show("Insufficient cash.");
                return;
            }

            double changeAmount = cashPaid - totalAmount;

            // Load current orders
            var orderItems = new List<(int prod_id, string prod_name, int qty, double orig_price, double total_price, DateTime order_date)>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT prod_id, prod_name, qty, orig_price, total_price, order_date FROM orders", conn);

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    orderItems.Add((
                        Convert.ToInt32(r["prod_id"]),
                        r["prod_name"].ToString(),
                        Convert.ToInt32(r["qty"]),
                        Convert.ToDouble(r["orig_price"]),
                        Convert.ToDouble(r["total_price"]),
                        Convert.ToDateTime(r["order_date"])
                    ));
                }
            }

            if (orderItems.Count == 0)
            {
                MessageBox.Show("No orders to process.");
                return;
            }

            string customerId = DateTime.Now.ToString("yyyyMMddHHmmss");
            int insertedTransId = -1;

            // Save transaction
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert transaction header
                        SqlCommand insertTrans = new SqlCommand(@"
INSERT INTO transactionData (customer_id, total_amount, cash_paid, change_amount, transaction_date)
VALUES (@cid, @t, @cash, @chg, @date);
SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran);

                        insertTrans.Parameters.AddWithValue("@cid", customerId);
                        insertTrans.Parameters.AddWithValue("@t", totalAmount);
                        insertTrans.Parameters.AddWithValue("@cash", cashPaid);
                        insertTrans.Parameters.AddWithValue("@chg", changeAmount);
                        insertTrans.Parameters.AddWithValue("@date", DateTime.Now);

                        insertedTransId = Convert.ToInt32(insertTrans.ExecuteScalar());

                        // Insert each item
                        foreach (var it in orderItems)
                        {
                            SqlCommand itemCmd = new SqlCommand(@"
INSERT INTO transactionItems (transaction_id, prod_id, prod_name, qty, orig_price, total_price, order_date)
VALUES (@tid, @pid, @pname, @qty, @op, @tp, @date)", conn, tran);

                            itemCmd.Parameters.AddWithValue("@tid", insertedTransId);
                            itemCmd.Parameters.AddWithValue("@pid", it.prod_id);
                            itemCmd.Parameters.AddWithValue("@pname", it.prod_name);
                            itemCmd.Parameters.AddWithValue("@qty", it.qty);
                            itemCmd.Parameters.AddWithValue("@op", it.orig_price);
                            itemCmd.Parameters.AddWithValue("@tp", it.total_price);
                            itemCmd.Parameters.AddWithValue("@date", it.order_date);

                            itemCmd.ExecuteNonQuery();
                        }

                        // Clear order table
                        new SqlCommand("DELETE FROM orders", conn, tran).ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Transaction failed: " + ex.Message);
                        return;
                    }
                }
            }

            // Store latest transaction for printing
            lastTransactionItems.Clear();
            lastCustomerId = customerId;
            lastTransactionPaid = cashPaid;
            lastTransactionChange = changeAmount;

            foreach (var it in orderItems)
                lastTransactionItems.Add((it.prod_name, it.qty, it.orig_price, it.total_price));

            DisplayAllOrders();
            displayallAvailableProducts();

            MessageBox.Show($"Payment successful! Change: ₱ {changeAmount:N2}");
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        // -------------------------------------------------------------------
        // PRINTING / RECEIPT  (Fully Fixed: Clean formatting + no duplicate print)
        // -------------------------------------------------------------------
        public void PrintAllOrders()
        {
            if (lastTransactionItems.Count == 0)
            {
                MessageBox.Show("No recent transaction to print.");
                return;
            }

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            receiptY = 20;
            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);

            int x = receiptLeft;
            int y = receiptY;

            // HEADER
            e.Graphics.DrawString("INVENTORY SYSTEM", titleFont, Brushes.Black, x, y);
            y += 28;
            e.Graphics.DrawString("Receipt", headerFont, Brushes.Black, x, y);
            y += 22;

            e.Graphics.DrawString("Customer ID: " + lastCustomerId, bodyFont, Brushes.Black, x, y);
            y += 18;

            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"),
                bodyFont, Brushes.Black, x, y);
            y += 18;

            e.Graphics.DrawLine(Pens.Black, x, y, x + receiptWidth, y);
            y += 8;

            // COLUMN HEADERS
            e.Graphics.DrawString("Product", boldFont, Brushes.Black, x, y);
            e.Graphics.DrawString("Qty", boldFont, Brushes.Black, x + 130, y);
            e.Graphics.DrawString("Total", boldFont, Brushes.Black, x + 185, y);
            y += 18;

            e.Graphics.DrawLine(Pens.Black, x, y, x + receiptWidth, y);
            y += 8;

            // ITEMS
            double grandTotal = 0;

            foreach (var item in lastTransactionItems)
            {
                string prod = item.prodName.Length > 15 ? item.prodName.Substring(0, 15) : item.prodName;

                e.Graphics.DrawString(prod, bodyFont, Brushes.Black, x, y);
                e.Graphics.DrawString(item.qty.ToString(), bodyFont, Brushes.Black, x + 130, y);
                e.Graphics.DrawString(item.totalPrice.ToString("N2"), bodyFont, Brushes.Black, x + 185, y);

                y += 18;
                grandTotal += item.totalPrice;

                // HANDLE NEW PAGE
                if (y > e.MarginBounds.Bottom - 60)
                {
                    e.HasMorePages = true;
                    receiptY = 20;
                    return;
                }
            }

            // TOTAL LINE
            y += 6;
            e.Graphics.DrawLine(Pens.Black, x, y, x + receiptWidth, y);
            y += 10;

            e.Graphics.DrawString("TOTAL:", boldFont, Brushes.Black, x, y);
            e.Graphics.DrawString("₱ " + grandTotal.ToString("N2"), boldFont, Brushes.Black, x + 140, y);
            y += 22;

            e.Graphics.DrawString("Amount Paid: ₱ " + lastTransactionPaid.ToString("N2"), bodyFont, Brushes.Black, x, y);
            y += 18;

            e.Graphics.DrawString("Change: ₱ " + lastTransactionChange.ToString("N2"), bodyFont, Brushes.Black, x, y);
            y += 22;

            e.Graphics.DrawLine(Pens.Black, x, y, x + receiptWidth, y);
            y += 12;

            // FOOTER
            e.Graphics.DrawString("Thank you for shopping!", bodyFont, Brushes.Black, x, y);
            y += 16;
            e.Graphics.DrawString("Please come again.", bodyFont, Brushes.Black, x, y);

            // Final page
            e.HasMorePages = false;
        }

        // -------------------------------------------------------------------
        // UI HELPER FUNCTIONS
        // -------------------------------------------------------------------
        private void cashierOrder_ammount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                if (double.TryParse(cashierOrder_totalPrice.Text.Replace("₱", "").Trim(), out double t))
                    total = t;

                double amount = double.TryParse(cashierOrder_ammount.Text.Trim(), out double a) ? a : 0;
                double change = amount - total;

                cashierOrder_change.Text = "₱ " + (change >= 0 ? change.ToString("N2") : "0.00");
            }
            catch
            {
                cashierOrder_change.Text = "₱ 0.00";
            }
        }

        private void cashierOrder_change_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change: " + cashierOrder_change.Text);
        }

        private void cashierOrder_qty_ValueChanged(object sender, EventArgs e)
        {
            // Optional logic if needed later
        }

        private void cashierOrder_discountBtn_Click(object sender, EventArgs e)
        {
            // Ask confirmation
            DialogResult result = MessageBox.Show(
                "Apply 20% discount to the total price?",
                "Confirm Discount",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return; // Cancel discount
            }

            // Convert displayed total price
            if (!double.TryParse(cashierOrder_totalPrice.Text.Replace("₱", "").Trim(), out double currentTotal))
            {
                MessageBox.Show("Invalid total amount.");
                return;
            }

            // Calculate 20% discount
            double discountAmount = currentTotal * 0.20;
            double newTotal = currentTotal - discountAmount;

            // Update the total price label
            cashierOrder_totalPrice.Text = "₱ " + newTotal.ToString("N2");

            // Update label8 text
            label8.Text = "DISCOUNTED!";

            MessageBox.Show("20% discount successfully applied!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
