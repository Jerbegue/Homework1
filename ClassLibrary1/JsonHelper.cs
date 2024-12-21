using System.Text.Json;

namespace ClassLibrary1
{
    public static class JsonHelper
    {
        public static void SaveToJson<T>(List<T> data, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
        }

        public static List<T> LoadFromJson<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return new List<T>();

            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(jsonString)!;
        }
    }
}
