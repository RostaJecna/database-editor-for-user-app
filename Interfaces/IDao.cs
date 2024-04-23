using System.Collections.Generic;

namespace DatabaseEditorForUser.Interfaces
{
    /// <summary>
    ///     Represents the interface for Data Access Objects (DAO) used to interact with a specific database entity.
    /// </summary>
    /// <typeparam name="T">The type of the database entity that the DAO interacts with.</typeparam>
    internal interface IDao<T> where T : IBaseClass
    {
        /// <summary>
        ///     Retrieves all records of the database entity from the database.
        /// </summary>
        /// <returns>An enumerable collection of database entity records.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Adds a new record of the database entity to the database.
        /// </summary>
        /// <param name="element">The database entity record to add.</param>
        void Add(T element);

        /// <summary>
        ///     Edits an existing record of the database entity in the database.
        /// </summary>
        /// <param name="element">The database entity record to edit.</param>
        void Edit(T element);

        /// <summary>
        ///     Deletes a record of the database entity from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the database entity record to delete.</param>
        void Delete(int id);

        /// <summary>
        ///     Retrieves a specific record of the database entity from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the database entity record to retrieve.</param>
        /// <returns>The database entity record with the specified unique identifier.</returns>
        T GetById(int id);

        /// <summary>
        ///     Checks if the database entity record with the specified identifier has references in other tables.
        /// </summary>
        /// <param name="id">The unique identifier of the database entity record to check.</param>
        /// <returns>True if the record has references; otherwise, false.</returns>
        bool HasReferences(int id);

        /// <summary>
        ///     Checks if adding the specified database entity record would result in a duplicate entry in the database.
        /// </summary>
        /// <param name="element">The database entity record to check for duplicates.</param>
        /// <returns>True if adding the record would result in a duplicate; otherwise, false.</returns>
        bool HasDuplicate(T element);

        /// <summary>
        ///     Imports multiple database entity records into the database.
        /// </summary>
        /// <param name="rows">The collection of database entity records to import.</param>
        void ImportAll(IEnumerable<T> rows);

        /// <summary>
        ///     Clears all records of the database entity from the database.
        /// </summary>
        void ClearTable();
    }
}