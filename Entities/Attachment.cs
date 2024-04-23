using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class Attachment : IBaseClass
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public int TypeId { get; set; }
        public string AttachmentName { get; set; }
        public float SizeMb { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Attachment(int id, int folderId, int typeId, string attachmentName, float sizeMb, DateTime createAt,
            DateTime updatedAt)
        {
            Id = id;
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMb;
            CreatedAt = createAt;
            UpdatedAt = updatedAt;
        }

        public Attachment(int id, int folderId, int typeId, string attachmentName, float sizeMB, DateTime createAt)
        {
            Id = id;
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMB;
            CreatedAt = createAt;
            UpdatedAt = DateTime.Now;
        }

        public Attachment(int folderId, int typeId, string attachmentName, float sizeMb)
        {
            FolderId = folderId;
            TypeId = typeId;
            AttachmentName = attachmentName;
            SizeMb = sizeMb;
        }
    }
}