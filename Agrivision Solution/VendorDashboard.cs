using System.Windows.Forms;
using System;

namespace Agrivision_Solution
{
    public partial class VendorDashboard : Form
    {
       
        public string UserName { get; set; }
        public string UserType { get; set; }

        public VendorDashboard(string vendorUsername, string userType)
        {
            InitializeComponent();
            UserName = vendorUsername;
          
            
            UserType = userType;
            textBox1.Text = UserName;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MediaFeedPage m = new MediaFeedPage(UserName, UserType);
            m.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            VendorProfile vendorProfile = new VendorProfile(UserName);  
            vendorProfile.ShowDialog();
            this.Show(); 
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void Marketplace_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marketplace1 marketplace1 = new Marketplace1(UserName, "Vendor");
            marketplace1.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrderVGC vgc = new ViewOrderVGC(UserName, "Canceled");
            vgc.ShowDialog();
            this.Show();
        }

        private void TransactionHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrderVGC vgc = new ViewOrderVGC(UserName, "Confirmed");
            vgc.ShowDialog();
            this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm rf = new ReportForm(UserName,UserType);
            rf.ShowDialog();
        }
    }
}
