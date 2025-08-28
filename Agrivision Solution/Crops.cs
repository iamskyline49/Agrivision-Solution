using Agrivision_Solution;
using Agrivision_Solution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrivision_Solution
{

    public partial class Crops : Form
    {
        private string userName;
        private string userType;
        public Crops(string userName, string userType)
        {
            InitializeComponent();
            this.userName = userName;
            this.userType=userType;

        }

        private void Crops_Load(object sender, EventArgs e)
        {

            this.Controls.Add(RTB2);
        }



        private void bBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
            FarmerHelpline form1 = new FarmerHelpline(userName , userType);
            form1.Show();
        }



        private void LLWhatsapp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://web.whatsapp.com/");
        }

        private void LLFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/prappo.sarker.9?mibextid=ZbWKwL");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void cbCropName_SelectedIndexChanged(object sender, EventArgs e) // corpname
        {
            lValue3.Text = cbCropName.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lValue4.Text = cbPrablem.Text;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) //fh
        {



        }

        




        private void button2_Click(object sender, EventArgs e) // clear button
        {
            // Clear ComboBoxes
            cbCropName.SelectedIndex = -1;
            cbPrablem.SelectedIndex = -1;

            // Clear RTB1 content
            if (RTB2 != null)
            {
                RTB2.Clear(); // This clears the RichTextBox content
            }

            // Optionally, clear any labels if needed
            lValue3.Text = "";
            lValue4.Text = "";
        }

        private void lInfo_Click(object sender, EventArgs e)
        {

        }

        private void bProfile_Click(object sender, EventArgs e)
        {

        }

        private void lValue4_Click(object sender, EventArgs e)
        {

        }

        private void bSearch2_Click_1(object sender, EventArgs e)
        {

            RTB2.Clear();
            RTB2.Font = new Font(RTB2.Font.FontFamily, 14);

            string cropName = cbCropName.Text.Trim().ToLower();
            string problem = cbPrablem.Text.Trim().ToLower();

            // Debugging output to check values


            // Ensure both fields are selected
            if (string.IsNullOrWhiteSpace(cropName) || string.IsNullOrWhiteSpace(problem))
            {
                MessageBox.Show("Please select both land size and crop type.", "Validation Error");
                return;
            }

            // Switch case 
            switch (problem)
            {
                case "fungaldiseases":
                    switch (cropName)
                    {
                        case "rice":
                            RTB2.Text = "Fungal diseases in rice, such as **Rice Blast** (*Magnaporthe oryzae*), **Sheath Blight** (*Rhizoctonia solani*), and **Brown Spot** (*Bipolaris oryzae*), can significantly reduce yield if not properly managed. To prevent these diseases, farmers should use **disease-resistant rice varieties**, ensure proper spacing to improve air circulation, and avoid excessive nitrogen fertilizer, which makes plants more susceptible to infections. **Field drainage** is also crucial, as waterlogged conditions promote fungal growth. Crop rotation with non-host plants and removing infected plant residues after harvest help break the fungal life cycle.  \r\n\r\nFor **biological control**, applying beneficial fungi such as *Trichoderma spp.* can help suppress fungal pathogens, while organic treatments like **neem oil** and compost tea strengthen plant immunity. In severe cases, **chemical control** is necessary, using **fungicides** such as **Tricyclazole** and **Carbendazim** for Rice Blast, **Hexaconazole** or **Propiconazole** for Sheath Blight, and **Mancozeb** or **Thiophanate-methyl** for Brown Spot. Regular monitoring of fields and early detection are crucial to prevent the rapid spread of fungal diseases. By integrating these cultural, biological, and chemical control measures, farmers can effectively protect their rice crops and improve yields. Would you like specific recommendations on application methods for these treatments?";
                            break;
                        case "corn":
                            RTB2.Text = "r"; // Provide details for Corn Fungal Diseases here
                            break;
                        case "suger_cane":
                            RTB2.Text = "Fungal Diseases in Sugarcane and How to Control Them\r\nSugarcane is prone to several fungal diseases, including Red Rot, Smut, Rust, and Wilt. To manage these, farmers should begin by planting disease-resistant varieties and using disease-free planting materials. Proper field drainage is crucial to prevent waterlogging, which promotes fungal growth. Crop rotation with legumes or rice can help disrupt the fungal life cycle. For biological control, applying Trichoderma spp., a beneficial fungus, and using neem oil or compost teas can help suppress fungal pathogens. If chemical control is needed, Copper Oxychloride, Mancozeb, Carbendazim, and Propiconazole are effective against various fungal infections when applied early in the disease cycle.";
                            break;
                        default:
                            RTB2.Text = "Information for the selected crop and fungal disease is not available.";
                            break;
                    }
                    break;

                case "bacterialdiseases":
                    switch (cropName)
                    {
                        case "rice":
                            RTB2.Text = "For bacterial diseases, like Bacterial Wilt and Fire Blight, it is crucial to remove infected plants immediately, avoid excessive nitrogen fertilizers, and practice crop rotation. Beneficial bacteria like Bacillus subtilis can help suppress bacterial growth, while copper-based sprays and antibiotics like Streptomycin are used in severe cases.";
                            break;
                        case "corn":
                            RTB2.Text = "### **Bacterial Diseases in Corn and How to Control Them**  \r\n\r\nBacterial diseases in corn, such as **Stewart’s Wilt** (*Pantoea stewartii*), **Goss’s Bacterial Wilt and Leaf Blight** (*Clavibacter michiganensis subsp. nebraskensis*), and **Bacterial Leaf Streak** (*Xanthomonas vasicola*), can cause significant damage by reducing photosynthesis, weakening plants, and lowering yield. Since bacterial infections have **no direct chemical cure**, effective management focuses on **prevention, biological control, and cultural practices**.  \r\n\r\nTo minimize the risk of infection, farmers should **plant resistant corn varieties**, practice **crop rotation** with non-host crops, and avoid excessive nitrogen fertilizer, which makes plants more susceptible to bacterial diseases. Controlling insect vectors, such as **flea beetles**, is essential because they spread bacteria from infected plants to healthy ones. Using **insecticides like Imidacloprid or Thiamethoxam** can help reduce flea beetle populations.";
                            break;
                        case "suger_cane":
                            RTB2.Text = "Bacterial Diseases in Sugarcane and How to Control Them\r\nRatoon Stunting Disease, Leaf Scald, and Gumming Disease are the most common bacterial diseases affecting sugarcane. To control bacterial diseases, farmers should use heat-treated cane setts (soaking at 50°C for 2 hours) and plant resistant varieties. Removing infected plants immediately can help stop the spread of bacteria. Bacillus subtilis, a beneficial bacterium, can be applied as a natural biocontrol agent to suppress harmful bacteria. Chemical treatments, including Copper Oxychloride and Streptomycin, help manage bacterial infections. Bordeaux mixture is another effective solution for controlling bacterial leaf scald.";
                            break;
                        default:
                            RTB2.Text = "Information for the selected crop and bacterial disease is not available.";
                            break;
                    }
                    break;

                case "viraldiseases":
                    switch (cropName)
                    {
                        case "rice":
                            RTB2.Text = "Viral diseases in rice, such as **Rice Tungro Disease** (caused by *Rice Tungro Bacilliform Virus* and *Rice Tungro Spherical Virus*) and **Rice Yellow Mottle Virus (RYMV)**, can severely affect plant growth and yield. Since there is **no direct chemical cure** for viral infections, prevention and management focus on controlling virus-spreading insects, such as **leafhoppers and aphids**, which transmit these viruses from plant to plant.  \r\n\r\nTo reduce the risk of infection, farmers should **plant virus-resistant rice varieties**, practice **crop rotation**, and remove infected plants immediately to prevent the disease from spreading.";
                            break;
                        case "corn":
                            RTB2.Text = "### **Viral Diseases in Corn and How to Control Them**  \r\n\r\nViral diseases in corn, such as **Maize Dwarf Mosaic Virus (MDMV)**, **Maize Chlorotic Mottle Virus (MCMV)** (which causes Maize Lethal Necrosis when combined with Sugarcane Mosaic Virus), and **High Plains Virus (HPV)**, can severely impact plant growth and yield. Since **there is no direct chemical cure for viral infections**, management focuses on **prevention, vector control, and cultural practices**.  \r\n\r\nTo reduce the risk of infection, farmers should **plant virus-resistant corn varieties**, practice **crop rotation**, and remove infected plants immediately to prevent further spread.";
                            break;
                        case "suger_cane":
                            RTB2.Text = "Viral Diseases in Sugarcane and How to Control Them\r\nSugarcane Mosaic Virus, Yellow Leaf Disease, and Fiji Disease are major viral threats to sugarcane. Since there are no direct chemical treatments for viral diseases, prevention is key. Use virus-free planting materials to avoid initial infections, and remove infected plants to prevent the spread. Insect vectors, such as aphids and whiteflies, are responsible for transmitting these viruses, so controlling these pests is crucial. Insecticides like Imidacloprid, Thiamethoxam, and neem-based sprays help control vector populations.";
                            break;
                        default:
                            RTB2.Text = "Information for the selected crop and viral disease is not available.";
                            break;
                    }
                    break;

                case "nematodediseases":
                    switch (cropName)
                    {
                        case "rice":
                            RTB2.Text = "Nematode diseases in rice, such as **Rice Root-Knot Nematode** (*Meloidogyne graminicola*) and **White Tip Nematode** (*Aphelenchoides besseyi*), can cause severe damage by stunting plant growth, reducing grain yield, and affecting root development. Since nematodes are soil-borne pests, managing them requires an integrated approach that includes **crop rotation, organic amendments, biological control, and, in severe cases, chemical treatments**.  \r\n\r\nTo reduce nematode infestations, farmers should **rotate rice with non-host crops** like legumes or marigolds, which naturally suppress nematode populations. **Soil solarization**, where fields are covered with plastic sheets for a few weeks before planting, helps kill nematodes in the soil.";
                            break;
                        case "corn":
                            RTB2.Text = "y"; // Provide details for Corn Nematode Diseases here
                            break;
                        case "suger_cane":
                            RTB2.Text = "Nematode Diseases in Sugarcane and How to Control Them\r\nRoot-Knot Nematode and Lesion Nematode can cause significant root damage and reduce plant growth. To manage nematodes, farmers should practice crop rotation with marigolds or legumes, as these plants naturally suppress nematodes. Organic amendments, such as compost and neem cake, improve soil health and support beneficial microorganisms that control nematode populations. Paecilomyces lilacinus, a natural fungus, can be applied as a biocontrol agent.";
                            break;
                        default:
                            RTB2.Text = "Information for the selected crop and nematode disease is not available.";
                            break;
                    }
                    break;

                default:
                    RTB2.Text = "Information for the selected disease and crop name is not available. Please try a different selection.";
                    break;
            }
        }

        private void bBackToMain_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FarmerDashboard f = new FarmerDashboard(userName, userType);
            f.Show();
        }
    }


}


