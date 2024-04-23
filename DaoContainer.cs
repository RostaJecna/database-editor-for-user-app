using DatabaseEditorForUser.DAOs;

namespace DatabaseEditorForUser
{
    internal abstract class DaoContainer
    {
        public static readonly AccessDao Access = new AccessDao();
        public static readonly AccountDao Account = new AccountDao();
        public static readonly AttachmentDao Attachment = new AttachmentDao();
        public static readonly AttachmentTypeDao AttachmentType = new AttachmentTypeDao();
        public static readonly FolderColorDao FolderColor = new FolderColorDao();
        public static readonly FolderDao Folder = new FolderDao();
    }
}