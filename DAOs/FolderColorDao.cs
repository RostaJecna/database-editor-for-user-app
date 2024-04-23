using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'FolderColor' entity.
    /// </summary>
    internal class FolderColorDao : IDao<FolderColor>
    {
        /// <summary>
        ///     Adds a new folder color entity to the database.
        /// </summary>
        /// <param name="element">The folder color entity to add.</param>
        /// <exception cref="Exception">Thrown if a duplicate color is found or if a database error occurs.</exception>
        public void Add(FolderColor element)
        {
            if (HasDuplicate(element)) throw new Exception("Color must be unique.");

            const string query = "INSERT INTO FolderColor (ColorName) VALUES" +
                                 "(@ColorName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Deletes a folder color entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the folder color entity to delete.</param>
        /// <exception cref="InvalidOperationException">Thrown if the folder color has references in other tables.</exception>
        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException("Can't delete Color with references in Folder table.");

            const string query = "DELETE FROM FolderColor WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Updates an existing folder color entity in the database.
        /// </summary>
        /// <param name="element">The updated folder color entity.</param>
        /// <exception cref="Exception">Thrown if a duplicate color is found or if a database error occurs.</exception>
        public void Edit(FolderColor element)
        {
            if (HasDuplicate(element))
                throw new Exception("Duplicate color found. Please provide a unique color name.");

            const string query = "UPDATE FolderColor SET ColorName = @ColorName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Retrieves all folder color entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of folder color entities.</returns>
        public IEnumerable<FolderColor> GetAll()
        {
            const string query = "SELECT * FROM FolderColor";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolderColor folderColor = new FolderColor(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        yield return folderColor;
                    }
                }
            }
        }

        /// <summary>
        ///     Retrieves a folder color entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the folder color entity to retrieve.</param>
        /// <returns>The folder color entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no folder color entity with the provided ID is found in the database.</exception>
        public FolderColor GetById(int id)
        {
            const string query = "SELECT * FROM FolderColor WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new FolderColor(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );
                }
            }
        }

        /// <summary>
        ///     Checks if a duplicate folder color entity exists in the database.
        /// </summary>
        /// <param name="element">The folder color entity to check for duplicates.</param>
        /// <returns>True if a duplicate folder color entity exists, otherwise false.</returns>
        public bool HasDuplicate(FolderColor element)
        {
            const string query = "SELECT 1 FROM FolderColor WHERE ColorName = @ColorName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        /// <summary>
        ///     Checks if any references to the folder color entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the folder color entity to check.</param>
        /// <returns>True if references to the folder color entity exist, otherwise false.</returns>
        public bool HasReferences(int id)
        {
            const string query = "SELECT 1 FROM Folder WHERE ColorID = @ID";
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
        ///     Retrieves the ID of a folder color entity by its name.
        /// </summary>
        /// <param name="name">The name of the folder color entity.</param>
        /// <returns>The ID of the folder color entity with the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown if the color ID cannot be retrieved from the database.</exception>
        public static int GetIdByName(string name)
        {
            const string query = "SELECT ID FROM FolderColor WHERE ColorName = @ColorName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        throw new ArgumentException("Failed to get color ID in the database.", nameof(name));
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        /// <summary>
        ///     Imports a collection of folder color entities into the database.
        /// </summary>
        /// <param name="rows">The collection of folder color entities to import.</param>
        public void ImportAll(IEnumerable<FolderColor> rows)
        {
            string query = "SET IDENTITY_INSERT FolderColor ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO FolderColor (ID, ColorName) VALUES" +
                    "(@ID, @ColorName);";

            foreach (FolderColor element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@ColorName", element.Name);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT FolderColor OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Clears all folder color entities from the database.
        /// </summary>
        public void ClearTable()
        {
            const string query = "DELETE FROM FolderColor;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}