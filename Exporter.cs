using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEditorForUser.DAOs;
using DatabaseEditorForUser.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatabaseEditorForUser
{
    internal static class Exporter
    {
        public const string DEFAULT_PATH = @"../../Resources/Database/Export/cloud.json";

        public static void Export()
        {
            JsonSerializerSettings jss = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            };

            JObject json = new JObject
            {
                { "Account", JToken.Parse(JsonConvert.SerializeObject(new AccountDAO().GetAll().ToList(), Formatting.Indented, jss)) },
                { "FolderColor", JToken.Parse(JsonConvert.SerializeObject(new FolderColorDAO().GetAll().ToList(), Formatting.Indented, jss)) },
                { "Folder", JToken.Parse(JsonConvert.SerializeObject(new FolderDAO().GetAll().ToList(), Formatting.Indented, jss)) },
                { "Access", JToken.Parse(JsonConvert.SerializeObject(new AccessDAO().GetAll().ToList(), Formatting.Indented, jss)) },
                { "AttachmentType", JToken.Parse(JsonConvert.SerializeObject(new AttachmentTypeDAO().GetAll().ToList(), Formatting.Indented, jss)) },
                { "Attachment", JToken.Parse(JsonConvert.SerializeObject(new AttachmentDAO().GetAll().ToList(), Formatting.Indented, jss)) }
            };

            File.WriteAllText(DEFAULT_PATH, json.ToString());
        }
    }
}
