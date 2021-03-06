﻿using System;

namespace Store.DataAccessLayer.Models
{
    public class User
    {
        public User() { }
        public User(int id, string firstname, string lastname, string emailaddress, string phonenumber, string address, string password, DateTime lastlogin, byte[] version, byte?[] picture = null)
        {
            Id = id;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public byte?[] Picture { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public byte[] Version { get; set; }
    }

    public class Verification
    {
        public Verification() { }
        public Verification(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
