using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Web;

namespace ConsoleTestApp
{
    public class VCard
    {
        public DateTime Created { get; set; }
        public string Categories { get; set; }
        public string FileUploaded { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhotoFileName { get; set; }
        public string Version { get; set; }
        // 4794069441-HLT
        // 0689012345
        // 380672465888
        // Pennsylvania65000
        // 12345678901234567
        // 9223372036854775807 Type-Long
    }

    public static class VcfProfileParser
    {
        public static void TestParseVcf(string vcfFilePath, string imagesSavePath)
        {
            try
            {
                var vCards = ParseVcfFile(vcfFilePath, imagesSavePath);
                string json = JsonSerializer.Serialize(vCards);
                File.WriteAllText(Path.Combine(imagesSavePath, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), json);
                Console.WriteLine("Json saved to - " + imagesSavePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<VCard> ParseVcfFile(string vcfFilePath, string imagesSavePath)
        {
            var vCards = new List<VCard>();

            if (File.Exists(vcfFilePath))
            {
                var fileUploadedName = Path.GetFileName(vcfFilePath);

                using (var fileStream = File.OpenRead(vcfFilePath))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    VCard vCard = null;
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // TODO:
                        // check valid begin and end of Cards !!!

                        // is for VERSION:2.1

                        if (line.StartsWith("BEGIN:VCARD"))
                        {
                            vCard = new VCard();
                        }
                        else if (line.StartsWith("END:VCARD"))
                        {
                            vCard.Created = DateTime.Now;
                            vCard.FileUploaded = fileUploadedName;
                            vCards.Add(vCard);
                        }
                        else if (line.StartsWith("N:")) vCard.Name += "," + line.Substring("N:".Length).TrimStart(',');
                        else if (line.StartsWith("FN:")) vCard.FullName += "," + line.Substring("FN:".Length).TrimStart(',');
                        else if (line.StartsWith("CATEGORIES:")) vCard.Categories += "," + line.Substring("CATEGORIES:".Length).TrimStart(',');
                        else if (line.StartsWith("TEL;CELL:")) vCard.PhoneNumber += "," + line.Substring("TEL;CELL:".Length).TrimStart(',');
                        else if (line.StartsWith("TEL;TYPE=CELL:")) vCard.PhoneNumber2 += "," + line.Substring("TEL;TYPE=CELL:".Length).TrimStart(',');
                        else if (line.StartsWith("VERSION:")) vCard.Version += "," + line.Substring("VERSION:".Length).TrimStart(',');
                        else if (line.StartsWith("X-GROUP:")) vCard.Group += "," + line.Substring("X-GROUP:".Length).TrimStart(',');
                        else if (line.StartsWith("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:"))
                        {
                            vCard.Name += line.Substring("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.Name.EndsWith("="))
                                vCard.Name += streamReader.ReadLine();

                            vCard.Name = HttpUtility.UrlDecode(vCard.Name.Replace("==", "=").Replace("=", "%"));
                        }
                        else if (line.StartsWith("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:"))
                        {
                            vCard.FullName += line.Substring("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.FullName.EndsWith("="))
                                vCard.FullName += streamReader.ReadLine();

                            vCard.FullName = HttpUtility.UrlDecode(vCard.FullName.Replace("==", "=").Replace("=", "%"));
                        }
                        else if (line.StartsWith("PHOTO;ENCODING=BASE64;JPEG:") || line.StartsWith("NOTE:Photo:"))
                        {
                            int colonIndex = line.IndexOf(':');

                            if (colonIndex == -1) { throw new Exception("ERROR parsing Photo string!"); }

                            string base64image = line.Substring(colonIndex + 1);

                            while (!string.IsNullOrWhiteSpace(line = streamReader.ReadLine())) base64image += line;

                            try
                            {
                                byte[] imageBytes = Convert.FromBase64String(base64image);
                                string guidImageName = Guid.NewGuid() + ".jpg";

                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    using (Image image = Image.FromStream(ms))
                                    {
                                        image.Save(Path.Combine(imagesSavePath, guidImageName));
                                        vCard.PhotoFileName = guidImageName;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                vCard.PhotoFileName = "ERROR!";
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                            Console.WriteLine($"ERROR! SKIPPED! - {line}");
                    }
                }
            }
            return vCards;
        }
    }
}
