using System.IO;
using System.Text.Json;

namespace PizzaStoreAPi
{
    public static class JsonManager
    {
        public static T ReadJsonFile<T>(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string jsonString = File.ReadAllText(filePath);
            T res = JsonSerializer.Deserialize<T>(jsonString, options);
            return res;
        }

        public static void SaveJsonFile<T>(T data, string filePath)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }
}