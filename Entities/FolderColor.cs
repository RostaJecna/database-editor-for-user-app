using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents a folder color entity, providing information about colors associated with folders.
    /// </summary>
    internal class FolderColor : IBaseClass
    {
        private string name;

        /// <summary>
        ///     Initializes a new instance of the FolderColor class with the specified identifier and color name.
        /// </summary>
        /// <param name="id">The unique identifier of the folder color.</param>
        /// <param name="name">The name of the folder color.</param>
        public FolderColor(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the FolderColor class with the specified color name.
        /// </summary>
        /// <param name="name">The name of the folder color.</param>
        public FolderColor(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the folder color.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the folder color.
        /// </summary>
        public string Name
        {
            get => name;
            private set => name = value ?? throw new ArgumentException("Name can't be null.");
        }

        /// <summary>
        ///     Returns a string representation of the folder color entity.
        /// </summary>
        /// <returns>A string representing the folder color entity.</returns>
        public override string ToString()
        {
            return Id == default ? $"{Name}" : $"{Id}, {Name}";
        }
    }
}