using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Task2
{
    internal class Task2
    {
        public class Root
        {
            [JsonPropertyName("tests")]
            public List<Test> Tests { get; set; }
        }

        public class Test
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }

            [JsonPropertyName("values")]
            public List<Test> Values { get; set; } = new();
        }

        public class Values
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Файлы не найден");
                return;
            }

            string testPath = args[0];
            string valuesPath = args[1];
            string reportPath = args[2];

            var root = JsonSerializer.Deserialize<Root>(File.ReadAllText(testPath));


            var valuesRoot = JsonSerializer.Deserialize<Dictionary<string, List<Values>>>(File.ReadAllText(valuesPath));
            var valueData = valuesRoot["values"];
            var valueDict = valueData.ToDictionary(v => v.Id, v => v.Value);

            void FillValues(List<Test> tests)
            {
                foreach (var test in tests)
                {
                    if (valueDict.TryGetValue(test.Id, out var val))
                        test.Value = val;

                    if (test.Values != null && test.Values.Count > 0)
                        FillValues(test.Values);
                }
            }

            FillValues(root.Tests);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonOutput = JsonSerializer.Serialize(root, options);
            File.WriteAllText(reportPath, jsonOutput);

            Console.WriteLine($"Сохранено в {reportPath}");
        }
    }
}
