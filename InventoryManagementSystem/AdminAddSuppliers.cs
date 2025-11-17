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
using System.Data;

namespace InventoryManagementSystem
{
    public partial class AdminAddSuppliers : UserControl
    {
        SqlConnection connect = new SqlConnection(
          @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAddSuppliers()
        {
            InitializeComponent();

            // ✅ Added: make sure grid updates and handles click when control loads
            this.Load += AdminAddSuppliers_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ✅ Added: load event for initializing display
        private void AdminAddSuppliers_Load(object sender, EventArgs e)
        {
            displayAllSuppliers();
        }

        private void addUsers_addBtn_Click(object sender, EventArgs e)
        {
            if (addSuppliers_supply.Text == "" || addSuppliers_contact.Text == "")
            {
                MessageBox.Show("Empty Fields !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                            connect.Open();

                        string checkTable = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Suppliers' AND xtype='U') " +
                                            "CREATE TABLE Suppliers (id INT PRIMARY KEY IDENTITY(1,1), supplier_name VARCHAR(MAX), contact_number VARCHAR(MAX))";
                        using (SqlCommand createCmd = new SqlCommand(checkTable, connect))
                        {
                            createCmd.ExecuteNonQuery();
                        }

                        string checkCat = "SELECT * FROM Suppliers WHERE supplier_name = @sup";

                        using (SqlCommand cmd = new SqlCommand(checkCat, connect))
                        {
                            cmd.Parameters.AddWithValue("@sup", addSuppliers_supply.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Supplier: " + addSuppliers_supply.Text.Trim() + " already exists",
                                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO Suppliers (supplier_name, contact_number) VALUES (@sup, @con)";

                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {
                                    insertD.Parameters.AddWithValue("@sup", addSuppliers_supply.Text.Trim());
                                    insertD.Parameters.AddWithValue("@con", addSuppliers_contact.Text.Trim());

                                    insertD.ExecuteNonQuery();
                                    MessageBox.Show("Supplier added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                    displayAllSuppliers(); // ✅ refresh
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        public bool checkConnection()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    connect.Close();
                    return true;
                }
                else
                {
                    connect.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void clearFields()
        {
            addSuppliers_supply.Text = "";
            addSuppliers_contact.Text = "";
        }

        private void displayAllSuppliers()
        {
            try
            {
                string query = "SELECT * FROM Suppliers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addSupplier_updateBtn_Click(object sender, EventArgs e)
        {
            if (addSuppliers_supply.Text == "" || addSuppliers_contact.Text == "")
            {
                MessageBox.Show("Please select a supplier to update.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string updateData = "UPDATE Suppliers SET contact_number = @con WHERE supplier_name = @sup";

                using (SqlCommand cmd = new SqlCommand(updateData, connect))
                {
                    cmd.Parameters.AddWithValue("@sup", addSuppliers_supply.Text.Trim());
                    cmd.Parameters.AddWithValue("@con", addSuppliers_contact.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Supplier updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayAllSuppliers();
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show("No supplier found with that name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update supplier: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void addSupplier_removeBtn_Click(object sender, EventArgs e)
        {
            if (addSuppliers_supply.Text == "")
            {
                MessageBox.Show("Please enter or select a supplier to remove.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                DialogResult confirm = MessageBox.Show("Are you sure you want to remove this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string deleteData = "DELETE FROM Suppliers WHERE supplier_name = @sup";

                    using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                    {
                        cmd.Parameters.AddWithValue("@sup", addSuppliers_supply.Text.Trim());
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Supplier removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayAllSuppliers();
                            clearFields();
                        }
                        else
                        {
                            MessageBox.Show("No supplier found with that name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove supplier: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void addSupplier_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            MessageBox.Show("Fields cleared!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                addSuppliers_supply.Text = row.Cells["supplier_name"].Value.ToString();
                addSuppliers_contact.Text = row.Cells["contact_number"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
