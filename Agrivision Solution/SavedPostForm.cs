using AxWMPLib;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;

namespace Agrivision_Solution
{
    public partial class SavedPostForm : Form
    {
        private string currentUserID;
        private string currentUserType;

        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public SavedPostForm(string userID, string userType)
        {
            this.currentUserID = userID;
            this.currentUserType = userType;
            InitializeComponent();
            LoadSavedPosts();
        }

        private void LoadSavedPosts(DateTime? startDate = null, DateTime? endDate = null)
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT P.* FROM Posts P INNER JOIN SavedPosts S ON P.PostID = S.PostID WHERE S.UserID = @UserID AND S.UserType = @UserType";

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND S.SaveDate BETWEEN @StartDate AND @EndDate";
                }

                query += " ORDER BY S.SaveDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    cmd.Parameters.AddWithValue("@UserType", currentUserType);

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                    }

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Panel postPanel = new Panel
                        {
                            Width = flowLayoutPanel1.Width - 25,
                            Height = 450,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(5),
                            AutoScroll = true
                        };

                        // Admin profile picture
                        PictureBox adminProfilePic = new PictureBox
                        {
                            Width = 50,
                            Height = 50,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Margin = new Padding(5),
                            Image = Image.FromFile(@"C:\Users\dipkh\Downloads\Image (7).jpg")

                        };
                        postPanel.Controls.Add(adminProfilePic);

                        // Admin name label
                        Label lblAdminName = new Label
                        {
                            Text = "Admin", // Replace with actual admin name
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            Margin = new Padding(5)
                        };
                        lblAdminName.Location = new Point(adminProfilePic.Right + 10, adminProfilePic.Top);
                        postPanel.Controls.Add(lblAdminName);

                        // Post date label
                        Label lblPostDate = new Label
                        {
                            Text = Convert.ToDateTime(reader["PostDate"]).ToString("MMM dd, yyyy HH:mm:ss"),
                            AutoSize = true,
                            Font = new Font("Arial", 8, FontStyle.Italic),
                            Margin = new Padding(5)
                        };
                        lblPostDate.Location = new Point(lblAdminName.Left, lblAdminName.Bottom + 5);
                        postPanel.Controls.Add(lblPostDate);

                        int verticalOffset = lblPostDate.Bottom + 20;

                        // Post text
                        if (!reader.IsDBNull(reader.GetOrdinal("PostText")))
                        {
                            Label lblText = new Label
                            {
                                Text = reader["PostText"].ToString(),
                                AutoSize = true,
                                MaximumSize = new Size(postPanel.Width - 10, 0),
                                Margin = new Padding(5),
                                TextAlign = ContentAlignment.MiddleLeft,
                                 RightToLeft = RightToLeft.No
                            };
                            postPanel.RightToLeft = RightToLeft.No;
                            lblText.Location = new Point(5, verticalOffset);
                            postPanel.Controls.Add(lblText);
                            verticalOffset = lblText.Bottom + 20;
                        }

                        // Post Image
                        if (!reader.IsDBNull(reader.GetOrdinal("PostImage")))
                        {
                            byte[] photoBytes = (byte[])reader["PostImage"];
                            using (MemoryStream ms = new MemoryStream(photoBytes))
                            {
                                PictureBox picPhoto = new PictureBox
                                {
                                    Image = Image.FromStream(ms),
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Width = postPanel.Width - 10,
                                    Height = 300,
                                    Margin = new Padding(5)
                                };
                                picPhoto.Location = new Point(5, verticalOffset);
                                postPanel.Controls.Add(picPhoto);
                            }
                        }
                        // Post Video
                        else if (!reader.IsDBNull(reader.GetOrdinal("PostVideo")))
                        {
                            byte[] videoBytes = (byte[])reader["PostVideo"];
                            string tempFilePath = Path.GetTempFileName() + ".mp4";
                            File.WriteAllBytes(tempFilePath, videoBytes);

                            try
                            {
                                AxWindowsMediaPlayer videoPlayer = new AxWindowsMediaPlayer();
                                videoPlayer.CreateControl();
                                videoPlayer.Width = postPanel.Width - 10;
                                videoPlayer.Height = 300;
                                videoPlayer.Location = new Point(5, verticalOffset);
                                videoPlayer.URL = tempFilePath;
                                videoPlayer.Ctlcontrols.stop();

                                postPanel.Controls.Add(videoPlayer);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error loading video: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Unsave Post Button
                        Button btnUnsave = new Button
                        {
                            Text = "Unsave Post",
                            Width = 100,
                            Height = 30,
                            Location = new Point(lblAdminName.Right+300, lblAdminName.Bottom + 5)
                        };

                        int postID = Convert.ToInt32(reader["PostID"]);
                        btnUnsave.Click += (s, e) => UnsavePost(postID);
                        postPanel.Controls.Add(btnUnsave);

                        flowLayoutPanel1.Controls.Add(postPanel);
                    }

                    conn.Close();
                }
            }
        }

        private void UnsavePost(int postID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM SavedPosts WHERE UserID = @UserID AND PostID = @PostID AND UserType = @UserType";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    cmd.Parameters.AddWithValue("@PostID", postID);
                    cmd.Parameters.AddWithValue("@UserType", currentUserType);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Post unsaved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSavedPosts(); // Refresh the list of saved posts
        }

      

      

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSavedPosts(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadSavedPosts(); // Reload all saved posts
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
                this.Hide();
                MediaFeedPage v = new MediaFeedPage (currentUserID, currentUserType);
                v.Show();
           
        }
    }
}
