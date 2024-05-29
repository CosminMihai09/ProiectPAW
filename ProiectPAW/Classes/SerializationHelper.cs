using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;

namespace ProiectPAW.Classes
{
    internal class SerializationHelper
    {
        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        public static void SerializeClientToJson(Client client, string filePath)
        {
            string json = JsonConvert.SerializeObject(client, jsonSettings);
            File.WriteAllText(filePath, json);
        }

        public static Client DeserializeClientFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Client>(json);
        }

        public static void SerializeClientToTxt(Client client, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {client.Name}");
            sb.AppendLine($"Address: {client.Address}");
            sb.AppendLine($"Email: {client.Email}");
            sb.AppendLine($"Phone: {client.Phone}");
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
