using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class Account : IBaseClass
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string hashedPassword;
        private DateTime registered;

        public Account(int id, string firstName, string lastName, string email, string hashedPassword, DateTime registered)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
            Registered = registered;
        }

        public Account(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = GetHashedPassword(password);
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("The first name must be at least 3 characters long.", nameof(FirstName));
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("The last name must be at least 3 characters long.", nameof(LastName));
                }
                lastName = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if(!Regex.IsMatch(value, @"@"))
                {
                    throw new ArgumentException("The email must contain the '@' character.", nameof(Email));
                }
                email = value;
            }
        }

        public string HashedPassword
        {
            get { return hashedPassword; }
            set { hashedPassword = value; }
        }

        public DateTime Registered
        {
            get { return registered; }
            set { registered = value; }
        }

        public static string GetHashedPassword(string password)
        {
            if(password == string.Empty)
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }
            SHA256 sha256 = SHA256.Create();

            byte[] bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password + "cloud"));
            byte[] hashedBytes = sha256.ComputeHash(bytes);
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            return hashedPassword;
        }

        public override string ToString()
        {
            if(ID == default)
            {
                return $"{FirstName}, {LastName}, {Email}, pass*";
            }

            return $"{ID}: {FirstName}, {LastName}, {Email}, pass*";
        }
    }
}
