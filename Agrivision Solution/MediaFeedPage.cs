using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AgriProject;
using AxWMPLib;
using Azure.Identity; // Add reference to use Windows Media Player control

namespace Agrivision_Solution
{
    public partial class MediaFeedPage : Form
    {
        private string currentUserID;
        private string currentUserType;

        private string connectionString = @"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";

        public MediaFeedPage(string currentUserID, string currentUserType)
        {
            this.currentUserID = currentUserID;
            this.currentUserType = currentUserType;
            InitializeComponent();
            LoadMediaFeed();
        }

        private void LoadMediaFeed(DateTime? startDate = null, DateTime? endDate = null)
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 100 * FROM Posts WHERE 1=1";

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND PostDate BETWEEN @StartDate AND @EndDate";
                }

                query += " ORDER BY PostID DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                            Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Image (7).jpg")
                        };
                        postPanel.Controls.Add(adminProfilePic);

                        // Admin name label
                        Label lblAdminName = new Label
                        {
                            Text = "Admin", 
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
                        int horizontalOffset = 5;

                        // Post text
                        if (!reader.IsDBNull(reader.GetOrdinal("PostText")))
                        {
                            Label lblText = new Label
                            {
                                Text = reader["PostText"].ToString(),
                                AutoSize = true,
                                MaximumSize = new Size(postPanel.Width - 10, 0),
                                Margin = new Padding(5),
                                TextAlign = ContentAlignment.TopLeft, 
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

                        // Store PostID in a local variable to avoid issues when accessing reader
                        int postID = Convert.ToInt32(reader["PostID"]);

                        // Reaction Emojis and Count
                        var reactions = new[] { "Like", "Love", "Haha", "Wow", "Sad", "Angry" };

                        foreach (var reaction in reactions)
                        {
                            PictureBox picReaction = new PictureBox
                            {
                                Width = 40,
                                Height = 40,
                                Margin = new Padding(5),
                                Tag = reaction, // Store reaction type in Tag property
                                Location = new Point(horizontalOffset + 10, verticalOffset + 310),
                                Cursor = Cursors.Hand,
                                SizeMode = PictureBoxSizeMode.Zoom // Ensures the image is properly scaled

                            };

                            switch (reaction)
                            {
                                case "Like":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Like.jpg");
                                    break;
                                case "Love":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Love.jpg");
                                    break;
                                case "Haha":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Haha.png");
                                    break;
                                case "Wow":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\wow.jpg");
                                    break;
                                case "Sad":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Sad.jpg");
                                    break;
                                case "Angry":
                                    picReaction.Image = Image.FromFile(@"C:\Users\dipkh\OneDrive\Pictures\Desktop\Agrivision Solution\Images\Angry.jpg");
                                    break;
                            }

                            postPanel.Controls.Add(picReaction);

                            Label lblReactionCount = new Label
                            {
                                Text = GetReactionCount(postID, reaction).ToString(),
                                AutoSize = true,
                                Font = new Font("Arial", 8, FontStyle.Bold),
                                Location = new Point(horizontalOffset + 55, verticalOffset + 310),
                                Margin = new Padding(5)
                            };

                            postPanel.Controls.Add(lblReactionCount);

                           
                            picReaction.Click += (s, e) =>
                            {
                                ReactToPost(postID, reaction);

                            
                                var originalSize = picReaction.Size;

                                
                                Timer animationTimer = new Timer();
                                int scaleStep = 5;
                                bool isExpanding = true; 

                                animationTimer.Interval = 60; 
                                animationTimer.Tick += (sender, args) =>
                                {
                                    if (isExpanding)
                                    {
                                        picReaction.Width += scaleStep;
                                        picReaction.Height += scaleStep;

                                        if (picReaction.Width >= originalSize.Width + 10) 
                                            isExpanding = false;
                                    }
                                    else
                                    {
                                        picReaction.Width -= scaleStep;
                                        picReaction.Height -= scaleStep;

                                        if (picReaction.Width <= originalSize.Width) // Reset to original
                                        {
                                            picReaction.Size = originalSize; // Ensure exact original size
                                            animationTimer.Stop();
                                            animationTimer.Dispose();
                                        }
                                    }
                                };

                                animationTimer.Start();
                            };
                        

                        // Adjust horizontal offset for the next emoji
                        horizontalOffset += 60; // Adjust based on your preferred spacing
                    }

                    // Save Post Button
                    Button btnSave = new Button
                    {
                        Text = "Save Post",
                        Width = 100,
                        Height = 30,
                        Location = new Point(lblAdminName.Right + 300, lblAdminName.Bottom + 5)
                    };
                    btnSave.Click += (s, e) => SavePost(postID); // Pass the postID directly to the event handler
                    postPanel.Controls.Add(btnSave);

                    flowLayoutPanel1.Controls.Add(postPanel);
                }

                // Close the reader after finishing all reads
                reader.Close();
            }
        }
    }

        private void SavePost(int postID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SavedPosts (UserID, PostID, UserType) VALUES (@UserID, @PostID, @UserType)";
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

            MessageBox.Show("Post saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReactToPost(int postID, string reactionType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reactions (UserID, PostID, UserType, ReactionType) VALUES (@UserID, @PostID, @UserType, @ReactionType)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    cmd.Parameters.AddWithValue("@PostID", postID);
                    cmd.Parameters.AddWithValue("@UserType", currentUserType);
                    cmd.Parameters.AddWithValue("@ReactionType", reactionType);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Reaction added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetReactionCount(int postID, string reactionType)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Reactions WHERE PostID = @PostID AND ReactionType = @ReactionType";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PostID", postID);
                    cmd.Parameters.AddWithValue("@ReactionType", reactionType);

                    conn.Open();
                    count = (int)cmd.ExecuteScalar();
                    conn.Close();
                }
            }
            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMediaFeed(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadMediaFeed();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SavedPostForm w = new SavedPostForm(currentUserID, currentUserType);
            w.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentUserType == "Vendor")
            {
                this.Hide();
                VendorDashboard v=new VendorDashboard(currentUserID, currentUserType);
                v.Show();
            }
            else if (currentUserType == "Farmer")
            {
                this.Hide();
                FarmerDashboard f=new FarmerDashboard(currentUserID,currentUserType);
                f.Show();
            }
            else if (currentUserType == "General Customer")
            {
                this.Hide();
                GeneralCustomerDashboard c=new GeneralCustomerDashboard(currentUserID,currentUserType);
                c.Show();
            }
            else
            {

            }
        }
    }
}
