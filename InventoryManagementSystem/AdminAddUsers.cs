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
    public partial class AdminAddUsers : UserControl
    {
        private int getID = -1; // Track selected user ID

        public AdminAddUsers()
        {
            InitializeComponent();
            dissplayAllUsers();
        }

        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public void dissplayAllUsers()
        {
            UsersData uData = new UsersData();
            List<UsersData> listData = uData.AllUserData();
            dataGridView1.DataSource = listData;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        // ================= ADD USER =================
        private void addUsers_addBtn_Click(object sender, EventArgs e)
        {
            if (addUsers_username.Text == "" || addUsers_password.Text == "" || addUsers_role.SelectedIndex == -1 || addUsers_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connect.Open();

                // Check if username already exists
                string checkUsername = "SELECT * FROM users WHERE username = @usern";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show(addUsers_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string insertData = "INSERT INTO users(username, password, role, status, date) VALUES(@usern, @pass, @role, @status, @date)";
                        using (SqlCommand insertD = new SqlCommand(insertData, connect))
                        {
                            insertD.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                            insertD.Parameters.AddWithValue("@pass", addUsers_password.Text.Trim());
                            insertD.Parameters.AddWithValue("@role", addUsers_role.SelectedItem.ToString());
                            insertD.Parameters.AddWithValue("@status", addUsers_status.SelectedItem.ToString());
                            insertD.Parameters.AddWithValue("@date", DateTime.Today);

                            insertD.ExecuteNonQuery();
                            clearFields();
                            dissplayAllUsers(); // Refresh DataGridView
                            MessageBox.Show("User added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool checkConnection()
        {
            return connect.State == ConnectionState.Open;
        }

        private void addUsers_status_SelectedIndexChanged(object sender, EventArgs e) { }

        public void clearFields()
        {
            addUsers_username.Text = "";
            addUsers_password.Text = "";
            addUsers_role.SelectedIndex = -1;
            addUsers_status.SelectedIndex = -1;
            getID = -1; // reset selected ID
        }

        private void addUsers_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // ================= UPDATE USER =================
        private void addUsers_updateBtn_Click(object sender, EventArgs e)
        {
            if (addUsers_username.Text == "" || addUsers_password.Text == "" || addUsers_role.SelectedIndex == -1 || addUsers_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (getID == -1)
            {
                MessageBox.Show("Please select a user to update", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this user? " + getID + "?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                connect.Open();

                // Exclude current user from username check
                string checkUsername = "SELECT * FROM users WHERE username = @usern AND id <> @id";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", getID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show(addUsers_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string updateData = "UPDATE users SET username = @usern, password = @pass, role = @role, status = @status WHERE id = @id";
                        using (SqlCommand updateD = new SqlCommand(updateData, connect))
                        {
                            updateD.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                            updateD.Parameters.AddWithValue("@pass", addUsers_password.Text.Trim());
                            updateD.Parameters.AddWithValue("@role", addUsers_role.SelectedItem.ToString());
                            updateD.Parameters.AddWithValue("@status", addUsers_status.SelectedItem.ToString());
                            updateD.Parameters.AddWithValue("@id", getID);

                            updateD.ExecuteNonQuery();
                            clearFields();
                            dissplayAllUsers(); // Refresh DataGridView
                            MessageBox.Show("User updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value; // store selected user ID
                addUsers_username.Text = row.Cells[1].Value.ToString();
                addUsers_password.Text = row.Cells[2].Value.ToString();
                addUsers_role.Text = row.Cells[3].Value.ToString();
                addUsers_status.Text = row.Cells[4].Value.ToString();
            }
        }

        private void addUsers_removeBtn_Click(object sender, EventArgs e)
        {
            if (getID == -1)
            {
                MessageBox.Show("Please select a user to remove", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this user? " + getID + "?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                connect.Open();

                string deleteData = "DELETE FROM users WHERE id = @id";
                using (SqlCommand deleteCmd = new SqlCommand(deleteData, connect))
                {
                    deleteCmd.Parameters.AddWithValue("@id", getID);
                    deleteCmd.ExecuteNonQuery();

                    clearFields();
                    dissplayAllUsers(); // Refresh DataGridView
                    MessageBox.Show("User removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
