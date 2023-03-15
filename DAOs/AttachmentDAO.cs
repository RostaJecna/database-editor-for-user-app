using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.DAOs
{
    internal class AttachmentDAO : IDAO<Attachment>
    {
        public void Add(Attachment element)
        {
            if (!FolderDAO.Exist(element.FolderID))
            {
                throw new Exception("The folder with this ID does not exist.");
            }

            string query = "INSERT INTO Attachment (FolderID, TypeID, AttachmentName, SizeMB) VALUES" +
                                "(@FolderID, @TypeID, @AttachmentName, @SizeMB);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@FolderID", element.FolderID);
                command.Parameters.AddWithValue("@TypeID", element.TypeID);
                command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMB, 2));

                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            string query = "DELETE FROM Attachment;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            string query = "DELETE FROM Attachment WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Attachment element)
        {
            if (!FolderDAO.Exist(element.FolderID))
            {
                throw new Exception("The folder with this ID does not exist.");
            }

            string query = "UPDATE Attachment SET FolderID = @FolderID, " +
                                              "TypeID = @TypeID," +
                                              "AttachmentName = @AttachmentName," +
                                              "SizeMB = @SizeMB," +
                                              "UpdatedAt = @UpdatedAt" +
                                          " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@FolderID", element.FolderID);
                command.Parameters.AddWithValue("@TypeID", element.TypeID);
                command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMB, 2));
                command.Parameters.AddWithValue("@UpdatedAt", element.UpdatedAt);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Attachment> GetAll()
        {
            string query = "SELECT * FROM Attachment";

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

        public Attachment GetByID(int ID)
        {
            string query = "SELECT * FROM Attachment WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
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
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasDuplicate(Attachment element)
        {
            throw new NotImplementedException();
        }

        public bool HasReferences(int ID)
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

            query = "INSERT INTO Attachment (ID, FolderID, TypeID, AttachmentName, SizeMB, CreatedAt, UpdatedAt) VALUES" +
                                "(@ID, @FolderID, @TypeID, @AttachmentName, @SizeMB, @CreatedAt, @UpdatedAt);";

            foreach (Attachment element in rows)
            {
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.ID);
                    command.Parameters.AddWithValue("@FolderID", element.FolderID);
                    command.Parameters.AddWithValue("@TypeID", element.TypeID);
                    command.Parameters.AddWithValue("@AttachmentName", element.AttachmentName);
                    command.Parameters.AddWithValue("@SizeMB", Math.Round(element.SizeMB, 2));
                    command.Parameters.AddWithValue("@CreatedAt", element.CreatedAt);
                    command.Parameters.AddWithValue("@UpdatedAt", element.UpdatedAt);

                    command.ExecuteNonQuery();
                }
            }

            query = "SET IDENTITY_INSERT Attachment OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
