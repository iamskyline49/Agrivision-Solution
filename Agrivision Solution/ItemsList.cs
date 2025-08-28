using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class ItemsList : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=True";

        public ItemsList()
        {
            InitializeComponent();
            LoadItems();
        }

        // Load all items from the database
        private void LoadItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM ItemTable"; // Fetch all columns
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable itemsTable = new DataTable();
                    adapter.Fill(itemsTable);
                    dataGridView1.DataSource = itemsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

      
       

        private void ItemsList_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

              
                int itemId = Convert.ToInt32(selectedRow.Cells["ItemID"].Value);
                string itemName = selectedRow.Cells["Name"].Value.ToString();
                double itemPrice = Convert.ToDouble(selectedRow.Cells["Price"].Value);
                int itemStock = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

              
                EditItems item = new EditItems(itemId , "Admin" , "admin");
                item.ShowDialog();

              
                LoadItems();
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard n = new AdminDashboard();
            n.ShowDialog();
        }
    }
}
