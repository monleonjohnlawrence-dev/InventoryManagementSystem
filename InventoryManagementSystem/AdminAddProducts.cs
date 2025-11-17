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
using System.IO;

namespace InventoryManagementSystem
{
    public partial class AdminAddProducts : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAddProducts()
        {
            InitializeComponent();
            displaySuppliers();
            displayAllProducts();

          
            AddProducts_dataGrid.CellClick += AddProducts_dataGrid_CellClick;
        }

    
        public void displayAllProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listData = apData.AllProductsData();
            AddProducts_dataGrid.DataSource = listData;
            AddProducts_dataGrid.AllowUserToAddRows = false;

        }

    
        public bool checkEmptyFields()
        {
            return (string.IsNullOrWhiteSpace(AddProducts_prodID.Text)
                || string.IsNullOrWhiteSpace(AddProducts_prodName.Text)
                || AddProducts_supplier.SelectedIndex == -1
                || string.IsNullOrWhiteSpace(AddProducts_price.Text)
                || string.IsNullOrWhiteSpace(AddProducts_stock.Text)
                || AddProducts_status.SelectedIndex == -1
                || AddProducts_imageView.Image == null);
        }

       
        public void displaySuppliers()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT supplier_name FROM Suppliers";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        AddProducts_supplier.DataSource = table;
                        AddProducts_supplier.DisplayMember = "supplier_name";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading suppliers: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

       
        private void AddProducts_addBtn_Click(object sender, EventArgs e)
        {
            if (checkEmptyFields())
            {
                MessageBox.Show("Please fill all fields!", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM Products WHERE prod_id = @prodID";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodID", AddProducts_prodID.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show($"Product ID {AddProducts_prodID.Text.Trim()} already exists.",
                                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Copy image to folder
                        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string relativePath = Path.Combine("Product_Directory", AddProducts_prodID.Text.Trim() + ".jpg");
                        string path = Path.Combine(baseDirectory, relativePath);
                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                            Directory.CreateDirectory(directoryPath);

                        File.Copy(AddProducts_imageView.ImageLocation, path, true);

                        // Insert product
                        string insertData = "INSERT INTO Products (prod_id, prod_name, supplier, price, stock, image_path, status, date_insert) " +
                                            "VALUES(@prodID, @prodName, @sup, @price, @stock, @path, @status, @date)";

                        using (SqlCommand insertD = new SqlCommand(insertData, connect))
                        {
                            insertD.Parameters.AddWithValue("@prodID", AddProducts_prodID.Text.Trim());
                            insertD.Parameters.AddWithValue("@prodName", AddProducts_prodName.Text.Trim());
                            insertD.Parameters.AddWithValue("@sup", AddProducts_supplier.Text.Trim());
                            insertD.Parameters.AddWithValue("@price", AddProducts_price.Text.Trim());
                            insertD.Parameters.AddWithValue("@stock", AddProducts_stock.Text.Trim());
                            insertD.Parameters.AddWithValue("@path", path);
                            insertD.Parameters.AddWithValue("@status", AddProducts_status.Text.Trim());
                            insertD.Parameters.AddWithValue("@date", DateTime.Today);

                            insertD.ExecuteNonQuery();
                        }

                        MessageBox.Show("Product added successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayAllProducts();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding product: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Update product
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkEmptyFields())
            {
                MessageBox.Show("Please fill all fields before updating.",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string updateQuery = "UPDATE Products SET " +
                                         "prod_name=@prodName, supplier=@sup, price=@price, stock=@stock, " +
                                         "image_path=@path, status=@status, date_insert=@date " +
                                         "WHERE prod_id=@prodID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodID", AddProducts_prodID.Text.Trim());
                        cmd.Parameters.AddWithValue("@prodName", AddProducts_prodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@sup", AddProducts_supplier.Text.Trim());
                        cmd.Parameters.AddWithValue("@price", AddProducts_price.Text.Trim());
                        cmd.Parameters.AddWithValue("@stock", AddProducts_stock.Text.Trim());
                        cmd.Parameters.AddWithValue("@path", AddProducts_imageView.ImageLocation ?? "");
                        cmd.Parameters.AddWithValue("@status", AddProducts_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Product updated successfully!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayAllProducts();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Product ID not found.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // ✅ Delete product
        private void AddProducts_removeBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddProducts_prodID.Text))
            {
                MessageBox.Show("Please enter a Product ID to remove.",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string deleteQuery = "DELETE FROM Products WHERE prod_id=@prodID";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodID", AddProducts_prodID.Text.Trim());
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Product removed successfully!",
                                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayAllProducts();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Product ID not found.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing product: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        // ✅ Clear fields
        private void AddProducts_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            AddProducts_prodID.Text = "";
            AddProducts_prodName.Text = "";
            AddProducts_supplier.SelectedIndex = -1;
            AddProducts_price.Text = "";
            AddProducts_stock.Text = "";
            AddProducts_status.SelectedIndex = -1;
            AddProducts_imageView.Image = null;
        }

        // ✅ Image import
        private void AddProducts_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AddProducts_imageView.ImageLocation = dialog.FileName;
                    AddProducts_imageView.Image = Image.FromFile(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Connection check
        public bool checkConnection()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    connect.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ✅ When a user clicks a product in the grid, fill in the fields
        private void AddProducts_dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = AddProducts_dataGrid.Rows[e.RowIndex];

                AddProducts_prodID.Text = row.Cells["ProdID"].Value?.ToString();
                AddProducts_prodName.Text = row.Cells["ProdName"].Value?.ToString();
                AddProducts_supplier.Text = row.Cells["Supplier"].Value?.ToString();
                AddProducts_price.Text = row.Cells["Price"].Value?.ToString();
                AddProducts_stock.Text = row.Cells["Stock"].Value?.ToString();
                AddProducts_status.Text = row.Cells["Status"].Value?.ToString();

                string imagePath = row.Cells["ImagePath"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    AddProducts_imageView.Image = Image.FromFile(imagePath);
                    AddProducts_imageView.ImageLocation = imagePath;
                }
                else
                {
                    AddProducts_imageView.Image = null;
                }
            }
        }
    
    // --- Designer-empty event handlers (add these) ---
private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }

        private void AddProducts_prodID_TextChanged(object sender, EventArgs e) { }
        private void AddProducts_prodName_TextChanged(object sender, EventArgs e) { }
        private void AddProducts_price_TextChanged(object sender, EventArgs e) { }
        private void AddProducts_stock_TextChanged(object sender, EventArgs e) { }
        private void AddProducts_status_SelectedIndexChanged(object sender, EventArgs e) { }
        private void AddProducts_supplier_SelectedIndexChanged(object sender, EventArgs e) { }

        private void AddProducts_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}