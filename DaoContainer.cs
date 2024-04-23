using DatabaseEditorForUser.DAOs;

namespace DatabaseEditorForUser
{
    /// <summary>
    ///     Container class for providing access to various DAO instances.
    /// </summary>
    internal abstract class DaoContainer
    {
        /// <summary>
        ///     Gets the instance of the AccessDao class.
        /// </summary>
        public static readonly AccessDao Access = new AccessDao();

        /// <summary>
        ///     Gets the instance of the AccountDao class.
        /// </summary>
        public static readonly AccountDao Account = new AccountDao();

        /// <summary>
        ///     Gets the instance of the AttachmentDao class.
        /// </summary>
        public static readonly AttachmentDao Attachment = new AttachmentDao();

        /// <summary>
        ///     Gets the instance of the AttachmentTypeDao class.
        /// </summary>
        public static readonly AttachmentTypeDao AttachmentType = new AttachmentTypeDao();

        /// <summary>
        ///     Gets the instance of the FolderColorDao class.
        /// </summary>
        public static readonly FolderColorDao FolderColor = new FolderColorDao();

        /// <summary>
        ///     Gets the instance of the FolderDao class.
        /// </summary>
        public static readonly FolderDao Folder = new FolderDao();
    }
}