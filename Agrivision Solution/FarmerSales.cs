using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class FarmerSales : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        private string FarmerUsername;
        DataTable dt;

        public FarmerSales(string farmerUsername)
        {
            InitializeComponent();
            FarmerUsername = farmerUsername;
        }

        private void FarmerSales_Load(object sender, EventArgs e)
        {
            LoadSales();
        }

        // Method to load all sales records
        private void LoadSales()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT SaleID, ItemID, ItemName, Quantity, TotalAmount, SaleDate FROM Sales WHERE FarmerUsername = @FarmerUsername ORDER BY SaleDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            UpdateTotalSales(dt); // Recalculate the total sales after loading data
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update the total sales in the TextBox based on provided DataTable
        private void UpdateTotalSales(DataTable data)
        {
            decimal totalSales = 0;
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["TotalAmount"] != DBNull.Value)
                    {
                        totalSales += Convert.ToDecimal(row["TotalAmount"]);
                    }
                }
            }
            txtTotal.Text = totalSales.ToString("C");
        }

        // Refresh button functionality
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = null;
            LoadSales(); // Reload all sales data and recalculate total sales
        }

        // Search by Date Range functionality
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string from = dateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string to = dateTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT SaleID, ItemID, ItemName, Quantity, TotalAmount, SaleDate FROM Sales WHERE FarmerUsername = @FarmerUsername AND SaleDate BETWEEN @From AND @To ORDER BY SaleDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FarmerUsername", FarmerUsername);
                        cmd.Parameters.AddWithValue("@From", from);
                        cmd.Parameters.AddWithValue("@To", to);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable filteredDt = new DataTable();
                            adapter.Fill(filteredDt);
                            dataGridView1.DataSource = filteredDt;
                            UpdateTotalSales(filteredDt); // Recalculate the total sales for filtered data
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Back button functionality
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Search by Item Name functionality
        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBox.Text.Trim();

            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);

                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView1.DataSource = dt; // Show all records if search box is empty
                    UpdateTotalSales(dt); // Recalculate total sales for all records
                }
                else
                {
                    dv.RowFilter = $"ItemName LIKE '%{searchText}%'";
                    dataGridView1.DataSource = dv;

                    // Recalculate the total sales for the filtered data (DataView)
                    UpdateTotalSales(dv.ToTable()); // Use DataView's filtered data for total sales calculation
                }
            }
        }

        // Automatically trigger search when the search box text changes
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
