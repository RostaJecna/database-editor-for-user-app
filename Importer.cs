using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseEditorForUser.Entities;
using Newtonsoft.Json.Linq;

namespace DatabaseEditorForUser
{
    internal static class Importer
    {
        public static void Import(string path)
        {
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));

            DaoContainer.Access.ClearTable();
            DaoContainer.Account.ClearTable();
            DaoContainer.Attachment.ClearTable();
            DaoContainer.AttachmentType.ClearTable();
            DaoContainer.Folder.ClearTable();
            DaoContainer.FolderColor.ClearTable();

            // Accounts
            JArray jArray = (JArray)jsonObject["Account"];
            if (jArray != null)
            {
                List<Account> accounts = jArray.Select(jo => new Account
                (
                    (int)jo["ID"],
                    jo["FirstName"].ToString(),
                    jo["LastName"].ToString(),
                    jo["Email"].ToString(),
                    jo["HashedPassword"].ToString(),
                    (DateTime)jo["Registered"]
                )).ToList();

                DaoContainer.Account.ImportAll(accounts);
            }

            // Folder colors
            jArray = (JArray)jsonObject["FolderColor"];
            if (jArray != null)
            {
                List<FolderColor> folderColors = jArray.Select(jo => new FolderColor
                (
                    (int)jo["ID"],
                    jo["Name"].ToString()
                )).ToList();

                DaoContainer.FolderColor.ImportAll(folderColors);
            }

            // Folders
            jArray = (JArray)jsonObject["Folder"];
            if (jArray != null)
            {
                List<Folder> folders = jArray.Select(jo => new Folder
                (
                    (int)jo["ID"],
                    jo["Name"].ToString(),
                    (int)jo["ColorID"],
                    (bool)jo["IsShared"],
                    (DateTime)jo["CreatedAt"]
                )).ToList();

                DaoContainer.Folder.ImportAll(folders);
            }

            // Accesses
            jArray = (JArray)jsonObject["Access"];
            if (jArray != null)
            {
                List<Access> accesses = jArray.Select(jo => new Access
                (
                    (int)jo["ID"],
                    (int)jo["AccountID"],
                    (int)jo["FolderID"]
                )).ToList();

                DaoContainer.Access.ImportAll(accesses);
            }

            // Attachment types
            jArray = (JArray)jsonObject["AttachmentType"];
            if (jArray != null)
            {
                List<AttachmentType> attachmentTypes = jArray.Select(jo => new AttachmentType
                (
                    (int)jo["ID"],
                    jo["TypeName"].ToString()
                )).ToList();

                DaoContainer.AttachmentType.ImportAll(attachmentTypes);
            }

            // Attachment
            jArray = (JArray)jsonObject["Attachment"];
            if (jArray == null) return;
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

            DaoContainer.Attachment.ImportAll(attachments);
        }
    }
}