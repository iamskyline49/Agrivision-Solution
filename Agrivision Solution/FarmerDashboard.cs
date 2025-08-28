using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Agrivision_Solution
{
    public partial class FarmerDashboard : Form
    {
        public string userName;
        public string userType;

        public FarmerDashboard(string userName, string userType)
        {

            InitializeComponent();
            this.userName = userName;
            this.userType = userType;
            textBox1.Text = userName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Profile w = new Profile(userName, "Farmer");
            w.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = userName;
        }

        private void Welcome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmerItemManagement w = new FarmerItemManagement(userName);
            w.ShowDialog();
            this.Show(); 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();  
            loginPage.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Profile w = new Profile(userName, "Farmer");
            w.ShowDialog();
            this.Show();    
        }

        private void Marketplace_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marketplace1 marketplace1 = new Marketplace1(userName, "Farmer");
            marketplace1.ShowDialog();
            this.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrders v = new ViewOrders(userName);
            v.ShowDialog();
            this.Show(); 
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmerSales fs = new FarmerSales(userName);
            fs.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MediaFeedPage m = new MediaFeedPage(userName, userType);
            m.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm rf = new ReportForm(userName, userType);
            rf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmerHelpline m = new FarmerHelpline(userName , userType);
            m.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

  

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }


}
