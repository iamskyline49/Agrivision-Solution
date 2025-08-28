using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class FarmerAddItem : Form
    {
        string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        private string FarmerUsername;

        public FarmerAddItem(string username)
        {
            InitializeComponent();
            FarmerUsername = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void itemPicUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    itemPicture.Image = Image.FromFile(dialog.FileName); 
                }
            }
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = @"INSERT INTO ItemTable (Name, Category, Price, Quantity, Description, ItemImage, FarmerUsername)
                                         VALUES (@Name, @Category, @Price, @Quantity, @Description, @ItemImage, @FarmerUsername)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            
                            cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                            cmd.Parameters.AddWithValue("@Category", comboCategory.Text);
                            cmd.Parameters.AddWithValue("@Price", decimal.Parse(PriceTextBox.Text));
                            cmd.Parameters.AddWithValue("@Quantity", int.Parse(QuantityTextBox.Text));
                            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);
                            cmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);

                           
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

                            cmd.ExecuteNonQuery(); 
                            MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(comboCategory.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out _) || !int.TryParse(QuantityTextBox.Text, out _))
            {
                MessageBox.Show("Please enter valid numeric values for Price and Quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            NameTextBox.Text = string.Empty;
            comboCategory.Text = string.Empty;
            PriceTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            itemPicture.Image = null; // Clear the picture box
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
