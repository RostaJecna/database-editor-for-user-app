using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'Attachment' entity.
    /// </summary>
    internal class AttachmentDao : IDao<Attachment>
    {
        /// <summary>
        ///     Adds a new attachment entity to the database.
        /// </summary>
        /// <param name="element">The attachment entity to add.</param>
        /// <exception cref="Exception">Thrown if the folder with the specified ID does not exist or if a database error occurs.</exception>
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

        /// <summary>
        ///     Clears all attachment entities from the database.
        /// </summary>
        public void ClearTable()
        {
            const string query = "DELETE FROM Attachment;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Deletes an attachment entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the attachment entity to delete.</param>
        public void Delete(int id)
        {
            const string query = "DELETE FROM Attachment WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Updates an existing attachment entity in the database.
        /// </summary>
        /// <param name="element">The updated attachment entity.</param>
        /// <exception cref="Exception">Thrown if the folder with the specified ID does not exist or if a database error occurs.</exception>
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

        /// <summary>
        ///     Retrieves all attachment entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of attachment entities.</returns>
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

        /// <summary>
        ///     Retrieves an attachment entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the attachment entity to retrieve.</param>
        /// <returns>The attachment entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no attachment entity with the provided ID is found in the database.</exception>
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

        /// <summary>
        ///     Checks if a duplicate attachment entity exists in the database.
        /// </summary>
        /// <param name="element">The attachment entity to check for duplicates.</param>
        /// <returns>True if a duplicate attachment entity exists, otherwise false.</returns>
        public bool HasDuplicate(Attachment element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Checks if any references to the attachment entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the attachment entity to check.</param>
        /// <returns>True if references to the attachment entity exist, otherwise false.</returns>
        public bool HasReferences(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Imports a collection of attachment entities into the database.
        /// </summary>
        /// <param name="rows">The collection of attachment entities to import.</param>
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