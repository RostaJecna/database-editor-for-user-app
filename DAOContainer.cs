using DatabaseEditorForUser.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser
{
    internal readonly struct DAOContainer
    {
        public static readonly AccessDAO access = new AccessDAO();
        public static readonly AccountDAO account = new AccountDAO();
        public static readonly AttachmentDAO attachment = new AttachmentDAO();
        public static readonly AttachmentTypeDAO attachmentType = new AttachmentTypeDAO();
        public static readonly FolderColorDAO folderColor = new FolderColorDAO();
        public static readonly FolderDAO folder = new FolderDAO();
    }
}
