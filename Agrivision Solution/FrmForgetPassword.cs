using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agrivision_Solution;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agrivision_Solution
{
    public partial class FrmForgetPassword : Form
    {
        private string randomCode;
        public static string to;

        public FrmForgetPassword()
        {
            InitializeComponent();
        }

        private async void Registration_Click(object sender, EventArgs e)
        {
            try
            {
                string farmerEmail = textBox1.Text;
                if (!await ValidateEmailAsync(farmerEmail))
                {
                    MessageBox.Show("Email not registered.");
                    return;
                }

                randomCode = new EmailSender().GenerateRandomCode();
                to = farmerEmail;
                await new EmailSender().SendEmailAsync(farmerEmail, randomCode);

                MessageBox.Show("Code Successfully Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (randomCode == textBox2.Text)
            {
                FormConfirmNewPass confirmForm = new FormConfirmNewPass(to);
                confirmForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You Entered the Wrong Code");
            }
        }

        private async Task<bool> ValidateEmailAsync(string email)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B3L9CGRC\DIPKHASTAGIR;Initial Catalog=Agrivision Solution;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = "SELECT COUNT(*) FROM [FarmerTable] WHERE [Email] = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    int count = (int)await cmd.ExecuteScalarAsync();
                    con.Close();
                    return count > 0;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
           FormForgetPassMethod w = new FormForgetPassMethod();
            w.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormForgetPassMethod formForgetPassMethod = new FormForgetPassMethod();
            formForgetPassMethod.Show();
        }
    }

    public class EmailSender
    {
        public string GenerateRandomCode()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString(); 
        }

        public async Task SendEmailAsync(string to, string randomCode)
        {
            string from = "jalal4635600@gmail.com"; 
            string pass = "wwmo tmhn wami dlsg";    

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = "Password Reset Code",
                Body = $"Your Reset Code is {randomCode}"
            };
            message.To.Add(to);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(from, pass)
            };

            await smtp.SendMailAsync(message);
        }
    }
}


