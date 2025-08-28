using AgriProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgriProject
{
    internal class Vendor : User
    {
        // Fields
        private string companyName;
        private long eIIN;
        private int tIN;

        // Constructor
        public Vendor(string userId, string userName, string password, string email, long phoneNumber1, int phoneNumber2, byte[] picture, 
              string location, string companyName, long eIIN, int tIN)
            : base(userId, userName, password, email, phoneNumber1, phoneNumber2, picture, location)
        {
            this.CompanyName = companyName;
            this.EIIN = eIIN;
            this.TIN = tIN;
        }

        public Vendor(string userId, string userName, string password, string email, long phoneNumber1, byte[] picture,
             string location, string companyName, long eIIN, int tIN)
           : base(userId, userName, password, email, phoneNumber1, picture, location)
        {
            this.CompanyName = companyName;
            this.EIIN = eIIN;
            this.TIN = tIN;
        }
      public Vendor(string userId , string password):base(userId, password)
        {

        }

        // Properties
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CompanyName cannot be null or empty.");
                companyName = value;
            }
        }

        public long EIIN
        {
            get { return eIIN; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("EIIN must be a positive number.");
                eIIN = value;
            }
        }

        public int TIN
        {
            get { return tIN; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("TIN must be a positive number.");
                tIN = value;
            }
        }

        public void BuyItem()
        {

        }
        protected override string GetRoleSpecificQuery()
        {
            return "SELECT COUNT(1) FROM VendorTable WHERE Username = @Username AND Password = @Password";
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

                string insertQuery = "INSERT INTO VendorTable (Name, Username, Password, Email, Phone, Address, EIIN, TIN, CompanyName, ProfilePicture) " +
                                     "VALUES (@Name, @Username, @Password, @Email, @Phone, @Address, @EIIN, @TIN, @CompanyName, @ProfilePicture)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Name", UserName);
                    cmd.Parameters.AddWithValue("@Username", UserId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", PhoneNumber1);
                    cmd.Parameters.AddWithValue("@Address", Location);
                    cmd.Parameters.AddWithValue("@ProfilePicture", Picture ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EIIN", EIIN);
                    cmd.Parameters.AddWithValue("@TIN", TIN);
                    cmd.Parameters.AddWithValue("@CompanyName", CompanyName);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

//cmd.Parameters.AddWithValue("@VendorId", UserId);
//cmd.Parameters.AddWithValue("@VendorName", UserName);
//cmd.Parameters.AddWithValue("@Address", Location);
//cmd.Parameters.AddWithValue("@Phone", PhoneNumber1);
//cmd.Parameters.AddWithValue("@Email", Email);
//cmd.Parameters.AddWithValue("@Password", Password);
//cmd.Parameters.AddWithValue("@Picture", Picture ?? (object)DBNull.Value);
//cmd.Parameters.AddWithValue("@TIN", TIN);
//cmd.Parameters.AddWithValue("@EIIN", EIIN);
//cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
