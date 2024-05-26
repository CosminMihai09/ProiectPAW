using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW.Classes
{
    internal class SerializationHelper
    {
        public static void SerializeClientToJson(Client client, string filePath)
        {
            string json = JsonConvert.SerializeObject(client, Formatting.Indented);
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
