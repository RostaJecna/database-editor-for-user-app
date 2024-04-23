using System.IO;
using System.Linq;
using DatabaseEditorForUser.DAOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatabaseEditorForUser
{
    internal static class Exporter
    {
        public const string DefaultPath = @"../../Resources/Database/Export/cloud.json";

        public static void Export()
        {
            JsonSerializerSettings jss = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            };

            JObject json = new JObject
            {
                {
                    "Account",
                    JToken.Parse(JsonConvert.SerializeObject(new AccountDao().GetAll().ToList(), Formatting.Indented,
                        jss))
                },
                {
                    "FolderColor",
                    JToken.Parse(JsonConvert.SerializeObject(new FolderColorDao().GetAll().ToList(),
                        Formatting.Indented, jss))
                },
                {
                    "Folder",
                    JToken.Parse(JsonConvert.SerializeObject(new FolderDao().GetAll().ToList(), Formatting.Indented,
                        jss))
                },
                {
                    "Access",
                    JToken.Parse(JsonConvert.SerializeObject(new AccessDao().GetAll().ToList(), Formatting.Indented,
                        jss))
                },
                {
                    "AttachmentType",
                    JToken.Parse(JsonConvert.SerializeObject(new AttachmentTypeDao().GetAll().ToList(),
                        Formatting.Indented, jss))
                },
                {
                    "Attachment",
                    JToken.Parse(JsonConvert.SerializeObject(new AttachmentDao().GetAll().ToList(), Formatting.Indented,
                        jss))
                }
            };

            File.WriteAllText(DefaultPath, json.ToString());
        }
    }
}