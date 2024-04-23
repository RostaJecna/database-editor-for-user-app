using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class Account : IBaseClass
    {
        private string firstName;
        private string lastName;
        private string email;

        public Account(int id, string firstName, string lastName, string email, string hashedPassword,
            DateTime registered)
        {
            Id = id;
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

        public int Id { get; set; }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("The first name must be at least 3 characters long.",
                        nameof(FirstName));
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("The last name must be at least 3 characters long.", nameof(LastName));
                lastName = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (!Regex.IsMatch(value, @"@"))
                    throw new ArgumentException("The email must contain the '@' character.", nameof(Email));
                email = value;
            }
        }

        public string HashedPassword { get; set; }

        public DateTime Registered { get; set; }

        public static string GetHashedPassword(string password)
        {
            if (password == string.Empty) throw new ArgumentException("Password cannot be empty.", nameof(password));

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + "cloud");

            SHA256 sha256 = SHA256.Create();

            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public override string ToString()
        {
            return Id == default ? $"{FirstName}, {LastName}, {Email}, pass*" : $"{Id}: {FirstName}, {LastName}, {Email}, pass*";
        }
    }
}