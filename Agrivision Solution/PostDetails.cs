using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class PostDetails : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=True";

        public PostDetails()
        {
            InitializeComponent();
            LoadPosts();

            // Handle DataGridView errors
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void LoadPosts()
        {
            string query = "SELECT PostID, UserID, PostText, PostImage, PostVideo, PostDate FROM Posts";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;

                    // Rename columns for better readability
                    dataGridView1.Columns["PostID"].HeaderText = "Post ID";
                    dataGridView1.Columns["UserID"].HeaderText = "User ID";
                    dataGridView1.Columns["PostText"].HeaderText = "Post Text";
                    dataGridView1.Columns["PostDate"].HeaderText = "Post Date";

                    // Hide PostVideo column (cannot display videos)
                    if (dataGridView1.Columns.Contains("PostVideo"))
                    {
                        dataGridView1.Columns["PostVideo"].Visible = false;
                    }

                    // Convert PostImage column into an Image type column
                    if (dataGridView1.Columns.Contains("PostImage") && !(dataGridView1.Columns["PostImage"] is DataGridViewImageColumn))
                    {
                        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                        {
                            Name = "PostImage",
                            HeaderText = "Post Image",
                            ImageLayout = DataGridViewImageCellLayout.Zoom
                        };

                        int index = dataGridView1.Columns["PostImage"].Index;
                        dataGridView1.Columns.Remove("PostImage");
                        dataGridView1.Columns.Insert(index, imgColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fix Data Error in DataGridView (prevents red cross)
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // Prevent crashes
            MessageBox.Show($"Error in column {dataGridView1.Columns[e.ColumnIndex].HeaderText}: {e.Exception.Message}",
                            "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Convert Byte Array to Image for PostImage Column
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PostImage" && e.Value is byte[] imageBytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        e.Value = Image.FromStream(ms);
                    }
                    e.FormattingApplied = true;
                }
                catch
                {
                    e.Value = null; // Prevent errors when image is corrupted
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a post to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int postID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PostID"].Value);
            UpdatePostForm updatePostForm = new UpdatePostForm(postID, connectionString);
            updatePostForm.ShowDialog();
            LoadPosts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a post to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int postID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PostID"].Value);
            string query = "DELETE FROM Posts WHERE PostID = @PostID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostID", postID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Post deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting post: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddTicks(-1); // End of the selected day

            string query = "SELECT PostID, UserID, PostText, PostImage, PostVideo, PostDate FROM Posts WHERE PostDate BETWEEN @StartDate AND @EndDate";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering posts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreatePostForm w = new CreatePostForm();
            w.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnlgn_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard a= new AdminDashboard();
            a.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
