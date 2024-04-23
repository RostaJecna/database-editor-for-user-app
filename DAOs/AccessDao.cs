using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class AccessDao : IDao<Access>
    {
        public void Add(Access element)
        {
            if (HasDuplicate(element)) throw new Exception("Repeated accesses are not allowed.");

            if (!AccountDao.Exist(element.AccountId)) throw new Exception("The account with this ID does not exist.");

            if (!FolderDao.Exist(element.FolderId)) throw new Exception("The folder with this ID does not exist.");

            const string query = "INSERT INTO Access (AccountID, FolderID) VALUES(@AccountID, @FolderID);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@AccountID", element.AccountId);
                command.Parameters.AddWithValue("@FolderID", element.FolderId);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            const string query = "DELETE FROM Access WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Access element)
        {
            if (HasDuplicate(element))
                throw new Exception("Duplicate access found. Repeated accesses are not allowed.");

            if (!AccountDao.Exist(element.AccountId)) throw new Exception("The account with this ID does not exist.");

            if (!FolderDao.Exist(element.FolderId)) throw new Exception("The folder with this ID does not exist.");

            const string query = "UPDATE Access SET AccountID = @AccountID, FolderID = @FolderID WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@AccountID", element.AccountId);
                command.Parameters.AddWithValue("@FolderID", element.FolderId);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Access> GetAll()
        {
            const string query = "SELECT * FROM Access";

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

        public Access GetById(int id)
        {
            const string query = "SELECT * FROM Access WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new Access(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2)
                    );

                }
            }
        }

        public bool HasDuplicate(Access element)
        {
            const string query = "SELECT 1 FROM Access WHERE AccountID = @AccountID AND FolderID = @FolderID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@AccountID", element.AccountId);
                command.Parameters.AddWithValue("@FolderID", element.FolderId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public bool HasReferences(int id)
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
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@AccountID", element.AccountId);
                    command.Parameters.AddWithValue("@FolderID", element.FolderId);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT Access OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            const string query = "DELETE FROM Access;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}