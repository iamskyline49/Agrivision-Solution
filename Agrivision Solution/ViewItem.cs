using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class ViewItem : Form
    {
        int IderId;
        public ViewItem(int iderId)
        {
            InitializeComponent();
            IderId = iderId;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ViewItem_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ItemTable WHERE ItemID = @ItemID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", IderId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate text fields
                                txtName.Text = reader["Name"].ToString();    
                                txtCategory.Text = reader["Category"].ToString();
                                txtDesc.Text = reader["Description"].ToString(); 
                                txtPrice.Text = reader["Price"].ToString();      
                                txtQuantity.Text = reader["Quantity"].ToString();

                                // Load image if available
                                if (reader["ItemImage"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["ItemImage"]; 
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        itemPicture.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    itemPicture.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No item found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
