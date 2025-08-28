using System.Drawing;
using System.Windows.Forms;

namespace Agrivision_Solution
{
    partial class FarmerAddItem
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.itemPicture = new System.Windows.Forms.PictureBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SaveItem = new System.Windows.Forms.Button();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.itemPicUpload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // itemPicture
            // 
            this.itemPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemPicture.Location = new System.Drawing.Point(68, 228);
            this.itemPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(313, 301);
            this.itemPicture.TabIndex = 0;
            this.itemPicture.TabStop = false;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(677, 479);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(482, 205);
            this.DescriptionTextBox.TabIndex = 67;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Font = new System.Drawing.Font("Segoe UI", 19.8F);
            this.QuantityTextBox.Location = new System.Drawing.Point(677, 413);
            this.QuantityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(483, 51);
            this.QuantityTextBox.TabIndex = 66;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Font = new System.Drawing.Font("Segoe UI", 19.8F);
            this.PriceTextBox.Location = new System.Drawing.Point(677, 335);
            this.PriceTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(483, 51);
            this.PriceTextBox.TabIndex = 65;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 19.8F);
            this.NameTextBox.Location = new System.Drawing.Point(677, 169);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(483, 51);
            this.NameTextBox.TabIndex = 63;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.Description.ForeColor = System.Drawing.Color.Green;
            this.Description.Location = new System.Drawing.Point(451, 496);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(206, 45);
            this.Description.TabIndex = 62;
            this.Description.Text = "Description:";
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.Phone.ForeColor = System.Drawing.Color.Green;
            this.Phone.Location = new System.Drawing.Point(490, 413);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(165, 45);
            this.Phone.TabIndex = 61;
            this.Phone.Text = "Quantity:";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.Email.ForeColor = System.Drawing.Color.Green;
            this.Email.Location = new System.Drawing.Point(551, 338);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(105, 45);
            this.Email.TabIndex = 60;
            this.Email.Text = "Price:";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.Green;
            this.Username.Location = new System.Drawing.Point(485, 258);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(171, 45);
            this.Username.TabIndex = 59;
            this.Username.Text = "Catagory:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.NameLabel.ForeColor = System.Drawing.Color.Green;
            this.NameLabel.Location = new System.Drawing.Point(536, 173);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(121, 45);
            this.NameLabel.TabIndex = 58;
            this.NameLabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(325, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 66);
            this.label1.TabIndex = 68;
            this.label1.Text = "Item Information";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1034, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 39);
            this.button3.TabIndex = 69;
            this.button3.Text = "BACK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Location = new System.Drawing.Point(1027, 690);
            this.SaveItem.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(139, 50);
            this.SaveItem.TabIndex = 71;
            this.SaveItem.Text = "Save Item";
            this.SaveItem.UseVisualStyleBackColor = true;
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // comboCategory
            // 
            this.comboCategory.Font = new System.Drawing.Font("SimSun", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Items.AddRange(new object[] {
            "Fruit",
            "Vegetable",
            "Rice",
            "Dal",
            "Sugar",
            "Salt",
            "Fish",
            "Meat"});
            this.comboCategory.Location = new System.Drawing.Point(677, 269);
            this.comboCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(483, 35);
            this.comboCategory.TabIndex = 75;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // itemPicUpload
            // 
            this.itemPicUpload.Location = new System.Drawing.Point(162, 535);
            this.itemPicUpload.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.itemPicUpload.Name = "itemPicUpload";
            this.itemPicUpload.Size = new System.Drawing.Size(103, 50);
            this.itemPicUpload.TabIndex = 76;
            this.itemPicUpload.Text = "Upload";
            this.itemPicUpload.UseVisualStyleBackColor = true;
            this.itemPicUpload.Click += new System.EventHandler(this.itemPicUpload_Click);
            // 
            // FarmerAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.itemPicUpload);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.SaveItem);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.itemPicture);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FarmerAddItem";
            this.Text = "Add Item Page";
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageList imageList1;
        private PictureBox itemPicture;
        private TextBox DescriptionTextBox;
        private TextBox QuantityTextBox;
        private TextBox PriceTextBox;
        private TextBox NameTextBox;
        private Label Description;
        private Label Phone;
        private Label Email;
        private Label Username;
        private Label NameLabel;
        private Label label1;
        private Button button3;
        private Button SaveItem;
        private ComboBox comboCategory;
        private Button itemPicUpload;
    }
}