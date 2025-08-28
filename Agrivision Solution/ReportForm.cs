using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class ReportForm : Form
    {
        private string userName;
        private string userType;
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True"; // Replace with actual connection string

        public ReportForm(string userName, string userType)
        {
            InitializeComponent();
            this.userName = userName;
            this.userType = userType;
        }

      
            string query = "";


        private void button1_Click(object sender, EventArgs e)
        {
            string reportText = txtReport.Text; // Get report text from textbox
            if (string.IsNullOrEmpty(reportText))
            {
                MessageBox.Show("Please enter a report before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Reports (UserID, ReportText, ReportDateTime, UserType) " +
                                   "VALUES (@UserID, @ReportText, GETDATE(), @UserType)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userName);
                        cmd.Parameters.AddWithValue("@ReportText", reportText);
                        cmd.Parameters.AddWithValue("@UserType", userType);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtReport.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit the report. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting the report: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (userType == "Farmer")
            {
                FarmerDashboard n=new FarmerDashboard(userName , userType);
                n.Show();
            }
            else if (userType == "Vendor")
            {
                VendorDashboard n=new VendorDashboard(userName , userType);
                n.Show();
            }
            else if (userType == "General Customer")
            {
                GeneralCustomerDashboard n=new GeneralCustomerDashboard(userName , userType);
                n.Show();
            }
            else
            {

            }
        }
    }
}

