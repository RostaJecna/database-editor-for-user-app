using DatabaseEditorForUser.DAOs;
using DatabaseEditorForUser.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser
{
    internal static class Importer
    {
        public static void Import(string path)
        {
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));

            DAOContainer.access.ClearTable();
            DAOContainer.account.ClearTable();
            DAOContainer.attachment.ClearTable();
            DAOContainer.attachmentType.ClearTable();
            DAOContainer.folder.ClearTable();
            DAOContainer.folderColor.ClearTable();

            // Accounts
            JArray jArray = (JArray)jsonObject["Account"];
            List<Account> accounts = jArray.Select(jo => new Account
            (
                (int)jo["ID"],
                jo["FirstName"].ToString(),
                jo["LastName"].ToString(),
                jo["Email"].ToString(),
                jo["HashedPassword"].ToString(),
                (DateTime)jo["Registered"]
            )).ToList();

            DAOContainer.account.ImportAll(accounts);

            // Folder colors
            jArray = (JArray)jsonObject["FolderColor"];
            List<FolderColor> folderColors = jArray.Select(jo => new FolderColor
            (
                (int)jo["ID"],
                jo["Name"].ToString()
            )).ToList();

            DAOContainer.folderColor.ImportAll(folderColors);

            // Folders
            jArray = (JArray)jsonObject["Folder"];
            List<Folder> folders = jArray.Select(jo => new Folder
            (
                (int)jo["ID"],
                jo["Name"].ToString(),
                (int)jo["ColorID"],
                (bool)jo["IsShared"],
                (DateTime)jo["CreatedAt"]
            )).ToList();

            DAOContainer.folder.ImportAll(folders);

            // Accesses
            jArray = (JArray)jsonObject["Access"];
            List<Access> accesses = jArray.Select(jo => new Access
            (
                (int)jo["ID"],
                (int)jo["AccountID"],
                (int)jo["FolderID"]
            )).ToList();

            DAOContainer.access.ImportAll(accesses);

            // Attachment types
            jArray = (JArray)jsonObject["AttachmentType"];
            List<AttachmentType> attachmentTypes = jArray.Select(jo => new AttachmentType
            (
                (int)jo["ID"],
                jo["TypeName"].ToString()
            )).ToList();

            DAOContainer.attachmentType.ImportAll(attachmentTypes);

            // Attachment
            jArray = (JArray)jsonObject["Attachment"];
            List<Attachment> attachments = jArray.Select(jo => new Attachment
            (
                (int)jo["ID"],
                (int)jo["FolderID"],
                (int)jo["TypeID"],
                jo["AttachmentName"].ToString(),
                (float)jo["SizeMB"],
                (DateTime)jo["CreatedAt"],
                (DateTime)jo["UpdatedAt"]
            )).ToList();

            DAOContainer.attachment.ImportAll(attachments);
        }
    }
}
