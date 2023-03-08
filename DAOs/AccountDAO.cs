using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DatabaseEditorForUser.DAOs
{
    internal class AccountDAO : IDAO<Account>
    {
        public IEnumerable<Account> GetAll()
        {
            string query = "SELECT * FROM Account";

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
            string query = "INSERT INTO Account (FirstName, LastName, Email, HashedPassword) VALUES" +
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

        public void Delete(int ID)
        {

            if(HasReferences(ID))
            {
                throw new InvalidOperationException("Cannot delete Account with references in Access table.");
            }

            string query = "DELETE FROM Account WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Account element)
        {
            string query = "UPDATE Account SET FirstName = @FirstName, " +
                                              "LastName = @LastName," +
                                              "Email = @Email," +
                                              "HashedPassword = @HashedPassword" +
                                          " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@FirstName", element.FirstName);
                command.Parameters.AddWithValue("@LastName", element.LastName);
                command.Parameters.AddWithValue("@Email", element.Email);
                command.Parameters.AddWithValue("@HashedPassword", element.HashedPassword);

                command.ExecuteNonQuery();
            }
        }

        public Account GetByID(int ID)
        {
            string query = "SELECT * FROM Account WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
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
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasReferences(int ID)
        {
            string query = "SELECT 1 FROM Access WHERE AccountID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
