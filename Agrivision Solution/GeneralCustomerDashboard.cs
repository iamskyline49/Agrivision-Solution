using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    public partial class GeneralCustomerDashboard : Form
    {
        public string userName;
        public string userType;
        public GeneralCustomerDashboard(string username, string userType)
        {
            InitializeComponent();
            this.userName = username;
            this.userType = userType;
            textBox1.Text = userName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage w = new WelcomePage();
            w.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile w = new Profile(userName, "General Customer");
            w.ShowDialog();
            this.Show();
        }

        private void Marketplace_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marketplace1 marketplace1 = new Marketplace1(userName, "General Customer");
            marketplace1.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             this.Hide();
             MediaFeedPage m= new MediaFeedPage(userName, userType);
             m.ShowDialog();
             //this.Show();
        }

        private void btnConfirmedOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrderVGC vgc = new ViewOrderVGC(userName, "Confirmed");
            vgc.ShowDialog();
            this.Show();
        }

        private void btnCancelledOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrderVGC vgc = new ViewOrderVGC(userName, "Canceled");
            vgc.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm rf = new ReportForm(userName, userType);
            rf.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

     
    }
}
