using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class PlaceOrder : Form
    {
        private string ItemId;
        private string Username;
        private string Role;
        private decimal ItemPrice;
        private int AvailableQuantity;
        private string ConnectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public PlaceOrder(string itemId, string username, string role)
        {
            InitializeComponent();
            this.ItemId = itemId;
            this.Username = username;
            this.Role = role;
        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {
            LoadItemDetails();
            comboPaymentMethod.Items.AddRange(new string[] { "Cash", "Credit Card", "Mobile Payment" });
            comboPaymentMethod.SelectedIndex = 0;
        }

        private void LoadItemDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Name, Price, Quantity FROM ItemTable WHERE ItemID = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", ItemId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtId.Text = ItemId;
                                txtItemName.Text = reader["Name"].ToString();
                                ItemPrice = Convert.ToDecimal(reader["Price"]);
                                AvailableQuantity = Convert.ToInt32(reader["Quantity"]);

                                txtPrice.Text = ItemPrice.ToString("0.00");
                            }
                            else
                            {
                                MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                if (quantity > AvailableQuantity)
                {
                    MessageBox.Show("The entered quantity exceeds the available quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Text = AvailableQuantity.ToString();
                }
                else
                {
                    decimal total = quantity * ItemPrice;
                    txtTotal.Text = total.ToString("0.00");
                }
            }
            else
            {
                txtTotal.Text = "0.00";
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quantity > AvailableQuantity)
            {
                MessageBox.Show("Insufficient stock for the requested quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Insert order into the TransactionTable with status 'Invalid'
                    string orderQuery = @"
                        INSERT INTO TransactionTable (ItemID, BuyerUsername, BuyerRole, Quantity, TotalAmount, PaymentMethod, OrderDate, Status)
                        VALUES (@ItemID, @BuyerUsername, @BuyerRole, @Quantity, @TotalAmount, @PaymentMethod, @OrderDate, @Status)";
                    using (SqlCommand cmd = new SqlCommand(orderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", ItemId);
                        cmd.Parameters.AddWithValue("@BuyerUsername", Username);
                        cmd.Parameters.AddWithValue("@BuyerRole", Role);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@TotalAmount", quantity * ItemPrice);
                        cmd.Parameters.AddWithValue("@PaymentMethod", comboPaymentMethod.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", "Invalid");

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order placed successfully! Pending farmer's verification.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
