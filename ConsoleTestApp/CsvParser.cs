using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;

namespace APP_4_TESTS
{
    public class CsvParser
    {
        public static void TestCsvParsing(string fileVcfPath, string workDir)
        {
            try
            {
                List<CsvProfile> vCards = ParseCsv(fileVcfPath);

                string json = JsonSerializer.Serialize(vCards);

                File.WriteAllText(Path.Combine(workDir, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), json);

                Console.WriteLine("Json saved to - " + workDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // https://joshclose.github.io/CsvHelper/examples/reading/


        public static List<CsvProfile> ParseCsv(string filePath)
        {
            //using (var reader = new StreamReader(filePath))
            //using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    HasHeaderRecord = true,  // Indicates that the first line is a header
            //}))
            //{
            //    var records = csv.GetRecords<CsvProfile>();
            //    return records.ToList();
            //}

            //using (var reader = new StreamReader(filePath))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    csv.Configuration.HasHeaderRecord = true;
            //    return csv.GetRecords<CsvProfile>().ToList();
            //}

            var contacts = new List<CsvProfile>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<dynamic>().ToList();

                var TEST = records.Count;

                foreach (var record in records)
                {
                    var contact = new CsvProfile();

                    foreach (var property in record)
                    {
                        var propertyName = property.Key;
                        var value = property.Value?.ToString();

                        // Use reflection to set properties dynamically
                        //var propInfo = typeof(CsvProfile).GetProperty(propertyName, (BindingFlags)StringComparison.OrdinalIgnoreCase);

                        var propInfo = typeof(CsvProfile).GetProperties().FirstOrDefault(p =>
                                string.Equals(p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName, propertyName, StringComparison.OrdinalIgnoreCase));

                        if (propInfo != null && value != null)
                        {
                            // Handle special cases like date parsing
                            // if (propInfo.PropertyType == typeof(DateTime?) && DateTime.TryParse(value, out var dateValue))
                            // {
                            //     propInfo.SetValue(contact, dateValue);
                            // }
                            // else
                            {
                                propInfo.SetValue(contact, value);
                            }
                        }
                    }
                    contacts.Add(contact);
                }
            }

            return contacts;
        }
    }
}
