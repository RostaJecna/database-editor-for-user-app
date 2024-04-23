using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'AttachmentType' entity.
    /// </summary>
    internal class AttachmentTypeDao : IDao<AttachmentType>
    {
        /// <summary>
        ///     Adds a new attachment type entity to the database.
        /// </summary>
        /// <param name="element">The attachment type entity to add.</param>
        /// <exception cref="Exception">Thrown if a duplicate attachment type is found or if a database error occurs.</exception>
        public void Add(AttachmentType element)
        {
            if (HasDuplicate(element)) throw new Exception("Type must be unique.");

            const string query = "INSERT INTO AttachmentType (TypeName) VALUES" +
                                 "(@TypeName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Deletes an attachment type entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the attachment type entity to delete.</param>
        /// <exception cref="InvalidOperationException">Thrown if the attachment type has references in other tables.</exception>
        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException("Can't delete Type with references in Attachment table.");

            const string query = "DELETE FROM AttachmentType WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Updates an existing attachment type entity in the database.
        /// </summary>
        /// <param name="element">The updated attachment type entity.</param>
        /// <exception cref="Exception">Thrown if a duplicate attachment type is found or if a database error occurs.</exception>
        public void Edit(AttachmentType element)
        {
            if (HasDuplicate(element)) throw new Exception("Duplicate type found. Please provide a unique type name.");

            const string query = "UPDATE AttachmentType SET TypeName = @TypeName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Retrieves all attachment type entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of attachment type entities.</returns>
        public IEnumerable<AttachmentType> GetAll()
        {
            const string query = "SELECT * FROM AttachmentType";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AttachmentType attachmentType = new AttachmentType(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        yield return attachmentType;
                    }
                }
            }
        }

        /// <summary>
        ///     Retrieves an attachment type entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the attachment type entity to retrieve.</param>
        /// <returns>The attachment type entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no attachment type entity with the provided ID is found in the database.</exception>
        public AttachmentType GetById(int id)
        {
            const string query = "SELECT * FROM AttachmentType WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new AttachmentType(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );
                }
            }
        }

        /// <summary>
        ///     Checks if a duplicate attachment type entity exists in the database.
        /// </summary>
        /// <param name="element">The attachment type entity to check for duplicates.</param>
        /// <returns>True if a duplicate attachment type entity exists, otherwise false.</returns>
        public bool HasDuplicate(AttachmentType element)
        {
            const string query = "SELECT 1 FROM AttachmentType WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        /// <summary>
        ///     Checks if any references to the attachment type entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the attachment type entity to check.</param>
        /// <returns>True if references to the attachment type entity exist, otherwise false.</returns>
        public bool HasReferences(int id)
        {
            const string query = "SELECT 1 FROM Attachment WHERE TypeID = @ID";
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
        ///     Retrieves the ID of an attachment type entity by its name.
        /// </summary>
        /// <param name="name">The name of the attachment type entity.</param>
        /// <returns>The ID of the attachment type entity with the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown if the type ID cannot be retrieved from the database.</exception>
        public static int GetIdByName(string name)
        {
            const string query = "SELECT ID FROM AttachmentType WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        throw new ArgumentException("Failed to get type ID in the database.", nameof(name));
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        /// <summary>
        ///     Imports a collection of attachment type entities into the database.
        /// </summary>
        /// <param name="rows">The collection of attachment type entities to import.</param>
        public void ImportAll(IEnumerable<AttachmentType> rows)
        {
            string query = "SET IDENTITY_INSERT AttachmentType ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO AttachmentType (ID, TypeName) VALUES" +
                    "(@ID, @TypeName);";

            foreach (AttachmentType element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@TypeName", element.TypeName);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT AttachmentType OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Clears all attachment type entities from the database.
        /// </summary>
        public void ClearTable()
        {
            const string query = "DELETE FROM AttachmentType;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}