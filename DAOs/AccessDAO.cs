using DatabaseEditorForUser.Interfaces;
using DatabaseEditorForUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseEditorForUser.DAOs
{
    internal class AccessDAO : IDAO<Access>
    {
        public void Add(Access element)
        {
            if(HasDuplicate(element))
            {
                throw new Exception("Repeated accesses are not allowed.");
            }

            if(!AccountDAO.Exist(element.AccountID))
            {
                throw new Exception("The account with this ID does not exist.");
            }

            if (!FolderDAO.Exist(element.FolderID))
            {
                throw new Exception("The folder with this ID does not exist.");
            }

            string query = "INSERT INTO Access (AccountID, FolderID) VALUES" +
                                "(@AccountID, @FolderID);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@AccountID", element.AccountID);
                command.Parameters.AddWithValue("@FolderID", element.FolderID);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            string query = "DELETE FROM Access WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Access element)
        {
            if (HasDuplicate(element))
            {
                throw new Exception("Duplicate access found. Repeated accesses are not allowed.");
            }

            if (!AccountDAO.Exist(element.AccountID))
            {
                throw new Exception("The account with this ID does not exist.");
            }

            if (!FolderDAO.Exist(element.FolderID))
            {
                throw new Exception("The folder with this ID does not exist.");
            }

            string query = "UPDATE Access SET AccountID = @AccountID, " +
                                              "FolderID = @FolderID" +
                                          " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@AccountID", element.AccountID);
                command.Parameters.AddWithValue("@FolderID", element.FolderID);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Access> GetAll()
        {
            string query = "SELECT * FROM Access";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Access access = new Access(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2)
                        );

                        yield return access;
                    }
                }
            }
        }

        public Access GetByID(int ID)
        {
            string query = "SELECT * FROM Access WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        return new Access(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2)
                        );
                    }
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasDuplicate(Access element)
        {
            string query = "SELECT 1 FROM Access WHERE AccountID = @AccountID AND FolderID = @FolderID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@AccountID", element.AccountID);
                command.Parameters.AddWithValue("@FolderID", element.FolderID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public bool HasReferences(int ID)
        {
            throw new NotImplementedException();
        }

        public void ImportAll(IEnumerable<Access> rows)
        {

            string query = "SET IDENTITY_INSERT Access ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO Access (ID, AccountID, FolderID) VALUES" +
                                "(@ID, @AccountID, @FolderID);";

            foreach (Access element in rows)
            {
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.ID);
                    command.Parameters.AddWithValue("@AccountID", element.AccountID);
                    command.Parameters.AddWithValue("@FolderID", element.FolderID);

                    command.ExecuteNonQuery();
                }
            }

            query = "SET IDENTITY_INSERT Access OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            string query = "DELETE FROM Access;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
