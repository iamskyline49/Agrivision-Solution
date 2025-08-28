using AgriProject;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class LoginPage : Form
    {
        string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = txtPass.PasswordChar == '\0' ? '*' : '\0';
        }

        private void btnlgn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text) || comboRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the selected role is Admin
                if (comboRole.Text == "Admin" && txtUserName.Text == "admin" && txtPass.Text == "admin")
                {
                    MessageBox.Show("Welcome Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                    return;
                }

                // Dynamically determine the user type
                User user = null;

                if (comboRole.Text == "Farmer")
                {
                    user = new Farmer(txtUserName.Text, txtPass.Text);
                }
                else if (comboRole.Text == "Vendor")
                {
                    user = new Vendor(txtUserName.Text, txtPass.Text);
                }
                else if (comboRole.Text == "General Customer")
                {
                    user = new Customer(txtUserName.Text, txtPass.Text);
                }
                else
                {
                    MessageBox.Show("Invalid role selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if the role is invalid
                }



                // Attempt login
                if (user.Login(connectionString, out string errorMessage))
                {
                    MessageBox.Show($"Welcome {comboRole.Text}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Navigate to the appropriate dashboard/form
                    switch (comboRole.Text)
                    {
                        case "Farmer":
                            FarmerDashboard farmerDashboard = new FarmerDashboard(txtUserName.Text, "Farmer");
                            farmerDashboard.Show();
                            break;
                        case "Vendor":
                            VendorDashboard vendorDashboard = new VendorDashboard(txtUserName.Text, "Vendor");
                            vendorDashboard.Show();
                            break;
                        case "General Customer":
                            GeneralCustomerDashboard customerDashboard = new GeneralCustomerDashboard(txtUserName.Text, "General Customer");
                            customerDashboard.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Login Failed: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormForgetPassMethod f3 = new FormForgetPassMethod();
            f3.Show();
            Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPass.Text = null;
            txtUserName.Text = null;    
            comboRole.Text = "Select Role";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Registration r = new Registration();
            r.Show();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
