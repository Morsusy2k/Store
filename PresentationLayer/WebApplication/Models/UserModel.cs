using Store.BusinessLogicLayer.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.PresentationLayer.WebApplication.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(string firstname, string lastname, string emailaddress, string phonenumber, string address, string password, DateTime lastlogin, byte[] version, byte?[] picture = null)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = emailaddress;
            PhoneNumber = phonenumber;
            Address = address;
            Picture = picture;
            Password = password;
            LastLogin = lastlogin;
            Version = version;
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("First name")]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Phone number")]
        [StringLength(25, MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }

        [DisplayName("Profile picture")]
        public byte?[] Picture { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public DateTime LastLogin { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator User(UserModel um)
        {
            if (um == null)
                return null;

            User user = new User(um.FirstName, um.LastName, um.EmailAddress, um.PhoneNumber, um.Address, um.Password, um.LastLogin, um.Version, um.Picture)
            {
                Id = um.Id
            };

            return user;
        }

        public static implicit operator UserModel(User u)
        {
            if (u == null)
                return null;

            UserModel user = new UserModel(u.FirstName, u.LastName, u.EmailAddress, u.PhoneNumber, u.Address, u.Password, u.LastLogin, u.Version, u.Picture)
            {
                Id = u.Id
            };

            return user;
        }
    }
}
