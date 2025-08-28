using System.Windows.Forms;
using System;

namespace Agrivision_Solution
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
     
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage r = new LoginPage();
            r.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Registration r = new Registration();
            r.Show();
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Credits r = new Credits();
            r.Show();

        }
    }
}
