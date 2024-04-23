using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'Folder' entity.
    /// </summary>
    internal class FolderDao : IDao<Folder>
    {
        /// <summary>
        ///     Adds a new folder entity to the database.
        /// </summary>
        /// <param name="element">The folder entity to add.</param>
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

        /// <summary>
        ///     Deletes a folder entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the folder entity to delete.</param>
        /// <exception cref="InvalidOperationException">Thrown if the folder has references in other tables.</exception>
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

        /// <summary>
        ///     Updates an existing folder entity in the database.
        /// </summary>
        /// <param name="element">The updated folder entity.</param>
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

        /// <summary>
        ///     Retrieves all folder entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of folder entities.</returns>
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

        /// <summary>
        ///     Retrieves a folder entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the folder entity to retrieve.</param>
        /// <returns>The folder entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no folder entity with the provided ID is found in the database.</exception>
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

        /// <summary>
        ///     Checks if a folder entity has a duplicate entry in the database.
        /// </summary>
        /// <param name="element">The folder entity to check for duplicates.</param>
        /// <returns>True if a duplicate entry exists in the database; otherwise, false.</returns>
        public bool HasDuplicate(Folder element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Checks if any references to the folder entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the folder entity to check.</param>
        /// <returns>True if references to the folder entity exist, otherwise false.</returns>
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

        /// <summary>
        ///     Checks if a folder with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the folder to check for existence.</param>
        /// <returns>True if a folder with the given ID exists in the database; otherwise, false.</returns>
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

        /// <summary>
        ///     Imports a collection of folder entities into the database.
        /// </summary>
        /// <param name="rows">The collection of folder entities to import.</param>
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

        /// <summary>
        ///     Clears all folder entities from the database.
        /// </summary>
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