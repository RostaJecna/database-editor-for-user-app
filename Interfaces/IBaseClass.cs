namespace DatabaseEditorForUser.Interfaces
{
    /// <summary>
    ///     Represents the base interface for all database entities.
    /// </summary>
    internal interface IBaseClass
    {
        /// <summary>
        ///     Gets or sets the unique identifier for the database entity.
        /// </summary>
        int Id { get; set; }
    }
}