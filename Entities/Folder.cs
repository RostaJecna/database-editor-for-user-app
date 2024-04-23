using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents a folder entity, providing information about folders in the database.
    /// </summary>
    internal class Folder : IBaseClass
    {
        private string name;

        /// <summary>
        ///     Initializes a new instance of the Folder class with the specified identifier, name, color ID, sharing status, and
        ///     creation date.
        /// </summary>
        /// <param name="id">The unique identifier of the folder.</param>
        /// <param name="name">The name of the folder.</param>
        /// <param name="colorId">The color identifier associated with the folder.</param>
        /// <param name="isShared">A boolean indicating whether the folder is shared.</param>
        /// <param name="createdAt">The creation date of the folder.</param>
        public Folder(int id, string name, int colorId, bool isShared, DateTime createdAt)
        {
            Id = id;
            Name = name;
            ColorId = colorId;
            IsShared = isShared;
            CreatedAt = createdAt;
        }

        /// <summary>
        ///     Initializes a new instance of the Folder class with the specified name, color ID, and sharing status.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        /// <param name="colorId">The color identifier associated with the folder.</param>
        /// <param name="isShared">A boolean indicating whether the folder is shared.</param>
        public Folder(string name, int colorId, bool isShared)
        {
            Name = name;
            ColorId = colorId;
            IsShared = isShared;
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the folder.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the folder.
        /// </summary>
        public string Name
        {
            get => name;
            private set => name = value ?? throw new ArgumentException("Name can't be null.");
        }

        /// <summary>
        ///     Gets or sets the color identifier associated with the folder.
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        ///     Gets or sets a boolean indicating whether the folder is shared.
        /// </summary>
        public bool IsShared { get; set; }

        /// <summary>
        ///     Gets or sets the creation date of the folder.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Returns a string representation of the folder entity.
        /// </summary>
        /// <returns>A string representing the folder entity.</returns>
        public override string ToString()
        {
            return Id == default ? $"{Name}, {ColorId}, {IsShared}" : $"{Id}: {Name}, {ColorId}, {IsShared}";
        }
    }
}