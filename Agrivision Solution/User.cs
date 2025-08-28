using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProject
{
    internal abstract class User : ILogin , IRecover , ISignup
    {
        // Fields
        private string userId;
        private string userName;
        private string password;
        private string email;
        private long  phoneNumber1;
        private int phoneNumber2;
        private byte[] picture;
        private string location;
        private string role;
        protected string ConnectionString { get; set; }

        public User(string connectionString)
        {
            ConnectionString = connectionString;
        }
        // Constructor
        protected User(string UserId, string Password)
        {
            this.userId = UserId;
            this.password = Password;
        }
        protected User(string userId, string userName, string password, string email, long phoneNumber1, int phoneNumber2, byte[] picture, string location)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
            this.picture = picture;
            this.location = location;
        }
        protected User(string userId, string userName, string password, string email, long phoneNumber1, byte[] picture, string location)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phoneNumber1 = phoneNumber1;
            this.picture = picture;
            this.location = location;
        }
        public User(string username, string password, string role)
        {
            this.userName = username;
            this.password = password;
            this.role = role;
        }



        // Properties
        public string UserId
        {
            get { return userId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserId cannot be null or empty.");
                userId = value;
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserName cannot be null or empty.");
                userName = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 6)
                    throw new ArgumentException("Password must be at least 6 characters long.");
                password = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("Invalid email format.");
                email = value;
            }
        }

        public long PhoneNumber1
        {
            get { return phoneNumber1; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("PhoneNumber1 must be positive.");
                phoneNumber1 = value;
            }
        }

        public int PhoneNumber2
        {
            get { return phoneNumber2; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("PhoneNumber2 must be positive.");
                phoneNumber2 = value;
            }
        }

        public byte[] Picture
        {
            get { return picture; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Picture cannot be null or empty.");
                picture = value;
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Location cannot be null or empty.");
                location = value;
            }
        }

        public void EditProfile()
        {

        }


        protected abstract string GetRoleSpecificQuery();

        public virtual bool Login(string connectionString, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = GetRoleSpecificQuery();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", UserId);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 1; // Login successful
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                errorMessage = $"Database error: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                errorMessage = $"An unexpected error occurred: {ex.Message}";
            }

            return false; // Login failed
        }

        public virtual void RecoverPassword(string password)
        {
            throw new NotImplementedException();
        }

        public virtual void Signup(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
