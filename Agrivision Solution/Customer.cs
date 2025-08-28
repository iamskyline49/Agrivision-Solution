using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProject
{
    internal class Customer : User
    {
        // Fields
        private long nId;

        // Constructor

        public Customer(string userId, string password) : base(userId, password)
        {

        }
        public Customer(string userId, string userName, string password, string email, long phoneNumber1, int phoneNumber2, byte[] picture, string location, long nId)
            : base(userId, userName, password, email, phoneNumber1, phoneNumber2, picture, location)
        {
            this.NId = nId;
        }
        public Customer(string userId, string userName, string password, string email, long phoneNumber1, byte[] picture, string location, long nId)
          : base(userId, userName, password, email, phoneNumber1, picture, location)
        {
           
        }

        public Customer(string userId, string userName, string password, string email, long phoneNumber1, byte[] picture, string location) : base(userId, userName, password, email, phoneNumber1, picture, location)
        {
        }

        // Properties
        public long NId
        {
            get { return nId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("NId must be a positive number.");
                nId = value;
            }
        }
        public void BuyItem()
        {

        }
        protected override string GetRoleSpecificQuery()
        {
            return "SELECT COUNT(1) FROM GeneralCustomerTable WHERE Username = @Username AND Password = @Password";
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

                string insertQuery = "INSERT INTO GeneralCustomerTable (Name, Username, Password, Email, Phone, Address, ProfilePicture) " +
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
    