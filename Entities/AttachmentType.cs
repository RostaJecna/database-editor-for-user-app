using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents an attachment type entity, providing information about types of attachments.
    /// </summary>
    internal class AttachmentType : IBaseClass
    {
        /// <summary>
        ///     Initializes a new instance of the AttachmentType class with the specified identifier and type name.
        /// </summary>
        /// <param name="id">The unique identifier of the attachment type.</param>
        /// <param name="typeName">The name of the attachment type.</param>
        public AttachmentType(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        /// <summary>
        ///     Initializes a new instance of the AttachmentType class with the specified type name.
        /// </summary>
        /// <param name="typeName">The name of the attachment type.</param>
        public AttachmentType(string typeName)
        {
            TypeName = typeName;
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the attachment type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the attachment type.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        ///     Returns a string representation of the attachment type entity.
        /// </summary>
        /// <returns>A string representing the attachment type entity.</returns>
        public override string ToString()
        {
            return Id == default ? $"{TypeName}" : $"{Id}: {TypeName}";
        }
    }
}