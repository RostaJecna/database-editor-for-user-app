using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents an access entity, providing information about access rights to a folder for a specific account.
    /// </summary>
    internal class Access : IBaseClass
    {
        /// <summary>
        ///     Initializes a new instance of the Access class with the specified identifier, account ID, and folder ID.
        /// </summary>
        /// <param name="id">The unique identifier of the access entity.</param>
        /// <param name="accountId">The ID of the account associated with the access.</param>
        /// <param name="folderId">The ID of the folder being accessed.</param>
        public Access(int id, int accountId, int folderId)
        {
            Id = id;
            AccountId = accountId;
            FolderId = folderId;
        }

        /// <summary>
        ///     Initializes a new instance of the Access class with the specified account ID and folder ID.
        /// </summary>
        /// <param name="accountId">The ID of the account associated with the access.</param>
        /// <param name="folderId">The ID of the folder being accessed.</param>
        public Access(int accountId, int folderId)
        {
            AccountId = accountId;
            FolderId = folderId;
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the access entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the account associated with the access.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the folder being accessed.
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        ///     Returns a string representation of the access entity.
        /// </summary>
        /// <returns>A string representing the access entity.</returns>
        public override string ToString()
        {
            return Id == default ? $"{AccountId}, {FolderId}" : $"{Id}: {AccountId}, {FolderId}";
        }
    }
}