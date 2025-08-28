using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class Marketplace1 : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        string username;
        string role; 

        public Marketplace1(string username, string role)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;
        }

        private void Marketplace1_Load(object sender, EventArgs e)
        {
            if(role == "Farmer")
            {
                btnBuy.Visible = false;
            }
            LoadMarketplaceData(role);
            PopulateComboBoxColumns();
        }

        private void LoadMarketplaceData(string userType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Base query
                    string query = "SELECT ItemID, Name, Category, Price, Quantity, Description, FarmerUsername FROM ItemTable";

                    // Add conditions based on user type
                    if (userType == "GeneralCustomer")
                    {
                        query += " WHERE Quantity > 0 ORDER BY AddedTime DESC"; // Show items in stock, most recently added first
                    }
                    else if (userType == "Vendor")
                    {
                        query += " ORDER BY Quantity DESC"; // Show items with the highest quantity first
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading marketplace data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateComboBoxColumns()
        {
            comboColumns.Items.Clear(); // Clear existing items

            // Manually adding column names (match database column names)
            comboColumns.Items.Add("Name");
            comboColumns.Items.Add("Category");
            comboColumns.Items.Add("Price");
            comboColumns.Items.Add("Quantity");
            comboColumns.Items.Add("Description");
            comboColumns.Items.Add("FarmerUsername");

            if (comboColumns.Items.Count > 0)
            {
                comboColumns.SelectedIndex = 0; // Select the first column by default
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBox.Text))
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboColumns.SelectedItem == null)
            {
                MessageBox.Show("Please select a column to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchColumn = comboColumns.SelectedItem.ToString();
            string searchText = txtSearchBox.Text;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"SELECT ItemID, Name, Category, Price, Quantity, Description, FarmerUsername FROM ItemTable WHERE {searchColumn} LIKE @SearchText";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
              
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to view.", "View Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the ItemID of the selected row
            int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ItemID"].Value);

            // Open the ViewItem form and pass the selected ItemID
            ViewItem viewItemForm = new ViewItem(selectedItemId);
            viewItemForm.ShowDialog();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to buy.", "Buy Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get the ItemID of the selected row
                int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ItemID"].Value);

                // Open the PlaceOrder form and pass the selected ItemID, username, and role
                PlaceOrder placeOrderForm = new PlaceOrder(selectedItemId.ToString(), username, role);
                placeOrderForm.ShowDialog();

                // Optionally, reload the marketplace data after the order is placed
                LoadMarketplaceData(role);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the order form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
