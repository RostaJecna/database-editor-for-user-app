using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class AccountDao : IDao<Account>
    {
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