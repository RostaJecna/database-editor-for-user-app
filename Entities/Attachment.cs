using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    /// <summary>
    ///     Represents an attachment entity, providing information about attachments associated with a folder.
    /// </summary>
    internal class Attachment : IBaseClass
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the attachment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the folder to which the attachment belongs.
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        ///     Gets or sets the type identifier of the attachment.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the attachment.
        /// </summary>
        public string AttachmentName { get; set; }

        /// <summary>
        ///     Gets or sets the size of the attachment in megabytes.
        /// </summary>
        public float SizeMb { get; set; }

        /// <summary>
        ///     Gets or sets the date and time when the attachment was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the date and time when the attachment was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        ///     Initializes a new instance of the Attachment class with the specified parameters.
        /// </summary>
        /// <param name="id">The unique identifier of the attachment.</param>
        /// <param name="folderId">The identifier of the folder to which the attachment belongs.</param>
        /// <param name="typeId">The type identifier of the attachment.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <param name="sizeMb">The size of the attachment in megabytes.</param>
        /// <param name="createdAt">The date and time when the attachment was created.</param>
        /// <param name="updatedAt">The date and time when the attachment was last updated.</param>
        public Attachment(int id, int folderId, int typeId, string attachmentName, float sizeMb, DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMb;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        ///     Initializes a new instance of the Attachment class with the specified parameters.
        /// </summary>
        /// <param name="id">The unique identifier of the attachment.</param>
        /// <param name="folderId">The identifier of the folder to which the attachment belongs.</param>
        /// <param name="typeId">The type identifier of the attachment.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <param name="sizeMb">The size of the attachment in megabytes.</param>
        /// <param name="createdAt">The date and time when the attachment was created.</param>
        public Attachment(int id, int folderId, int typeId, string attachmentName, float sizeMb, DateTime createdAt)
        {
            Id = id;
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMb;
            CreatedAt = createdAt;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        ///     Initializes a new instance of the Attachment class with the specified parameters.
        /// </summary>
        /// <param name="folderId">The identifier of the folder to which the attachment belongs.</param>
        /// <param name="typeId">The type identifier of the attachment.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <param name="sizeMb">The size of the attachment in megabytes.</param>
        public Attachment(int folderId, int typeId, string attachmentName, float sizeMb)
        {
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMb;
        }
    }
}