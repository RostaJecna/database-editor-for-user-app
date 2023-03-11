using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class Attachment : IBaseClass
    {
        public int ID { get; set; }
        public int FolderID { get; set; }
        public int TypeID { get; set; }
        public string AttachmentName { get; set; }
        public float SizeMB { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Attachment(int id, int folderID, int typeID, string attachmentName, float sizeMB, DateTime createAt, DateTime updatedAt)
        {
            ID = id;
            FolderID = folderID;
            TypeID = typeID;
            AttachmentName = attachmentName;
            SizeMB = sizeMB;
            CreatedAt = createAt;
            UpdatedAt = updatedAt;
        }

        public Attachment(int id, int folderID, int typeID, string attachmentName, float sizeMB, DateTime createAt)
        {
            ID = id;
            FolderID = folderID;
            TypeID = typeID;
            AttachmentName = attachmentName;
            SizeMB = sizeMB;
            CreatedAt = createAt;
            UpdatedAt = DateTime.Now;
        }

        public Attachment(int folderID, int typeID, string attachmentName, float sizeMB)
        {
            FolderID = folderID;
            TypeID = typeID;
            AttachmentName = attachmentName;
            SizeMB = sizeMB;
        }
    }
}
