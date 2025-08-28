using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class VendorProfile : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=True";
        private string username;

        public VendorProfile(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadVendorData();
            btnSave.Visible = false;  
            ChangePic.Visible = false;
            DisableFields();
        }

        private void VendorProfile_Load(object sender, EventArgs e)
        {
            LoadVendorData();
        }

        // Load vendor data from the database
        private void LoadVendorData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT Name, Username, Email, Phone, Address, EIIN, TIN, CompanyName, ProfilePicture
                        FROM VendorTable
                        WHERE Username = @Username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameTextBox.Text = reader["Name"].ToString();
                            UsernameTextBox.Text = reader["Username"].ToString();
                            EmailTextBox.Text = reader["Email"].ToString();
                            PhoneTextBox.Text = reader["Phone"].ToString();
                            AddressTextBox.Text = reader["Address"].ToString();
                            EiinTextBox.Text = reader["EIIN"].ToString();
                            TinTextBox.Text = reader["TIN"].ToString();
                            CompanyNameTextBox.Text = reader["CompanyName"].ToString();

                            // Load profile picture if it exists
                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imgData))
                                {
                                    profilePic.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                profilePic.Image = null; // Default image
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vendor data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vendor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enable fields for editing
        private void EnableFields()
        {
            NameTextBox.ReadOnly = false;
            UsernameTextBox.ReadOnly = true; // Username should not be editable
            EmailTextBox.ReadOnly = false;
            PhoneTextBox.ReadOnly = false;
            AddressTextBox.ReadOnly = false;
            EiinTextBox.ReadOnly = false;
            TinTextBox.ReadOnly = false;
            CompanyNameTextBox.ReadOnly = false;
            ChangePic.Enabled = true;
            btnSave.Enabled = true;
        }

        // Disable fields after saving
        private void DisableFields()
        {
            NameTextBox.ReadOnly = true;
            UsernameTextBox.ReadOnly = true;
            EmailTextBox.ReadOnly = true;
            PhoneTextBox.ReadOnly = true;
            AddressTextBox.ReadOnly = true;
            EiinTextBox.ReadOnly = true;
            TinTextBox.ReadOnly = true;
            CompanyNameTextBox.ReadOnly = true;
            ChangePic.Enabled = false;
            btnSave.Enabled = false;
        }

        // Edit button click event
        private void EditInfo_Click(object sender, EventArgs e)
        {
            EnableFields();
            EditInfo.Visible = false; // Hide Edit button
            btnSave.Visible = true;  // Show Save button
            ChangePic.Visible = true; // Show Change Profile Picture button
        }

        // Save button click event to save edited data
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE VendorTable
                        SET Name = @Name,
                            Email = @Email,
                            Phone = @Phone,
                            Address = @Address,
                            EIIN = @EIIN,
                            TIN = @TIN,
                            CompanyName = @CompanyName
                        WHERE Username = @Username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@Phone", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                    cmd.Parameters.AddWithValue("@EIIN", EiinTextBox.Text);
                    cmd.Parameters.AddWithValue("@TIN", TinTextBox.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", CompanyNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Username", username);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vendor data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DisableFields();
                    btnSave.Visible = false; 
                    EditInfo.Visible = true; 
                    ChangePic.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving vendor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Change profile picture button click event
        private void ChangePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    profilePic.Image = Image.FromFile(dialog.FileName);
                }
            }
        }

        // Save profile picture button click event
        private void button1_Click(object sender, EventArgs e)
        {
            if (profilePic.Image != null)
            {
                byte[] imgData;
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePic.Image.Save(ms, profilePic.Image.RawFormat);
                    imgData = ms.ToArray();
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE VendorTable SET ProfilePicture = @ProfilePicture WHERE Username = @Username";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@ProfilePicture", imgData);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Profile picture updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No profile picture selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Back button click event
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void VendorProfile_Load_1(object sender, EventArgs e)
        {

        }
    }
}
