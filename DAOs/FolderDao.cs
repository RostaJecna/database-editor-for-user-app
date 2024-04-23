using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class FolderDao : IDao<Folder>
    {
        public void Add(Folder element)
        {
            const string query = "INSERT INTO Folder (FolderName, ColorID, IsShared) VALUES" +
                                 "(@FolderName, @ColorID, @IsShared);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@FolderName", element.Name);
                command.Parameters.AddWithValue("@ColorID", element.ColorId);
                command.Parameters.AddWithValue("@IsShared", element.IsShared ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException(
                    "Can't delete Folder with references in Access or Attachment table.");

            const string query = "DELETE FROM Folder WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Folder element)
        {
            const string query = "UPDATE Folder SET FolderName = @FolderName, " +
                                 "ColorID = @ColorID," +
                                 "IsShared = @IsShared" +
                                 " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@FolderName", element.Name);
                command.Parameters.AddWithValue("@ColorID", element.ColorId);
                command.Parameters.AddWithValue("@IsShared", element.IsShared ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Folder> GetAll()
        {
            const string query = "SELECT * FROM Folder";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Folder folder = new Folder(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetBoolean(3),
                            reader.GetDateTime(4)
                        );

                        yield return folder;
                    }
                }
            }
        }

        public Folder GetById(int id)
        {
            const string query = "SELECT * FROM Folder WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new Folder(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetBoolean(3),
                        reader.GetDateTime(4)
                    );

                }
            }
        }

        public bool HasDuplicate(Folder element)
        {
            throw new NotImplementedException();
        }

        public bool HasReferences(int id)
        {
            string query = "SELECT 1 FROM Access WHERE FolderID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) return true;
                }
            }

            query = "SELECT 1 FROM Attachment WHERE FolderID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public static bool Exist(int id)
        {
            const string query = "SELECT 1 FROM Folder WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public void ImportAll(IEnumerable<Folder> rows)
        {
            string query = "SET IDENTITY_INSERT Folder ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO Folder (ID, FolderName, ColorID, IsShared, CreatedAt) VALUES" +
                    "(@ID, @FolderName, @ColorID, @IsShared, @CreatedAt);";

            foreach (Folder element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@FolderName", element.Name);
                    command.Parameters.AddWithValue("@ColorID", element.ColorId);
                    command.Parameters.AddWithValue("@IsShared", element.IsShared ? 1 : 0);
                    command.Parameters.AddWithValue("@CreatedAt", element.CreatedAt);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT Folder OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            const string query = "DELETE FROM Folder;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}