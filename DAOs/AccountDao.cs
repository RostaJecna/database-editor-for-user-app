using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'Account' entity.
    /// </summary>
    internal class AccountDao : IDao<Account>
    {
        /// <summary>
        ///     Retrieves all account entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of account entities.</returns>
        public IEnumerable<Account> GetAll()
        {
            const string query = "SELECT * FROM Account";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5)
                        );

                        yield return account;
                    }
                }
            }
        }

        /// <summary>
        ///     Adds a new account entity to the database.
        /// </summary>
        /// <param name="element">The account entity to add.</param>
        /// <exception cref="Exception">
        ///     Thrown if an account with the same email already exists in the database or if a database
        ///     error occurs.
        /// </exception>
        public void Add(Account element)
        {
            if (HasDuplicate(element)) throw new Exception("Email must be unique.");

            const string query = "INSERT INTO Account (FirstName, LastName, Email, HashedPassword) VALUES" +
                                 "(@FirstName, @LastName, @Email, @HashedPassword);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@FirstName", element.FirstName);
                command.Parameters.AddWithValue("@LastName", element.LastName);
                command.Parameters.AddWithValue("@Email", element.Email);
                command.Parameters.AddWithValue("@HashedPassword", element.HashedPassword);

                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        ///     Updates an existing account entity in the database.
        /// </summary>
        /// <param name="element">The updated account entity.</param>
        /// <exception cref="Exception">
        ///     Thrown if an account with the same email already exists in the database or if a database
        ///     error occurs.
        /// </exception>
        public void Edit(Account element)
        {
            if (HasDuplicate(element)) throw new Exception("Duplicate email found. Please provide a unique email.");

            const string query = "UPDATE Account SET FirstName = @FirstName, " +
                                 "LastName = @LastName," +
                                 "Email = @Email," +
                                 "HashedPassword = @HashedPassword" +
                                 " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@FirstName", element.FirstName);
                command.Parameters.AddWithValue("@LastName", element.LastName);
                command.Parameters.AddWithValue("@Email", element.Email);
                command.Parameters.AddWithValue("@HashedPassword", element.HashedPassword);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Deletes an account entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the account entity to delete.</param>
        /// <exception cref="InvalidOperationException">Thrown if the account has references in the 'Access' table.</exception>
        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException("Cannot delete Account with references in Access table.");

            const string query = "DELETE FROM Account WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        ///     Retrieves an account entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the account entity to retrieve.</param>
        /// <returns>The account entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no account entity with the provided ID is found in the database.</exception>
        public Account GetById(int id)
        {
            const string query = "SELECT * FROM Account WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new Account(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetDateTime(5)
                    );
                }
            }
        }

        /// <summary>
        ///     Checks if any references to the account entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the account entity to check.</param>
        /// <returns>True if references to the account entity exist, otherwise false.</returns>
        public bool HasReferences(int id)
        {
            const string query = "SELECT 1 FROM Access WHERE AccountID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        /// <summary>
        ///     Checks if an account entity with the same email already exists in the database.
        /// </summary>
        /// <param name="element">The account entity to check for duplicates.</param>
        /// <returns>True if a duplicate account entity exists, otherwise false.</returns>
        public bool HasDuplicate(Account element)
        {
            const string query = "SELECT ID FROM Account WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@Email", element.Email);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return false;
                    reader.Read();
                    return element.Id != reader.GetInt32(0);
                }
            }
        }

        /// <summary>
        ///     Checks if an account entity with the provided ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the account entity to check.</param>
        /// <returns>True if an account entity with the provided ID exists, otherwise false.</returns>
        public static bool Exist(int id)
        {
            const string query = "SELECT 1 FROM Account WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        /// <summary>
        ///     Imports a collection of account entities into the database.
        /// </summary>
        /// <param name="rows">The collection of account entities to import.</param>
        public void ImportAll(IEnumerable<Account> rows)
        {
            string query = "SET IDENTITY_INSERT Account ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO Account (ID, FirstName, LastName, Email, HashedPassword, Registered) VALUES" +
                    "(@ID, @FirstName, @LastName, @Email, @HashedPassword, @Registered);";

            foreach (Account element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@FirstName", element.FirstName);
                    command.Parameters.AddWithValue("@LastName", element.LastName);
                    command.Parameters.AddWithValue("@Email", element.Email);
                    command.Parameters.AddWithValue("@HashedPassword", element.HashedPassword);
                    command.Parameters.AddWithValue("@Registered", element.Registered);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT Account OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Clears all account entities from the database.
        /// </summary>
        public void ClearTable()
        {
            const string query = "DELETE FROM Account;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}