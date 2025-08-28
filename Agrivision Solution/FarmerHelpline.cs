using Agrivision_Solution;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace Agrivision_Solution
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class FarmerHelpline : Form



    {
        private string userName;
        private string userType;




        public FarmerHelpline(string userName , string userType)
        {
            InitializeComponent();


            this. userName = userName;
            this.userType = userType;


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            RTB1 = new RichTextBox
            {
                Location = new Point(327, 133), 
                Size = new Size(730, 574),      
                ReadOnly = true
            };

            
            this.Controls.Add(RTB1);
        }


        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lValue1.Text = cbType.Text; 
            //Button btn = (Button)sender;
            //input += btn.Text;
            //dataGridView1.Text = input;
        }

        private void cbLandSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            lValue2.Text = cbLandSize.Text; // Assuming lValue2 is a Label to display the selected value
                                            // Button btn = (Button)sender;
                                            //input += btn.Text;

        }

        private void LLWhatsap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            Process.Start("https://web.whatsapp.com/");


        }

        private void LLFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            Process.Start("https://www.facebook.com/prappo.sarker.9?mibextid=ZbWKwL");


        }

        private void LLGmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {




        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            
        }



        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        private void bCrops_Click(object sender, EventArgs e)
        {

            Crops crops = new Crops(userName,userType);
            crops.Show();
            Visible = false;
        }

        private void lEnterLandSize_Click(object sender, EventArgs e)
        {

        }

        private void lSelected2_Click(object sender, EventArgs e)
        {

        }

        private void lValue2_Click(object sender, EventArgs e)
        {

        }

        private void lEnterType_Click(object sender, EventArgs e)
        {

        }

        private void lSelected1_Click(object sender, EventArgs e)
        {

        }

        private void lValue1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Clear ComboBoxes
            cbType.SelectedIndex = -1;
            cbLandSize.SelectedIndex = -1;

            // Clear RTB1 content
            if (RTB1 != null)
            {
                RTB1.Clear(); // This clears the RichTextBox content
            }

            // Optionally, clear any labels if needed
            lValue1.Text = "";
            lValue2.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {

        }

        private void bProfile_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bCrops_Click_1(object sender, EventArgs e)
        {

            Crops crops = new Crops(userName, userType);
            crops.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FarmerDashboard f = new FarmerDashboard(userName, userType);
            f.Show();
        }

        private void bSearch_Click_1(object sender, EventArgs e)
        {
            RTB1.Font = new Font(RTB1.Font.FontFamily, 10);
            // Get selected values from ComboBoxes
            string landSize = cbLandSize.Text;
            string cropType = cbType.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(landSize) || string.IsNullOrWhiteSpace(cropType))
            {
                MessageBox.Show("Please select both land size and crop type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {

                // Check the inputs and provide information
                if (landSize == "1-2 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 1 to 2 acres, start by preparing the soil through tilling, removing weeds, and testing to ensure a pH of 6.0–6.8. Add organic matter and fertilizers based on soil test results. " +
                                "Choose high-yield, disease-resistant seeds, and plant them in rows spaced 30–36 inches apart, with seeds 6–12 inches apart within the rows and 1–2 inches deep. This will result in about 42,000–51,000 plants. " +
                                "Provide consistent watering, ensuring 1–1.5 inches of water per week, especially during key growth stages like tasseling and silking. Fertilize with nitrogen in split doses and add phosphorus and potassium as needed. " +
                                "Manage weeds with pre- and post-emergence herbicides or manual methods, and control pests using integrated pest management (IPM) practices. " +
                                "Harvest grain corn when kernels reach 20–25% moisture, sweet corn at the milk stage, and silage at the dough stage. " +
                                "Expected yields for 1.5 acres are 150–225 bushels for grain corn, 15–18 tons for sweet corn, and 30–37.5 tons for silage. " +
                                "Scale up inputs such as seeds, fertilizers, and labor proportionally for the larger area.";
                }
                else if (landSize == "2-3 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 2 to 3 acres, start by preparing the soil through tilling, removing weeds, and testing to ensure a pH of 6.0–6.8. Add organic matter and fertilizers based on soil test results. " +
                                "Choose high-yield, disease-resistant seeds, and plant them in rows spaced 30–36 inches apart, with seeds 6–12 inches apart within the rows and 1–2 inches deep. This will result in about 42,000–51,000 plants. " +
                                "Provide consistent watering, ensuring 1–1.5 inches of water per week, especially during key growth stages like tasseling and silking. Fertilize with nitrogen in split doses and add phosphorus and potassium as needed. " +
                                "Manage weeds with pre- and post-emergence herbicides or manual methods, and control pests using integrated pest management (IPM) practices. " +
                                "Harvest grain corn when kernels reach 20–25% moisture, sweet corn at the milk stage, and silage at the dough stage. " +
                                "Expected yields for 1.5 acres are 150–225 bushels for grain corn, 15–18 tons for sweet corn, and 30–37.5 tons for silage. " +
                                "Scale up inputs such as seeds, fertilizers, and labor proportionally for the larger area.";
                }
                else if (landSize == "3-4 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 3 to 4 acres, prepare the soil by tilling, removing weeds, and testing to ensure a pH of 6.0–6.8. Incorporate organic matter and fertilizers as per soil test recommendations. Select high-yield, disease-resistant seeds suitable for your region. Plant the seeds in rows spaced 30–36 inches apart, with 6–12 inches between seeds within each row and a depth of 1–2 inches, resulting in about 56,000–68,000 plants across 2 acres. Ensure consistent irrigation, providing 1–1.5 inches of water per week, especially during critical stages like tasseling and silking. Fertilize with nitrogen in split applications and add phosphorus and potassium as required. Control weeds using pre- and post-emergence herbicides or manual methods, and manage pests with integrated pest management (IPM) strategies. Harvest grain corn at 20–25% moisture, sweet corn at the milk stage, and silage at the dough stage. Expected yields for 2 acres are 200–300 bushels of grain corn, 20–24 tons of sweet corn, or 40–50 tons of silage. Scale up all inputs proportionally for the 2-acre area.";
                }
                else if (landSize == "4-5 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 4–5 acres, start by testing the soil (pH 6.0–6.8) and tilling it 6–8 inches deep. Apply fertilizers based on soil test results, ensuring sufficient nitrogen for optimal growth. Choose a high-yield hybrid variety and plant seeds in rows 30 inches apart, with 8–12 inches between seeds at a depth of 1–2 inches. Provide consistent irrigation (1–1.5 inches per week) and control weeds using mulching or herbicides. Monitor for pests like armyworms and corn borers, applying pesticides if needed. Side-dress nitrogen at the knee-high stage to boost yields. Harvest sweet corn in 60–90 days or grain corn in 90–120 days when kernels are fully dry. 🌽";
                }
                else if (landSize == "5-6 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 5–6 acres, begin with soil testing (pH 6.0–6.8) and deep tilling (6–8 inches). Apply fertilizers rich in nitrogen, phosphorus, and potassium based on soil test results. Select a high-yield hybrid variety and plant seeds in rows 30 inches apart, spacing them 8–12 inches apart at a depth of 1–2 inches. Ensure consistent irrigation (1–1.5 inches per week) and manage weeds using herbicides or mechanical cultivation. Monitor for pests like armyworms and corn borers, applying pesticides if necessary. Side-dress nitrogen at the knee-high stage for optimal growth. Harvest sweet corn in 60–90 days or grain corn in 90–120 days when kernels are fully dry. 🌽";
                }
                else if (landSize == "6-7 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 6–7 acres, start with soil testing (pH 6.0–6.8) and deep tilling (6–8 inches). Apply fertilizers rich in nitrogen, phosphorus, and potassium based on soil needs. Select a high-yield hybrid variety and plant seeds in rows 30 inches apart, spacing them 8–12 inches apart at a depth of 1–2 inches. Ensure proper irrigation (1–1.5 inches per week) and control weeds using herbicides or mechanical cultivation. Regularly monitor for pests like armyworms and corn borers, applying pesticides if required. Side-dress nitrogen at the knee-high stage to enhance growth. Harvest sweet corn in 60–90 days or grain corn in 90–120 days when kernels are fully dry. 🌽";
                }
                else if (landSize == "7-8 acre" && cropType.Equals("Corn", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow corn on 7–8 acres, start with soil testing (pH 6.0–6.8) and deep tilling (6–8 inches). Apply fertilizers rich in nitrogen, phosphorus, and potassium based on soil test results. Choose a high-yield hybrid variety and plant seeds in rows 30 inches apart, spacing them 8–12 inches apart at a depth of 1–2 inches. Maintain regular irrigation (1–1.5 inches per week) and control weeds using herbicides or mechanical cultivation. Monitor for pests like armyworms and corn borers, applying pesticides if necessary. Side-dress nitrogen at the knee-high stage to boost plant growth. Harvest sweet corn in 60–90 days or grain corn in 90–120 days when kernels are fully dry. 🌽";
                }
                else if (landSize == "1-2 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 1–2 acres, begin by testing the soil (pH 5.5–7.0) and ensuring good drainage, then plow and level the field for uniform water retention. Choose a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them before sowing. You can either direct-seed or transplant 2–3-week-old seedlings. Maintain 2–4 inches of water in the field and manage weeds through manual weeding or herbicides. Apply nitrogen-rich fertilizer during tillering and panicle initiation, and monitor for pests like stem borers and diseases like blast, using pesticides if needed. Harvest the rice in 90–120 days when grains are golden, then dry them to 12–14% moisture before storage. 🌾";
                }
                else if (landSize == "2-3 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 2–3 acres, start by testing the soil (pH 5.5–7.0) and ensuring good drainage, followed by plowing and leveling the field for uniform water distribution. Choose a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them for sowing. You can either direct-seed or transplant 2–3-week-old seedlings. Keep the field flooded with 2–4 inches of water and control weeds through manual weeding or herbicides. Apply nitrogen-rich fertilizer at the tillering and panicle initiation stages, and monitor for pests like stem borers or diseases such as blast, using pesticides if necessary. Harvest the rice in 90–120 days when the grains turn golden and dry them to 12–14% moisture for storage. 🌾";
                }
                else if (landSize == "3-4 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 3–4 acres, start by testing the soil (pH 5.5–7.0) and ensuring proper drainage. Plow and level the field to ensure uniform water distribution. Choose a high-yield, disease-resistant rice variety, soak the seeds for 24 hours, and dry them before sowing. You can opt for direct seeding or transplanting 2–3-week-old seedlings. Maintain 2–4 inches of standing water throughout the growing season and manage weeds through manual weeding or herbicides. Apply nitrogen-rich fertilizers during the tillering and panicle initiation stages, and monitor for pests like stem borers and diseases like blast, using pesticides when necessary. Harvest the rice in 90–120 days when the grains are golden and fully matured, then dry them to 12–14% moisture for storage. 🌾";
                }
                else if (landSize == "4-5 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 4–5 acres, start by testing the soil (pH 5.5–7.0) and ensuring proper drainage. Plow and level the field to maintain uniform water distribution. Select a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them before sowing. Use either direct seeding or transplant 2–3-week-old seedlings. Maintain 2–4 inches of standing water throughout the season and control weeds through manual weeding or herbicides. Apply nitrogen-rich fertilizers at the tillering and panicle initiation stages, and monitor for pests like stem borers and diseases like blast, using pesticides if required. Harvest the rice in 90–120 days when grains turn golden and fully mature, then dry them to 12–14% moisture for proper storage. 🌾";
                }
                else if (landSize == "5-6 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 5–6 acres, start with soil testing (pH 5.5–7.0) and proper drainage. Plow and level the field for uniform water retention. Choose a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them before sowing. Use either direct seeding or transplant 2–3-week-old seedlings. Maintain 2–4 inches of standing water throughout the season and manage weeds using manual weeding or herbicides. Apply nitrogen-rich fertilizers during the tillering and panicle initiation stages, and monitor for pests like stem borers and diseases like blast, applying pesticides if needed. Harvest in 90–120 days when grains turn golden, then dry them to 12–14% moisture for proper storage. 🌾";
                }
                else if (landSize == "6-7 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 6–7 acres, start by testing the soil (pH 5.5–7.0) and ensuring proper drainage. Plow and level the field for uniform water retention. Select a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them before sowing. Use direct seeding or transplant 2–3-week-old seedlings. Maintain 2–4 inches of standing water throughout the growing season and manage weeds using manual weeding or herbicides. Apply nitrogen-rich fertilizers at the tillering and panicle initiation stages, and monitor for pests like stem borers and diseases such as blast, using pesticides if necessary. Harvest in 90–120 days when the grains turn golden, then dry them to 12–14% moisture for proper storage. 🌾";
                }
                else if (landSize == "7-8 acre" && cropType.Equals("Rice", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow rice on 7–8 acres, start by testing the soil (pH 5.5–7.0) and ensuring proper drainage. Plow and level the field for uniform water retention. Choose a high-yield, disease-resistant variety, soak seeds for 24 hours, and dry them before sowing. Use either direct seeding or transplant 2–3-week-old seedlings. Maintain 2–4 inches of standing water throughout the growing season and control weeds using manual weeding or herbicides. Apply nitrogen-rich fertilizers at the tillering and panicle initiation stages, and monitor for pests like stem borers and diseases such as blast, using pesticides if required. Harvest in 90–120 days when the grains turn golden, then dry them to 12–14% moisture for proper storage. 🌾";
                }
                else if (landSize == "1-2 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 1–2 acres, start by testing the soil (pH 5.5–8.0) and preparing the land with deep plowing (10–12 inches) for good root penetration. Choose a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and fertilizers rich in nitrogen, phosphorus, and potassium. Ensure consistent irrigation, especially during the early growth stages, and control weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, using pesticides if necessary. Harvest in 10–14 months when the stalks turn yellowish and hard, ensuring maximum sugar content. 🌱";
                }
                else if (landSize == "2-3 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 2–3 acres, begin with soil testing (pH 5.5–8.0) and deep plowing (10–12 inches) for proper root growth. Select a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and balanced fertilizers rich in nitrogen, phosphorus, and potassium. Maintain regular irrigation, especially during germination and tillering stages, and control weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, applying pesticides if needed. Harvest in 10–14 months when the stalks mature, turn yellowish, and have maximum sugar content. 🌱";
                }
                else if (landSize == "3-4 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 3–4 acres, start by testing the soil (pH 5.5–8.0) and deep plowing (10–12 inches) for proper root development. Choose a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and fertilizers rich in nitrogen, phosphorus, and potassium. Ensure consistent irrigation, especially during germination and tillering stages, and control weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, applying pesticides if necessary. Harvest in 10–14 months when stalks turn yellowish, harden, and have maximum sugar content. 🌱";
                }
                else if (landSize == "4-5 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 4–5 acres, start with soil testing (pH 5.5–8.0) and deep plowing (10–12 inches) for proper root establishment. Select a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and fertilizers rich in nitrogen, phosphorus, and potassium. Maintain regular irrigation, especially during germination and tillering stages, and manage weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, using pesticides if needed. Harvest in 10–14 months when stalks mature, turn yellowish, and reach peak sugar content. 🌱";
                }
                else if (landSize == "5-6 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 5–6 acres, start by testing the soil (pH 5.5–8.0) and deep plowing (10–12 inches) for proper root establishment. Choose a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and fertilizers rich in nitrogen, phosphorus, and potassium. Ensure consistent irrigation, especially during germination and tillering stages, and control weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, applying pesticides if needed. Harvest in 10–14 months when stalks mature, turn yellowish, and reach peak sugar content. 🌱";
                }
                else if (landSize == "6-7 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 6–7 acres, begin with soil testing (pH 5.5–8.0) and deep plowing (10–12 inches) for optimal root growth. Select a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and balanced fertilizers rich in nitrogen, phosphorus, and potassium. Ensure consistent irrigation, especially during germination and tillering, and manage weeds through manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, applying pesticides when necessary. Harvest after 10–14 months when the stalks are mature, yellowish, and have reached their maximum sugar content. 🌱";
                }
                else if (landSize == "7-8 acre" && cropType.Equals("Suger cane", StringComparison.OrdinalIgnoreCase))
                {
                    RTB1.Text = "To grow sugarcane on 7–8 acres, start by testing the soil (pH 5.5–8.0) and deep plowing (10–12 inches) for proper root development. Select a high-yield, disease-resistant variety and plant healthy, disease-free cane sets (2–3 budded) in furrows spaced 4–5 feet apart. Apply organic manure and fertilizers rich in nitrogen, phosphorus, and potassium. Maintain regular irrigation, especially during germination and tillering stages, and control weeds using manual weeding or herbicides. Monitor for pests like borers and diseases such as red rot, using pesticides if necessary. Harvest in 10–14 months when the stalks mature, turn yellowish, and have maximum sugar content. 🌱";
                }
                else
                {
                    RTB1.Text = "Information for the selected land size and crop type is not available. Please try a different selection.";
                }
            }

            // Implement search functionality here
            //MessageBox.Show("Search feature is under development!");
        }
    }
}
