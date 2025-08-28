using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class ViewOrderVGC : Form
    {
        private string BuyerUsername;
        private string OrderType;
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public ViewOrderVGC(string buyerUsername, string orderType)
        {
            InitializeComponent();
            BuyerUsername = buyerUsername;
            OrderType = orderType;
        }

        private void ViewOrderVGC_Load(object sender, EventArgs e)
        {
            LoadOrders();
            PopulateComboBoxColumns();
        }

        private void LoadOrders()
        {
            if(OrderType == "Canceled")
            {
                btnConfirm.Visible = false;
            }
            string statusFilter = OrderType == "Confirmed" ? "Ready For Delivery" : "Canceled";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT TransactionID, ItemID, BuyerUsername, BuyerRole, Quantity, TotalAmount, PaymentMethod, OrderDate, Status 
                        FROM TransactionTable 
                        WHERE BuyerUsername = @BuyerUsername AND Status = @StatusFilter";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BuyerUsername", BuyerUsername);
                        cmd.Parameters.AddWithValue("@StatusFilter", statusFilter);

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
            comboColumns.Items.Add("ItemID");
            comboColumns.Items.Add("BuyerUsername");
            comboColumns.Items.Add("Status");

            if (comboColumns.Items.Count > 0)
            {
                comboColumns.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to mark as delivered.", "Confirm Delivery", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int transactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TransactionID"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE TransactionTable SET Status = 'Delivered' WHERE TransactionID = @TransactionID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Order marked as delivered successfully.", "Confirm Delivery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string statusFilter = OrderType == "Confirmed" ? "Ready For Delivery" : "Canceled";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $@"
                        SELECT TransactionID, ItemID, BuyerUsername, BuyerRole, Quantity, TotalAmount, PaymentMethod, OrderDate, Status 
                        FROM TransactionTable 
                        WHERE BuyerUsername = @BuyerUsername AND Status = @StatusFilter AND {searchColumn} LIKE @SearchText";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BuyerUsername", BuyerUsername);
                        cmd.Parameters.AddWithValue("@StatusFilter", statusFilter);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}