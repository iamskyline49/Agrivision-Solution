using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class CreatePostForm : Form
    {
        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
       

        public CreatePostForm()
        {
            InitializeComponent();
        }

    

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    button3.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    button2.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting the video: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string textContent = textBox1.Text;
                byte[] photoBytes = null;
                byte[] videoBytes = null;

              
                if (button3.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        button3.Image.Save(ms, button3.Image.RawFormat);
                        photoBytes = ms.ToArray();
                    }
                }

             
                if (!string.IsNullOrEmpty(button2.Text))
                {
                    videoBytes = File.ReadAllBytes(button2.Text);
                }

               
                if (string.IsNullOrEmpty(textContent) && photoBytes == null && videoBytes == null)
                {
                    MessageBox.Show("Please provide at least one content type (text, photo, or video).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Posts (UserID, PostText, PostImage, PostVideo, PostDate) OUTPUT INSERTED.PostID VALUES (@UserID, @PostText, @PostImage, @PostVideo, @PostDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", "admin"); 
                        cmd.Parameters.AddWithValue("@PostText", string.IsNullOrEmpty(textContent) ? (object)DBNull.Value : textContent);
                        cmd.Parameters.AddWithValue("@PostImage", photoBytes ?? (object)DBNull.Value);

                     
                        cmd.Parameters.AddWithValue("@PostVideo", videoBytes ?? (object)DBNull.Value);

                        cmd.Parameters.AddWithValue("@PostDate", DateTime.Now);

                        conn.Open();
                        int newPostID = (int)cmd.ExecuteScalar(); 
                        conn.Close();

                        MessageBox.Show($"Post saved successfully! Post ID: {newPostID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PostDetails postDetails = new PostDetails();
            postDetails.Show();
        }
    }
}
