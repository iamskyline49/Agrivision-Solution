using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agrivision_Solution
{
    public partial class FormConfirmNewPass : Form
    {
        public string EMAIL { get; private set; }

        public FormConfirmNewPass(string farmerEmail)
        {
            InitializeComponent();
            EMAIL = farmerEmail;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string newPassword = textBox3.Text;
            string confirmPassword = textBox4.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.");
                return;
            }

            if (newPassword == confirmPassword)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True"))
                    {
                        string query = "UPDATE [FarmerTable] SET [Password] = @Password WHERE [email] = @Email";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Password", newPassword);
                            cmd.Parameters.AddWithValue("@Email", EMAIL);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password Successfully Changed");
                                LoginPage loginForm = new LoginPage();
                                loginForm.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error: Email not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {

        }

        private void FormConfirmNewPass_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newPassword = textBox3.Text;
            string confirmPassword = textBox4.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.");
                return;
            }

            if (newPassword == confirmPassword)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True"))
                    {
                        string query = "UPDATE [FarmerTable] SET [Password] = @Password WHERE [email] = @Email";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Password", newPassword);
                            cmd.Parameters.AddWithValue("@Email", EMAIL);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password Successfully Changed");
                                LoginPage loginForm = new LoginPage();
                                loginForm.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error: Email not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
           FrmForgetPassword w = new FrmForgetPassword();
            w.Show();
        }
    }
}
