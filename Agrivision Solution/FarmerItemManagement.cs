using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class FarmerItemManagement : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        private string username;

        public FarmerItemManagement(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadItems();
            PopulateComboBoxColumns();
        }

        private void FarmerItemManagement_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ItemID, Name, Category, Price, Quantity, Description FROM ItemTable WHERE FarmerUsername = @FarmerUsername";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", username);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddItems_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmerAddItem f = new FarmerAddItem(username);
            f.ShowDialog();
            this.Show();
            LoadItems(); // Reload items after adding a new one
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Close the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Delete the selected item
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ItemID"].Value);
                var confirmResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string query = "DELETE FROM ItemTable WHERE ItemID = @ItemID";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@ItemID", itemId);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadItems(); // Reload items after deletion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event can be used for specific actions based on the cell clicked
            LoadItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                int itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ItemID"].Value);
                EditItems viewItemForm = new EditItems(itemId , "Farmer" , username); 
                this.Hide();
                viewItemForm.ShowDialog();
                this.Show(); 
            }
            else
            {
                MessageBox.Show("Please select an item to view.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopulateComboBoxColumns()
        {
            comboColumn.Items.Clear(); // Clear any existing items

            // Add the column names manually (these should match the columns in the database)
            comboColumn.Items.Add("Name");
            comboColumn.Items.Add("Category");
            comboColumn.Items.Add("Price");
            comboColumn.Items.Add("Quantity");
            comboColumn.Items.Add("Description");
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtsearchItem.Text) || string.IsNullOrWhiteSpace(comboColumn.Text))
                {
                    MessageBox.Show("Please select a column and enter a search value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    
                    string query = $"SELECT ItemID, Name, Category, Price, Quantity, Description FROM ItemTable " +
                                   $"WHERE FarmerUsername = @FarmerUsername AND {comboColumn.Text} LIKE @SearchValue";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", username);
                        cmd.Parameters.AddWithValue("@SearchValue", $"%{txtsearchItem.Text}%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the filtered data to the DataGridView
                            dataGridView1.DataSource = dt;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No results found for the given search criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
