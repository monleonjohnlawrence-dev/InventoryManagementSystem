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
    public partial class CashierOrder : UserControl
    {
        public CashierOrder()
        {
            InitializeComponent();
            displayallAvailableProducts();

            // ✅ handle clicks on DataGridView
            DataGridView1.CellClick += DataGridView1_CellClick;

            // ✅ display orders table in dataGridView2 on start
            DisplayAllOrders();
            CalculateTotalPrice(); // ✅ added: show total on load

        }

        public void displayallAvailableProducts()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    string query = "SELECT id, prod_name, price, stock FROM products WHERE status = 'Available'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataGridView1.DataSource = dt;

                        DataGridView1.Columns["id"].HeaderText = "Product ID";
                        DataGridView1.Columns["prod_name"].HeaderText = "Product Name";
                        DataGridView1.Columns["price"].HeaderText = "Price (₱)";
                        DataGridView1.Columns["price"].DefaultCellStyle.Format = "₱ #,##0.00";

                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        DataGridView1.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("No available products found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

                cashierOrder_productID.Text = row.Cells["id"].Value.ToString();
                label5cashierOrder_ProdName.Text = row.Cells["prod_name"].Value.ToString();
                cashierOrder_price.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cashierOrder_productID_TextChanged(object sender, EventArgs e) { }
        private void label5cashierOrder_ProdName_Click(object sender, EventArgs e) { }
        private void cashierOrder_price_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void cashierOrder_qty_ValueChanged(object sender, EventArgs e) { }

        private void cashierOrder_searchBox_TextChanged(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void SearchProducts()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    string search = cashierOrder_searchBox.Text.Trim();

                    string query = @"SELECT id, prod_name, price 
                                     FROM products 
                                     WHERE status = 'Available' 
                                     AND prod_name LIKE @search + '%'";

                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@search", search);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message);
            }
        }

        private void cashierOrder_addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cashierOrder_productID.Text) ||
                    string.IsNullOrEmpty(label5cashierOrder_ProdName.Text) ||
                    string.IsNullOrEmpty(cashierOrder_price.Text))
                {
                    MessageBox.Show("Please select a product first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int qty = (int)cashierOrder_qty.Value;
                if (qty <= 0)
                {
                    MessageBox.Show("Quantity must be greater than zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double price = Convert.ToDouble(cashierOrder_price.Text);
                double total = qty * price;

                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    string stockQuery = "SELECT stock FROM products WHERE id = @id";
                    SqlCommand checkStockCmd = new SqlCommand(stockQuery, connect);
                    checkStockCmd.Parameters.AddWithValue("@id", cashierOrder_productID.Text);
                    int currentStock = Convert.ToInt32(checkStockCmd.ExecuteScalar());

                    if (qty > currentStock)
                    {
                        MessageBox.Show($"Not enough stock! Available: {currentStock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string insertQuery = @"INSERT INTO orders (prod_id, prod_name, qty, orig_price, total_price, order_date)
                                           VALUES (@prod_id, @prod_name, @qty, @orig_price, @total_price, @order_date)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connect);
                    insertCmd.Parameters.AddWithValue("@prod_id", cashierOrder_productID.Text);
                    insertCmd.Parameters.AddWithValue("@prod_name", label5cashierOrder_ProdName.Text);
                    insertCmd.Parameters.AddWithValue("@qty", qty);
                    insertCmd.Parameters.AddWithValue("@orig_price", price);
                    insertCmd.Parameters.AddWithValue("@total_price", total);
                    insertCmd.Parameters.AddWithValue("@order_date", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    int newStock = currentStock - qty;
                    string updateQuery = "UPDATE products SET stock = @newStock WHERE id = @id";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connect);
                    updateCmd.Parameters.AddWithValue("@newStock", newStock);
                    updateCmd.Parameters.AddWithValue("@id", cashierOrder_productID.Text);
                    updateCmd.ExecuteNonQuery();

                    connect.Close();
                }

               

                DisplayAllOrders();
                displayallAvailableProducts();
                CalculateTotalPrice(); // ✅ added: update total after adding
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAllOrders()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    string query = "SELECT id, prod_name, qty, orig_price, total_price, order_date FROM orders";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.ReadOnly = true;
                }

                CalculateTotalPrice(); // ✅ added: recalc after reload
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void cashierOrder_totalPrice_Click(object sender, EventArgs e)
        {
            CalculateTotalPrice(); // ✅ just use your method here now
        }

        // ✅ Method to automatically calculate total
        private void CalculateTotalPrice()
        {
            double totalSum = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["total_price"].Value != null)
                {
                    string value = row.Cells["total_price"].Value.ToString();
                    value = value.Replace("₱", "").Replace(",", "").Trim();

                    if (double.TryParse(value, out double price))
                    {
                        totalSum += price;
                    }
                }
            }

            cashierOrder_totalPrice.Text = $"₱ {totalSum:N2}";
        }

        private void cashierOrder_removeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return; // just exit silently if nothing is selected
            }

            try
            {
                int orderId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);

                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM orders WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, connect);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }

                // Refresh the data and recalc totals immediately
                DisplayAllOrders();
                CalculateTotalPrice();
            }
            catch
            {
                // silently ignore errors (optional: log them if needed)
            }
        }

        private void cashierOrder_clearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM orders";
                    SqlCommand cmd = new SqlCommand(deleteQuery, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }

                // Refresh data and recalc totals immediately
                DisplayAllOrders();
                CalculateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label10_Click(object sender, EventArgs e) { }

        private void cashierOrder_ammount_TextChanged(object sender, EventArgs e)
        {
            // Auto calculate change whenever amount changes
            try
            {
                string totalText = cashierOrder_totalPrice.Text.Replace("₱", "").Replace(",", "").Trim();
                double total = 0, amount = 0;

                double.TryParse(totalText, out total);
                double.TryParse(cashierOrder_ammount.Text, out amount);

                double change = amount - total;

                // Only show change if amount >= total
                if (amount >= total)
                {
                    cashierOrder_change.Text = $"₱ {change:N2}";
                }
                else
                {
                    cashierOrder_change.Text = "₱ 0.00";
                }
            }
            catch
            {
                cashierOrder_change.Text = "₱ 0.00";
            }
        }

        private void cashierOrder_change_Click(object sender, EventArgs e)
        {
            try
            {
                string totalText = cashierOrder_totalPrice.Text.Replace("₱", "").Replace(",", "").Trim();
                double total = 0, amount = 0;

                double.TryParse(totalText, out total);
                double.TryParse(cashierOrder_ammount.Text, out amount);

                double change = amount - total;

                if (change < 0)
                {
                    MessageBox.Show("Insufficient payment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cashierOrder_change.Text = $"₱ {change:N2}";
                    MessageBox.Show($"Change: ₱ {change:N2}", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cashierOrder_payOrders_Click(object sender, EventArgs e)
        {
            try
            {
                double totalAmount = 0;
                double amountPaid = 0;
                double change = 0;

                string totalText = cashierOrder_totalPrice.Text.Replace("₱", "").Replace(",", "").Trim();
                double.TryParse(totalText, out totalAmount);
                double.TryParse(cashierOrder_ammount.Text, out amountPaid);

                change = amountPaid - totalAmount;

                if (amountPaid < totalAmount)
                {
                    MessageBox.Show("Not enough payment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Declare outside so it can be used later
                string customerId = Guid.NewGuid().ToString().Substring(0, 8);

                using (SqlConnection connect = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    string insertCustomer = @"INSERT INTO customers 
            (customer_id, total_price, amount, change_amount, order_date)
            VALUES (@customer_id, @total_price, @amount, @change_amount, @order_date)";

                    SqlCommand insertCmd = new SqlCommand(insertCustomer, connect);
                    insertCmd.Parameters.AddWithValue("@customer_id", customerId);
                    insertCmd.Parameters.AddWithValue("@total_price", totalAmount);
                    insertCmd.Parameters.AddWithValue("@amount", amountPaid);
                    insertCmd.Parameters.AddWithValue("@change_amount", change);
                    insertCmd.Parameters.AddWithValue("@order_date", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    connect.Close();
                }

                // ✅ Now these can use customerId
                cashierOrder_change.Text = $"₱ {change:N2}";
                MessageBox.Show($"Payment successful!\nCustomer ID: {customerId}\nChange: ₱ {change:N2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int rowIndex = 0;

        private void cashierOrder_receipt_Click(object sender, EventArgs e)
        {
            // Prevent duplicate handlers
            printDocument1.PrintPage -= new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            printDocument1.BeginPrint -= new PrintEventHandler(printDocument1_BeginPrint);
            printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

            // Show print preview
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // ✅ Calculate total from DataGridView
            double totalPrice = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["total_price"].Value != null &&
                    double.TryParse(row.Cells["total_price"].Value.ToString(), out double val))
                {
                    totalPrice += val;
                }
            }

            // ----- Variables -----
            float y = 0;
            int colWidth = 120;
            int headerMargin = 10;
            int tableMargin = 20;

            Font font = new Font("Arial", 12);
            Font bold = new Font("Arial", 12, FontStyle.Bold);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font labelFont = new Font("Arial", 14, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat alignCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // ----- Header -----
            string headerText = "STORE RECEIPT";
            y = margin + headerMargin;
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black,
                e.MarginBounds.Left + (e.MarginBounds.Width / 2), y, alignCenter);
            y += headerFont.GetHeight(e.Graphics) + 30;

            // ----- Table Header -----
            string[] header = { "Product Name", "Qty", "Price", "Total" };
            for (int q = 0; q < header.Length; q++)
            {
                e.Graphics.DrawString(header[q], bold, Brushes.Black,
                    e.MarginBounds.Left + q * colWidth, y, alignCenter);
            }
            y += bold.GetHeight(e.Graphics) + 10;

            // Draw line under table header
            e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (colWidth * header.Length), y);
            y += 10;

            // ----- Table Body -----
            while (rowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                // measure height needed for this row
                float rowHeight = font.GetHeight(e.Graphics);
                for (int q = 0; q < dataGridView2.Columns.Count && q < header.Length; q++)
                {
                    object cellValue = row.Cells[q].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    SizeF sz = e.Graphics.MeasureString(cell, font, colWidth);
                    if (sz.Height > rowHeight) rowHeight = sz.Height;
                }

                // draw cells for this row
                for (int q = 0; q < dataGridView2.Columns.Count && q < header.Length; q++)
                {
                    object cellValue = row.Cells[q].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    e.Graphics.DrawString(cell, font, Brushes.Black,
                        e.MarginBounds.Left + q * colWidth, y, new StringFormat(StringFormatFlags.LineLimit));
                }

                y += rowHeight + 5f; // move down
                rowIndex++;

                // check if we need a new page
                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom - 150)
                {
                    e.HasMorePages = true;
                    return;
                }
            } // <-- end of product loop

            // ✅ Totals start after last row
            y += 20;
            e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (colWidth * header.Length), y);
            y += 25;

            double amountPaid = 0, change = 0;
            double.TryParse(cashierOrder_ammount.Text, out amountPaid);
            string changeText = cashierOrder_change.Text.Replace("₱", "").Replace(",", "").Trim();
            double.TryParse(changeText, out change);

            e.Graphics.DrawString($"Total Price: ₱ {totalPrice:N2}", labelFont, Brushes.Black, e.MarginBounds.Left, y);
            y += 30;
            e.Graphics.DrawString($"Amount: ₱ {amountPaid:N2}", labelFont, Brushes.Black, e.MarginBounds.Left, y);
            y += 30;
            e.Graphics.DrawString($"Change: ₱ {change:N2}", labelFont, Brushes.Black, e.MarginBounds.Left, y);
            y += 40;

            e.Graphics.DrawString(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), font, Brushes.Black, e.MarginBounds.Left, y);
            y += 25;
            e.Graphics.DrawString("Thank you for shopping with us!", bold, Brushes.Black, e.MarginBounds.Left, y);




        }
    }
}
