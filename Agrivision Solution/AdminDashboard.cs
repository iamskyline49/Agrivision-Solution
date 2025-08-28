using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class AdminDashboard : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=True";

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = comboRole.SelectedItem.ToString();
            string query = "";

            // Determine the table based on the selected role
            if (selectedRole == "Farmer")
                query = "SELECT FarmerID, Name, Username, Password, Email, Phone, Address FROM FarmerTable";
            else if (selectedRole == "Vendor")
                query = "SELECT VendorID, Name, Username, Password, Email, Phone, Address, EIIN, TIN, CompanyName FROM VendorTable";
            else if (selectedRole == "General Customer")
                query = "SELECT CustomerID, Name, Username, Password, Email, Phone, Address FROM GeneralCustomerTable";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = comboRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role before deleting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idColumn = selectedRole == "Farmer" ? "FarmerID" :
                              selectedRole == "Vendor" ? "VendorID" :
                              "CustomerID";

            string tableName = selectedRole == "Farmer" ? "FarmerTable" :
                               selectedRole == "Vendor" ? "VendorTable" :
                               "GeneralCustomerTable";

            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[idColumn].Value);

            string deleteQuery = $"DELETE FROM {tableName} WHERE {idColumn} = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@Id", selectedId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload data after deletion
                    btnLoad.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to manage.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = comboRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role before managing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = dataGridView1.SelectedRows[0].Cells["Username"].Value.ToString();

            if (selectedRole == "Farmer" || selectedRole == "General Customer")
            {
                this.Hide();
                Profile profileForm = new Profile(username, selectedRole);
                profileForm.ShowDialog();
                this.Show();

            }
            else if (selectedRole == "Vendor")
            {
                this.Hide();
                VendorProfile vendorProfileForm = new VendorProfile(username);
                vendorProfileForm.ShowDialog();
                this.Show(); 
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.ShowDialog();
            this.Show();
            btnLoad_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           CreatePostForm w = new CreatePostForm();
            w.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            PostDetails w = new PostDetails();
            w.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ItemsList itemsList = new ItemsList();
            itemsList.Show();
        }
    }
}
