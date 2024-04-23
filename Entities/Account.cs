using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents an account entity, providing information about user accounts.
    /// </summary>
    internal class Account : IBaseClass
    {
        private string firstName;
        private string lastName;
        private string email;

        /// <summary>
        ///     Initializes a new instance of the Account class with the specified identifier, first name, last name, email, hashed
        ///     password, and registration date.
        /// </summary>
        /// <param name="id">The unique identifier of the account entity.</param>
        /// <param name="firstName">The first name of the account holder.</param>
        /// <param name="lastName">The last name of the account holder.</param>
        /// <param name="email">The email address associated with the account.</param>
        /// <param name="hashedPassword">The hashed password of the account.</param>
        /// <param name="registered">The registration date of the account.</param>
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

        /// <summary>
        ///     Initializes a new instance of the Account class with the specified first name, last name, email, and password.
        /// </summary>
        /// <param name="firstName">The first name of the account holder.</param>
        /// <param name="lastName">The last name of the account holder.</param>
        /// <param name="email">The email address associated with the account.</param>
        /// <param name="password">The password for the account.</param>
        public Account(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = GetHashedPassword(password);
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the account entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the first name of the account holder.
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the last name of the account holder.
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the email address associated with the account.
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the hashed password of the account.
        /// </summary>
        public string HashedPassword { get; set; }

        /// <summary>
        ///     Gets or sets the registration date of the account.
        /// </summary>
        public DateTime Registered { get; set; }

        /// <summary>
        ///     Computes the SHA-256 hash of the specified password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        public static string GetHashedPassword(string password)
        {
            if (password == string.Empty)
                throw new ArgumentException("Password cannot be empty.", nameof(password));

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + "cloud");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        ///     Returns a string representation of the account entity.
        /// </summary>
        /// <returns>A string representing the account entity.</returns>
        public override string ToString()
        {
            return Id == default
                ? $"{FirstName}, {LastName}, {Email}, pass*"
                : $"{Id}: {FirstName}, {LastName}, {Email}, pass*";
        }
    }
}