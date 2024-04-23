using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class AttachmentDao : IDao<Attachment>
    {
        public void Add(Attachment element)
        {
            if (!FolderDao.Exist(element.FolderId)) throw new Exception("The folder with this ID does not exist.");

            const string query = "INSERT INTO Attachment (FolderID, TypeID, AttachmentName, SizeMB) VALUES" +
                                 "(@FolderID, @TypeID, @AttachmentName, @SizeMB);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@FolderID", element.FolderId);
                command.Parameters.AddWithValue("@TypeID", element.TypeId);
                command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMb, 2));

                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            const string query = "DELETE FROM Attachment;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            const string query = "DELETE FROM Attachment WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Attachment element)
        {
            if (!FolderDao.Exist(element.FolderId)) throw new Exception("The folder with this ID does not exist.");

            const string query = "UPDATE Attachment SET FolderID = @FolderID, " +
                                 "TypeID = @TypeID," +
                                 "AttachmentName = @AttachmentName," +
                                 "SizeMB = @SizeMB," +
                                 "UpdatedAt = @UpdatedAt" +
                                 " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@FolderID", element.FolderId);
                command.Parameters.AddWithValue("@TypeID", element.TypeId);
                command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMb, 2));
                command.Parameters.AddWithValue("@UpdatedAt", element.UpdatedAt);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Attachment> GetAll()
        {
            const string query = "SELECT * FROM Attachment";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attachment attachment = new Attachment(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            (float)reader.GetDouble(4),
                            reader.GetDateTime(5),
                            reader.GetDateTime(6)
                        );

                        yield return attachment;
                    }
                }
            }
        }

        public Attachment GetById(int id)
        {
            const string query = "SELECT * FROM Attachment WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new Attachment(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetString(3),
                        (float)reader.GetDouble(4),
                        reader.GetDateTime(5),
                        reader.GetDateTime(6)
                    );

                }
            }
        }

        public bool HasDuplicate(Attachment element)
        {
            throw new NotImplementedException();
        }

        public bool HasReferences(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportAll(IEnumerable<Attachment> rows)
        {
            string query = "SET IDENTITY_INSERT Attachment ON;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query =
                "INSERT INTO Attachment (ID, FolderID, TypeID, AttachmentName, SizeMB, CreatedAt, UpdatedAt) VALUES" +
                "(@ID, @FolderID, @TypeID, @AttachmentName, @SizeMB, @CreatedAt, @UpdatedAt);";

            foreach (Attachment element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@FolderID", element.FolderId);
                    command.Parameters.AddWithValue("@TypeID", element.TypeId);
                    command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                    command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMb, 2));
                    command.Parameters.AddWithValue("@CreatedAt", element.CreatedAt);
                    command.Parameters.AddWithValue("@UpdatedAt", element.UpdatedAt);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT Attachment OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}