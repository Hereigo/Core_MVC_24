using System.Text;

namespace ConsoleTestApp
{
    class TestProfile
    {
        public string FullName { get; set; }
        public string Categories { get; set; }
        public string PhotoImage { get; set; }
        public string Phone { get; set; }
        // 2147483647
        // 0672465888
        // 4794069441-HLT
        // 9223372036854775807
        // 380672465888
        // 12127365000
        // Pennsylvania65000
        // 12345678901234567
    }

    public static class VcfProfileParser
    {
        public static void ParseVcf(string vcfFile)
        {
            if (File.Exists(vcfFile))
            {
                string[] serviceLines = { "VERSION:3.0" };

                DateTime dateImported = DateTime.Now;

                List<TestProfile> profiles = new List<TestProfile>();

                const Int32 BufferSize = 256;
                using (var fileStream = File.OpenRead(vcfFile))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    TestProfile profile = new TestProfile();
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // TODO:
                        // check valid begin and end of Cards !!!

                        if (line.Contains("BEGIN:VCARD"))
                        {
                            profile = new TestProfile();
                        }
                        else if (line.Contains("END:VCARD"))
                        {
                            profiles.Add(profile);
                        }
                        else
                        {
                            if (!serviceLines.Contains(line.Trim())) // Not a Service info :
                            {
                                switch (line)
                                {
                                    // MULTILINE !!!!!!!!!!
                                    case string a when a.StartsWith("NOTE:Photo:"): profile.PhotoImage = a.Replace("FN:", ""); break;

                                    case string a when a.StartsWith("FN:"): profile.FullName = a.Replace("FN:", ""); break;
                                    case string a when a.StartsWith("TEL;TYPE=CELL:"): profile.Phone = a.Replace("TEL;TYPE=CELL:", ""); break;
                                    case string a when a.StartsWith("CATEGORIES:"): profile.Categories = a.Replace("CATEGORIES:", ""); break;
                                    default:
                                        Console.WriteLine($"SKIPPED! - {line}");
                                        break;
                                }
                            }
                        }
                    }
                }
                var TEST = true;
            }
        }
    }
}
