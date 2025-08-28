using System.Drawing;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    partial class VendorProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorProfile));
            this.ChangePic = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.profilePic = new System.Windows.Forms.PictureBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.EditInfo = new System.Windows.Forms.Button();
            this.CompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.EiinTextBox = new System.Windows.Forms.TextBox();
            this.CompanyName = new System.Windows.Forms.Label();
            this.EIN = new System.Windows.Forms.Label();
            this.TIN = new System.Windows.Forms.Label();
            this.TinTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.profilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangePic
            // 
            this.ChangePic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePic.ForeColor = System.Drawing.Color.SandyBrown;
            this.ChangePic.Location = new System.Drawing.Point(104, 391);
            this.ChangePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangePic.Name = "ChangePic";
            this.ChangePic.Size = new System.Drawing.Size(240, 34);
            this.ChangePic.TabIndex = 60;
            this.ChangePic.Text = "CHANGE PROFILE PICTURE";
            this.ChangePic.UseVisualStyleBackColor = true;
            this.ChangePic.Click += new System.EventHandler(this.ChangePic_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Peru;
            this.button3.Location = new System.Drawing.Point(1046, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 34);
            this.button3.TabIndex = 59;
            this.button3.Text = "BACK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // profilePic
            // 
            this.profilePic.BackColor = System.Drawing.Color.White;
            this.profilePic.Location = new System.Drawing.Point(88, 120);
            this.profilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profilePic.Name = "profilePic";
            this.profilePic.Size = new System.Drawing.Size(282, 247);
            this.profilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePic.TabIndex = 58;
            this.profilePic.TabStop = false;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextBox.Location = new System.Drawing.Point(192, 707);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(336, 38);
            this.AddressTextBox.TabIndex = 57;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneTextBox.Location = new System.Drawing.Point(192, 652);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(336, 38);
            this.PhoneTextBox.TabIndex = 56;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(192, 605);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(336, 38);
            this.EmailTextBox.TabIndex = 55;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.Location = new System.Drawing.Point(192, 539);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(336, 38);
            this.UsernameTextBox.TabIndex = 54;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(192, 474);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(336, 38);
            this.NameTextBox.TabIndex = 53;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.ForeColor = System.Drawing.Color.Green;
            this.Address.Location = new System.Drawing.Point(36, 710);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(105, 31);
            this.Address.TabIndex = 52;
            this.Address.Text = "Address:";
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone.ForeColor = System.Drawing.Color.Green;
            this.Phone.Location = new System.Drawing.Point(53, 655);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(88, 31);
            this.Phone.TabIndex = 51;
            this.Phone.Text = "Phone:";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.Color.Green;
            this.Email.Location = new System.Drawing.Point(53, 601);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(79, 31);
            this.Email.TabIndex = 50;
            this.Email.Text = "Email:";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.Green;
            this.Username.Location = new System.Drawing.Point(49, 538);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(127, 31);
            this.Username.TabIndex = 49;
            this.Username.Text = "Username:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.Green;
            this.NameLabel.Location = new System.Drawing.Point(49, 474);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(83, 31);
            this.NameLabel.TabIndex = 48;
            this.NameLabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(595, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Vendor Profile ";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(669, 684);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 48);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditInfo
            // 
            this.EditInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditInfo.ForeColor = System.Drawing.Color.Green;
            this.EditInfo.Location = new System.Drawing.Point(937, 684);
            this.EditInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditInfo.Name = "EditInfo";
            this.EditInfo.Size = new System.Drawing.Size(192, 48);
            this.EditInfo.TabIndex = 66;
            this.EditInfo.Text = "EDIT INFORMATION";
            this.EditInfo.UseVisualStyleBackColor = true;
            this.EditInfo.Click += new System.EventHandler(this.EditInfo_Click);
            // 
            // CompanyNameTextBox
            // 
            this.CompanyNameTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyNameTextBox.Location = new System.Drawing.Point(772, 474);
            this.CompanyNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyNameTextBox.Name = "CompanyNameTextBox";
            this.CompanyNameTextBox.Size = new System.Drawing.Size(336, 38);
            this.CompanyNameTextBox.TabIndex = 67;
            // 
            // EiinTextBox
            // 
            this.EiinTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EiinTextBox.Location = new System.Drawing.Point(772, 535);
            this.EiinTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EiinTextBox.Name = "EiinTextBox";
            this.EiinTextBox.Size = new System.Drawing.Size(343, 38);
            this.EiinTextBox.TabIndex = 68;
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSize = true;
            this.CompanyName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyName.ForeColor = System.Drawing.Color.Green;
            this.CompanyName.Location = new System.Drawing.Point(539, 474);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(190, 31);
            this.CompanyName.TabIndex = 69;
            this.CompanyName.Text = "Company Name:";
            // 
            // EIN
            // 
            this.EIN.AutoSize = true;
            this.EIN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EIN.ForeColor = System.Drawing.Color.Green;
            this.EIN.Location = new System.Drawing.Point(663, 542);
            this.EIN.Name = "EIN";
            this.EIN.Size = new System.Drawing.Size(70, 31);
            this.EIN.TabIndex = 70;
            this.EIN.Text = "EIIN: ";
            // 
            // TIN
            // 
            this.TIN.AutoSize = true;
            this.TIN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIN.ForeColor = System.Drawing.Color.Green;
            this.TIN.Location = new System.Drawing.Point(669, 608);
            this.TIN.Name = "TIN";
            this.TIN.Size = new System.Drawing.Size(64, 31);
            this.TIN.TabIndex = 71;
            this.TIN.Text = "TIN: ";
            // 
            // TinTextBox
            // 
            this.TinTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TinTextBox.Location = new System.Drawing.Point(772, 601);
            this.TinTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TinTextBox.Name = "TinTextBox";
            this.TinTextBox.Size = new System.Drawing.Size(343, 38);
            this.TinTextBox.TabIndex = 72;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(454, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 310);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // VendorProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.TinTextBox);
            this.Controls.Add(this.TIN);
            this.Controls.Add(this.EIN);
            this.Controls.Add(this.CompanyName);
            this.Controls.Add(this.EiinTextBox);
            this.Controls.Add(this.CompanyNameTextBox);
            this.Controls.Add(this.EditInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ChangePic);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.profilePic);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VendorProfile";
            this.Text = "VendorProfile";
            this.Load += new System.EventHandler(this.VendorProfile_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.profilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangePic;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox profilePic;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button EditInfo;
        private System.Windows.Forms.TextBox CompanyNameTextBox;
        private System.Windows.Forms.TextBox EiinTextBox;
        private System.Windows.Forms.Label CompanyName;
        private System.Windows.Forms.Label EIN;
        private System.Windows.Forms.Label TIN;
        private System.Windows.Forms.TextBox TinTextBox;
        private PictureBox pictureBox1;
    }
}
