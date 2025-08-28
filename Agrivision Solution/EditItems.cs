using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class EditItems : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        private int itemId;
        private string userType;
        private string userName;

        public EditItems(int itemId , string userType, string userName)
        {
            InitializeComponent();
            this.itemId = itemId;
            this.userType = userType;
            this.userName = userName;
        }

    
        private void LoadItemData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT Name, Category, Price, Quantity, Description, ItemImage FROM ItemTable WHERE ItemID = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            NameTextBox.Text = reader["Name"].ToString();
                            comboCategory.Text = reader["Category"].ToString();
                            PriceTextBox.Text = reader["Price"].ToString();
                            QuantityTextBox.Text = reader["Quantity"].ToString();
                            DescriptionTextBox.Text = reader["Description"].ToString();

                            if (reader["ItemImage"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["ItemImage"];
                                using (MemoryStream ms = new MemoryStream(imgData))
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
                            MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading item data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE ItemTable SET Name = @Name, Category = @Category, Price = @Price, Quantity = @Quantity, Description = @Description WHERE ItemID = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Category", comboCategory.Text);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(PriceTextBox.Text));
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(QuantityTextBox.Text));
                        cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@ItemID", itemId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();   

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        private void itemPicUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    itemPicture.Image = Image.FromFile(openFileDialog.FileName);

                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string query = "UPDATE ItemTable SET ItemImage = @ItemImage WHERE ItemID = @ItemID";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                if (itemPicture.Image != null)
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        itemPicture.Image.Save(ms, itemPicture.Image.RawFormat);
                                        cmd.Parameters.AddWithValue("@ItemImage", ms.ToArray());
                                    }
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@ItemImage", DBNull.Value);
                                }

                                cmd.Parameters.AddWithValue("@ItemID", itemId);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Item image updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating the item image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (userType == "Admin")
            {
                AdminDashboard adminDashboard= new AdminDashboard();
                adminDashboard.Show();       
            }
            else
            {
                FarmerItemManagement f=new FarmerItemManagement(userName);
                f.Show();
            }
        }

        private void EditItems_Load(object sender, EventArgs e)
        {
            LoadItemData();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
