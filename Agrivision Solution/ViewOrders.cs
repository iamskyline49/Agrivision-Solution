using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class ViewOrders : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        string FarmerUsername; 

        public ViewOrders(string farmerUsername)
        {
            InitializeComponent();
            FarmerUsername = farmerUsername;
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
            PopulateComboBoxColumns();
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT T.TransactionID, T.ItemID, I.Name AS ItemName, T.BuyerUsername, T.BuyerRole, T.Quantity, 
                               T.TotalAmount, T.PaymentMethod, T.OrderDate, T.Status
                        FROM TransactionTable T
                        INNER JOIN ItemTable I ON T.ItemID = I.ItemID
                        WHERE I.FarmerUsername = @FarmerUsername";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);

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
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxColumns()
        {
            comboColumns.Items.Clear(); 

            comboColumns.Items.Add("ItemName");
            comboColumns.Items.Add("BuyerUsername");
            comboColumns.Items.Add("Status");
            comboColumns.Items.Add("PaymentMethod");

            if (comboColumns.Items.Count > 0)
            {
                comboColumns.SelectedIndex = 0; 
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
                    string query = $@"
                        SELECT T.TransactionID, T.ItemID, I.Name AS ItemName, T.BuyerUsername, T.BuyerRole, T.Quantity, 
                               T.TotalAmount, T.PaymentMethod, T.OrderDate, T.Status
                        FROM TransactionTable T
                        INNER JOIN ItemTable I ON T.ItemID = I.ItemID
                        WHERE I.FarmerUsername = @FarmerUsername AND {searchColumn} LIKE @SearchText";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to cancel.", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int transactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TransactionID"].Value);
            string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Delivered")
            {
                MessageBox.Show("This order has already been delivered and cannot be canceled.", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE TransactionTable SET Status = 'Canceled' WHERE TransactionID = @TransactionID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Order canceled successfully.", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error canceling order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to confirm.", "Confirm Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int transactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TransactionID"].Value);
            int itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ItemID"].Value);
            int quantity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Quantity"].Value);
            decimal totalAmount = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["TotalAmount"].Value);
            string itemName = dataGridView1.SelectedRows[0].Cells["ItemName"].Value.ToString();
            string currentStatus = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();

            if (currentStatus == "Delivered")
            {
                MessageBox.Show("This order has already been delivered and cannot be confirmed again.", "Confirm Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuantityQuery = "SELECT Quantity FROM ItemTable WHERE ItemID = @ItemID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuantityQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@ItemID", itemId);
                        int availableQuantity = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (availableQuantity < quantity)
                        {
                            MessageBox.Show("Insufficient quantity available to confirm this order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string updateTransactionQuery = "UPDATE TransactionTable SET Status = 'Ready For Delivery' WHERE TransactionID = @TransactionID";
                    using (SqlCommand updateCmd = new SqlCommand(updateTransactionQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        updateCmd.ExecuteNonQuery();
                    }

                    string updateItemQuery = "UPDATE ItemTable SET Quantity = Quantity - @Quantity WHERE ItemID = @ItemID";
                    using (SqlCommand updateItemCmd = new SqlCommand(updateItemQuery, con))
                    {
                        updateItemCmd.Parameters.AddWithValue("@Quantity", quantity);
                        updateItemCmd.Parameters.AddWithValue("@ItemID", itemId);
                        updateItemCmd.ExecuteNonQuery();
                    }

                    string insertSalesQuery = @"
                INSERT INTO Sales (FarmerUsername, ItemID, ItemName, Quantity, TotalAmount, SaleDate)
                VALUES (@FarmerUsername, @ItemID, @ItemName, @Quantity, @TotalAmount, GETDATE())";
                    using (SqlCommand insertCmd = new SqlCommand(insertSalesQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);
                        insertCmd.Parameters.AddWithValue("@ItemID", itemId);
                        insertCmd.Parameters.AddWithValue("@ItemName", itemName);
                        insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                        insertCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Order confirmed successfully.", "Confirm Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }
    }
}
