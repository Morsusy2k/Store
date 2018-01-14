using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class User
    {
        private string firstname { get; set; }
        private string lastname { get; set; }
        private string emailaddress { get; set; }
        private string phonenumber { get; set; }
        private string address { get; set; }
        private string password { get; set; }
        private DateTime lastlogin { get; set; }
        private bool activated { get; set; }

        public User() { }
        public User(string firstname, string lastname, string emailaddress, string phonenumber, string address, string password, DateTime lastlogin, bool activated, byte?[] picture = null)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = emailaddress;
            PhoneNumber = phonenumber;
            Address = address;
            Picture = picture;
            Password = password;
            LastLogin = lastlogin;
            Activated = activated;
        }
        public int Id { get; set; }
        public byte[] Version { get; set; }
        public byte?[] Picture { get; set; }
        public string FirstName
        {
            get
            {
                Debug.Assert(firstname != null);
                return firstname;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("FirstName", "Valid firstname is mandatory!");

                string oldValue = firstname;
                try
                {
                    firstname = value;
                }
                catch
                {
                    firstname = oldValue;
                    throw;
                }
            }
        }
        public string LastName
        {
            get
            {
                Debug.Assert(lastname != null);
                return lastname;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("LastName", "Valid lastname is mandatory!");

                string oldValue = lastname;
                try
                {
                    lastname = value;
                }
                catch
                {
                    lastname = oldValue;
                    throw;
                }
            }
        }
        public string EmailAddress
        {
            get
            {
                Debug.Assert(emailaddress != null);
                return emailaddress;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("EmailAddress", "Valid emailaddress is mandatory!");

                string oldValue = emailaddress;
                try
                {
                    emailaddress = value;
                }
                catch
                {
                    emailaddress = oldValue;
                    throw;
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                Debug.Assert(phonenumber != null);
                return phonenumber;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("PhoneNumber", "Valid phonenumber is mandatory!");

                string oldValue = phonenumber;
                try
                {
                    phonenumber = value;
                }
                catch
                {
                    phonenumber = oldValue;
                    throw;
                }
            }
        }
        public string Address
        {
            get
            {
                Debug.Assert(address != null);
                return address;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Address", "Valid address is mandatory!");

                string oldValue = address;
                try
                {
                    address = value;
                }
                catch
                {
                    address = oldValue;
                    throw;
                }
            }
        }
        public string Password
        {
            get
            {
                Debug.Assert(password != null);
                return password;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Password", "Valid password is mandatory!");

                string oldValue = password;
                try
                {
                    password = value;
                }
                catch
                {
                    password = oldValue;
                    throw;
                }
            }
        }
        public DateTime LastLogin
        {
            get
            {
                Debug.Assert(lastlogin != null);
                return lastlogin;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("lastLogin", "Valid lastlogin is mandatory!");

                DateTime oldValue = lastlogin;
                try
                {
                    lastlogin = value;
                }
                catch
                {
                    lastlogin = oldValue;
                    throw;
                }
            }
        }
        public bool Activated
        {
            get
            {
                return activated;
            }

            set
            {
                bool oldValue = activated;
                try
                {
                    activated = value;
                }
                catch
                {
                    activated = oldValue;
                    throw;
                }
            }
        }
    }

    public class Verification
    {
        private string code { get; set; }

        public Verification() { }
        public Verification(int userId)
        {
            UserId = userId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

    }

}
