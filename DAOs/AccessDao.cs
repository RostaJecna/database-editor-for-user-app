using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    /// <summary>
    ///     Provides data access operations for the 'Access' entity.
    /// </summary>
    internal class AccessDao : IDao<Access>
    {
        /// <summary>
        ///     Adds a new access entity to the database.
        /// </summary>
        /// <param name="element">The access entity to add.</param>
        /// <exception cref="Exception">
        ///     Thrown if duplicate accesses are not allowed, if the account or folder with the provided
        ///     IDs does not exist, or if a database error occurs.
        /// </exception>
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

        /// <summary>
        ///     Deletes an access entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the access entity to delete.</param>
        public void Delete(int id)
        {
            const string query = "DELETE FROM Access WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        ///     Updates an existing access entity in the database.
        /// </summary>
        /// <param name="element">The updated access entity.</param>
        /// <exception cref="Exception">
        ///     Thrown if duplicate accesses are not allowed, if the account or folder with the provided
        ///     IDs does not exist, or if a database error occurs.
        /// </exception>
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

        /// <summary>
        ///     Retrieves all access entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of access entities.</returns>
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

        /// <summary>
        ///     Retrieves an access entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the access entity to retrieve.</param>
        /// <returns>The access entity with the specified ID.</returns>
        /// <exception cref="Exception">Thrown if no access entity with the provided ID is found in the database.</exception>
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

        /// <summary>
        ///     Checks if a duplicate access entity exists in the database.
        /// </summary>
        /// <param name="element">The access entity to check for duplicates.</param>
        /// <returns>True if a duplicate access entity exists, otherwise false.</returns>
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

        /// <summary>
        ///     Checks if any references to the access entity exist in other tables.
        /// </summary>
        /// <param name="id">The ID of the access entity to check.</param>
        /// <returns>True if references to the access entity exist, otherwise false.</returns>
        /// <exception cref="NotImplementedException">Thrown since this method is not implemented.</exception
        public bool HasReferences(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Imports a collection of access entities into the database.
        /// </summary>
        /// <param name="rows">The collection of access entities to import.</param>
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

        /// <summary>
        ///     Clears all access entities from the database.
        /// </summary>
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