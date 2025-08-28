using AgriProject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgriProject
{
    internal class Farmer : User
    {
        // Fields
        private bool orderCancelAcceptance;
        private double orderCancelFinePercentage;

        // Constructor

        public Farmer(string userId, string password) : base(userId, password)
        {

        }
        public Farmer(string userId, string userName, string password, string email, long phoneNumber1, int phoneNumber2, byte[] picture, string location, bool orderCancelAcceptance, double orderCancelFinePercentage)
            : base(userId, userName, password, email, phoneNumber1, phoneNumber2, picture, location)
        {
            this.OrderCancelAcceptance = orderCancelAcceptance;
            this.OrderCancelFinePercentage = orderCancelFinePercentage;
        }
        public Farmer(string userId, string userName, string password, string email, long phoneNumber1, byte[] picture, string location)
            : base(userId, userName, password, email, phoneNumber1, picture, location)
        {

        }


        // Properties
        public bool OrderCancelAcceptance
        {
            get { return orderCancelAcceptance; }
            set { orderCancelAcceptance = value; }
        }

        public double OrderCancelFinePercentage
        {
            get { return orderCancelFinePercentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("OrderCancelFinePercentage must be between 0 and 100.");
                orderCancelFinePercentage = value;
            }
        }

        // Methods
        public void AddItem()
        {
            // Implementation for adding an item
        }

        public void UpdateItem()
        {
            // Implementation for updating an item
        }

        public void RemoveItem()
        {
            // Implementation for removing an item
        }

        protected override string GetRoleSpecificQuery()
        {
            return "SELECT COUNT(1) FROM FarmerTable WHERE Username = @Username AND Password = @Password";
        }

        public override void RecoverPassword(string password)
        {
            throw new NotImplementedException();
        }

        public override void Signup(string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string insertQuery = "INSERT INTO FarmerTable (Name, Username, Password, Email, Phone, Address, ProfilePicture) " +
                                     "VALUES (@Name, @Username, @Password, @Email, @Phone, @Address, @ProfilePicture)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {

                    cmd.Parameters.AddWithValue("@Name", UserName);
                    cmd.Parameters.AddWithValue("@Username", UserId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", PhoneNumber1);
                    cmd.Parameters.AddWithValue("@Address", Location);
                    cmd.Parameters.AddWithValue("@ProfilePicture", Picture ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}

//cmd.Parameters.AddWithValue("@FarmerId", UserId);
//cmd.Parameters.AddWithValue("@FarmerName", UserName);
//cmd.Parameters.AddWithValue("@Address", Location);
//cmd.Parameters.AddWithValue("@Phone", PhoneNumber1);
//cmd.Parameters.AddWithValue("@Email", Email);
//cmd.Parameters.AddWithValue("@Password", Password);
//cmd.Parameters.AddWithValue("@Picture", Picture ?? (object)DBNull.Value);

