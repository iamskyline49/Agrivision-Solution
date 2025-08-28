using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class Profile : Form
    {
        string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public string LoggedInUsername { get; set; }
        public string UserRole { get; set; }
        private bool isProfilePicChanged = false;  // Track if the profile picture is changed

        public Profile(string username, string role)
        {
            InitializeComponent();
            LoggedInUsername = username;
            UserRole = role;
            UsernameTextBox.Text = username;    
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadUserData();
            btnSave.Visible = false;
            ChangePic.Visible = false;
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = string.Empty;

                    if (UserRole == "Farmer")
                    {
                        query = "SELECT Name, Email, Phone, Address, ProfilePicture FROM FarmerTable WHERE Username = @Username";
                    }
                    else if (UserRole == "General Customer")
                    {
                        query = "SELECT Name, Email, Phone, Address, ProfilePicture FROM GeneralCustomerTable WHERE Username = @Username";
                    }
                    else
                    {
                        MessageBox.Show("Invalid role for this profile page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", LoggedInUsername);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            NameTextBox.Text = reader["Name"].ToString();
                            EmailTextBox.Text = reader["Email"].ToString();
                            PhoneTextBox.Text = reader["Phone"].ToString();
                            AddressTextBox.Text = reader["Address"].ToString();

                            // Load profile picture
                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imgData))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableFields()
        {
            NameTextBox.ReadOnly = false;
            EmailTextBox.ReadOnly = false;
            PhoneTextBox.ReadOnly = false;
            AddressTextBox.ReadOnly = false;
            ChangePic.Visible = true;
        }

        private void DisableFields()
        {
            NameTextBox.ReadOnly = true;
            EmailTextBox.ReadOnly = true;
            PhoneTextBox.ReadOnly = true;
            AddressTextBox.ReadOnly = true;
            ChangePic.Visible = false;
        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            EnableFields();
            EditInfo.Visible = false;
            btnSave.Visible = true;
            UsernameTextBox.Text = LoggedInUsername;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = string.Empty;

                    if (UserRole == "Farmer")
                    {
                        query = "UPDATE FarmerTable SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE Username = @Username";
                    }
                    else if (UserRole == "General Customer")
                    {
                        query = "UPDATE GeneralCustomerTable SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE Username = @Username";
                    }
                    else
                    {
                        MessageBox.Show("Invalid role for this profile page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTextBox.Text);
                        cmd.Parameters.AddWithValue("@Phone", PhoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", LoggedInUsername);

                        // Execute the update query for non-profile picture fields
                        cmd.ExecuteNonQuery();
                    }

                    // Now update the profile picture if it was changed
                    if (isProfilePicChanged)
                    {
                        string updatePicQuery = string.Empty;

                        if (UserRole == "Farmer")
                        {
                            updatePicQuery = "UPDATE FarmerTable SET ProfilePicture = @ProfilePicture WHERE Username = @Username";
                        }
                        else if (UserRole == "General Customer")
                        {
                            updatePicQuery = "UPDATE GeneralCustomerTable SET ProfilePicture = @ProfilePicture WHERE Username = @Username";
                        }

                        using (SqlCommand cmdPic = new SqlCommand(updatePicQuery, con))
                        {
                            cmdPic.Parameters.AddWithValue("@Username", LoggedInUsername);

                            // Convert profile picture to byte array
                            if (pictureBox1.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                    cmdPic.Parameters.AddWithValue("@ProfilePicture", ms.ToArray());
                                }

                                cmdPic.ExecuteNonQuery();
                            }
                            else
                            {
                                cmdPic.Parameters.AddWithValue("@ProfilePicture", DBNull.Value);
                                cmdPic.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Disable fields and reset buttons
                    DisableFields();
                    btnSave.Visible = false;
                    EditInfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    isProfilePicChanged = true; // Mark the profile picture as changed
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
