using AgriProject;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class AddNewUser : Form
    {
        string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        SqlConnection con;

        public AddNewUser()
        {
            InitializeComponent();
            comboLoad();
        }

        private void comboLoad()
        {
            // Toggle visibility of fields based on the selected role
            if (comboRole.Text == "Vendor")
            {
                cname.Show();
                eiin.Show();
                tin.Show();
                txtEIIN.Show();
                txtTIN.Show();
                txtCNAME.Show();
            }
            else
            {
                cname.Hide();
                eiin.Hide();
                tin.Hide();
                txtEIIN.Hide();
                txtTIN.Hide();
                txtCNAME.Hide();
            }
        }

        private void btnReg_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUserName.Text) ||
                    string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                    comboRole.Text == "Select Role")
                {
                    MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtPass.Text != txtConPass.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string insertQuery = string.Empty;

                    // Build the query based on the selected role
                    if (comboRole.Text == "Farmer")
                    {
                        insertQuery = "INSERT INTO FarmerTable (Name, Username, Password, Email, Phone, Address, ProfilePicture) " +
                                      "VALUES (@Name, @Username, @Password, @Email, @Phone, @Address, @ProfilePicture)";
                    }
                    else if (comboRole.Text == "Vendor")
                    {
                        insertQuery = "INSERT INTO VendorTable (Name, Username, Password, Email, Phone, Address, EIIN, TIN, CompanyName, ProfilePicture) " +
                                      "VALUES (@Name, @Username, @Password, @Email, @Phone, @Address, @EIIN, @TIN, @CompanyName, @ProfilePicture)";
                    }
                    else if (comboRole.Text == "General Customer")
                    {
                        insertQuery = "INSERT INTO GeneralCustomerTable (Name, Username, Password, Email, Phone, Address, ProfilePicture) " +
                                      "VALUES (@Name, @Username, @Password, @Email, @Phone, @Address, @ProfilePicture)";
                    }

                    // Execute the query
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@ProfilePicture", GetProfilePicture());

                        if (comboRole.Text == "Vendor")
                        {
                            cmd.Parameters.AddWithValue("@EIIN", txtEIIN.Text);
                            cmd.Parameters.AddWithValue("@TIN", txtTIN.Text);
                            cmd.Parameters.AddWithValue("@CompanyName", txtCNAME.Text);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); 
                    }
                }

                // Clear fields after successful registration
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetProfilePicture()
        {
            if (profilePic.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePic.Image.Save(ms, profilePic.Image.RawFormat);
                    return ms.ToArray(); // Return byte array
                }
            }
            return null;
        }


        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtConPass.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEIIN.Text = string.Empty;
            txtTIN.Text = string.Empty;
            txtCNAME.Text = string.Empty;
            comboRole.SelectedIndex = 0;
            profilePic.Image = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnShowHide_Click_1(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                txtPass.PasswordChar = '*';
                txtConPass.PasswordChar = '*';
            }
            else
            {
                txtPass.PasswordChar = '\0';
                txtConPass.PasswordChar = '\0';
            }
        }

        private void comboRole_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboLoad();
        }

        private void btnproUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a file dialog to select an image
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Profile Picture";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load the selected image into the PictureBox
                        profilePic.Image = new Bitmap(openFileDialog.FileName);
                        profilePic.SizeMode = PictureBoxSizeMode.StretchImage;

                        // Optionally, store the image path (if needed for debugging)
                        string imagePath = openFileDialog.FileName;
                        MessageBox.Show("Profile picture uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while uploading the profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
