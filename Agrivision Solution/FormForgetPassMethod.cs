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
    public partial class FormForgetPassMethod : Form
    {
        public FormForgetPassMethod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmForgetPassword f4 = new FrmForgetPassword();
            f4.Show();
            Visible = false;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage w = new LoginPage();
            w.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
