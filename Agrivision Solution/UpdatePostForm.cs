using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class UpdatePostForm : Form
    {
        private int postID;
        private string connectionString;

        public UpdatePostForm(int postID, string connectionString)
        {
            InitializeComponent();
            this.postID = postID;
            this.connectionString = connectionString;
            LoadPostDetails();
        }

        private void LoadPostDetails()
        {
            string query = "SELECT PostText, PostImage, PostVideo FROM Posts WHERE PostID = @PostID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostID", postID);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["PostText"] as string;

                                if (reader["PostImage"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["PostImage"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        button3.Image = Image.FromStream(ms);
                                    }
                                }

                                if (reader["PostVideo"] != DBNull.Value)
                                {
                                    button2.Text = "Video Selected";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading post details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePostForm));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(577, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(328, 185);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add Photo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(911, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 185);
            this.button2.TabIndex = 9;
            this.button2.Text = "Add Video";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(577, 164);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(511, 268);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(568, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "Content";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(775, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Post ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 414);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 33);
            this.button4.TabIndex = 12;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // UpdatePostForm
            // 
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "UpdatePostForm";
            this.Text = "Update Post Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private Label label1;
        private System.Windows.Forms.Button button1;

        private void button3_Click(object sender, EventArgs e)
        {
            // Image selection logic (using OpenFileDialog)
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);
                    button3.Image = selectedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Video selection logic (using OpenFileDialog)
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button2.Text = openFileDialog.FileName;
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

                if (!string.IsNullOrEmpty(button2.Text) && button2.Text != "Select Video")
                {
                    videoBytes = File.ReadAllBytes(button2.Text);
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Posts SET PostText = @PostText, PostImage = @PostImage, PostVideo = @PostVideo WHERE PostID = @PostID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostText", string.IsNullOrEmpty(textContent) ? (object)DBNull.Value : textContent);
                        cmd.Parameters.AddWithValue("@PostImage", photoBytes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PostVideo", videoBytes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PostID", postID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Post updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating post: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PictureBox pictureBox1;
        private Button button4;

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PostDetails p=new PostDetails();
            p.Show();
        }
    }
}
