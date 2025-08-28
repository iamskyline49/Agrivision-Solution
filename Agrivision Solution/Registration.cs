using AgriProject;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class Registration : Form
    {
        string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        SqlConnection con;

        public Registration()
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
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            
            if (phoneNumber.Length != 11)
            {
                return false;
            }

            if (!phoneNumber.All(char.IsDigit))
            {
                return false;
            }

            string[] validPatterns = { "018", "015", "013", "017", "019", "016" };

            
            foreach (string pattern in validPatterns)
            {
                if (phoneNumber.StartsWith(pattern))
                {
                    return true;
                }
            }

         
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
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

              
                string phoneText = txtPhone.Text.Trim();
                if (!IsValidPhoneNumber(phoneText))
                {
                    MessageBox.Show("Invalid phone number. Please enter a valid 11-digit number starting with 018, 015, 013, 017, 019, or 016.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User user = null;

                if (comboRole.Text == "Farmer")
                {
                    user = new Farmer(
                        txtUserName.Text,
                        txtName.Text,
                        txtPass.Text,
                        txtEmail.Text,
                        Convert.ToInt64(phoneText),
                        GetProfilePicture(),
                        txtAddress.Text
                    );
                }
                else if (comboRole.Text == "Vendor")
                {
                    user = new Vendor(
                        txtUserName.Text,
                        txtName.Text,
                        txtPass.Text,
                        txtEmail.Text,
                        Convert.ToInt64(phoneText),
                        GetProfilePicture(),
                        txtAddress.Text,
                        txtCNAME.Text,
                        Convert.ToInt64(txtEIIN.Text),
                        Convert.ToInt32(txtTIN.Text)
                    );
                }
                else if (comboRole.Text == "General Customer")
                {
                    user = new Customer(
                        txtUserName.Text,
                        txtName.Text,
                        txtPass.Text,
                        txtEmail.Text,
                        Convert.ToInt64(phoneText),
                        GetProfilePicture(),
                        txtAddress.Text
                    );
                }

                string otp = GenerateOtp();
                SendOtpToEmail(txtEmail.Text, otp);

            
                string userInputOtp = InputBox.Show("OTP Verification", "Enter the OTP sent to your email:");

                if (string.IsNullOrEmpty(userInputOtp))
                {
                    MessageBox.Show("No OTP entered. Registration canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userInputOtp != otp)
                {
                    MessageBox.Show("Incorrect OTP. Registration canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                user?.Signup(connectionString);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendOtpToEmail(string email, string otp)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("jalal4635600@gmail.com", "wwmo tmhn wami dlsg");
                    smtpClient.EnableSsl = true;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress("jalal4635600@gmail.com"),
                        Subject = "Your OTP Code",
                        Body = $"Your OTP code is: {otp}"
                    };
                    mail.To.Add(email);

                    smtpClient.Send(mail);
                    MessageBox.Show("OTP sent to your email successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send OTP. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
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

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = txtPass.PasswordChar == '\0' ? '*' : '\0';
        }
    }


    public static class InputBox
    {
        public static string Show(string title, string promptText)
        {
            // Create a new form
            Form form = new Form();
            form.Text = title;
            form.Size = new System.Drawing.Size(300, 150);
            form.StartPosition = FormStartPosition.CenterScreen;

            // Label for prompt text
            Label label = new Label { Text = promptText, Left = 10, Top = 10, Width = 260 };
            form.Controls.Add(label);

            // TextBox for input
            TextBox textBox = new TextBox { Left = 10, Top = 40, Width = 260 };
            form.Controls.Add(textBox);

            // OK Button
            Button okButton = new Button { Text = "OK", Left = 75, Top = 80, DialogResult = DialogResult.OK };
            form.Controls.Add(okButton);

            // Cancel Button
            Button cancelButton = new Button { Text = "Cancel", Left = 150, Top = 80, DialogResult = DialogResult.Cancel };
            form.Controls.Add(cancelButton);

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            // Show the form as a dialog
            DialogResult result = form.ShowDialog();

            // Return the input or null if canceled
            return result == DialogResult.OK ? textBox.Text : null;
        }
    }

}
