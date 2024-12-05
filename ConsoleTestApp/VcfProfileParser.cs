using System.Drawing;
using System.Text;

namespace ConsoleTestApp
{
    public class VCard
    {
        public DateTime Created { get; set; }
        public string FileUploaded { get; set; }
        public string Group { get; set; }
        public string Version { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Categories { get; set; }
        public string PhotoFileName { get; set; }
        public string PhoneNumber { get; set; } // Convert 2 LONG !!!
        public string PhoneNumber2 { get; set; } // Convert 2 LONG !!!
        // 2147483647
        // 0672465888
        // 4794069441-HLT
        // 9223372036854775807
        // 380672465888
        // 12127365000
        // Pennsylvania65000
        // 12345678901234567
        // 9223372036854775807
    }

    public static class VcfProfileParser
    {
        public static void ConvertWin1251toUTF8()
        {
            // Sample string encoded in Windows-1251
            byte[] windows1251Bytes = new byte[] { 0xC4, 0xE5, 0xEC, 0xE4, 0xF0 };  // "Привет" in Windows-1251

            // Decode the byte array from Windows-1251 encoding
            string decodedString = Encoding.GetEncoding("windows-1251").GetString(windows1251Bytes);

            // Now 'decodedString' contains the text in UTF-16 (the default string encoding in .NET)
            // If you need to explicitly convert to UTF-8, you can do it like this:
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(decodedString);

            // You can now work with 'utf8Bytes' in UTF-8 encoding, or just use 'decodedString' as needed.
            Console.WriteLine("Decoded string: " + decodedString);
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
                            vCard.Name += "," + line.Substring("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.Name.EndsWith("="))
                                vCard.Name += "," + streamReader.ReadLine();
                        }
                        else if (line.StartsWith("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:"))
                        {
                            vCard.FullName += line.Substring("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.FullName.EndsWith("="))
                                vCard.FullName += "," + streamReader.ReadLine();
                        }
                        else if (line.StartsWith("PHOTO;ENCODING=BASE64;JPEG:") || line.StartsWith("NOTE:Photo:"))
                        {
                            int colonIndex = line.IndexOf(':');

                            if (colonIndex == -1) { throw new Exception("ERROR parsing Photo string!"); }

                            string base64image = line.Substring(colonIndex + 1);

                            while (!string.IsNullOrWhiteSpace(line = streamReader.ReadLine()))
                            {
                                base64image += line;
                            }

                            try
                            {
                                byte[] imageBytes = Convert.FromBase64String(base64image);

                                string guidName = Guid.NewGuid() + ".jpg";

                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    using (Image image = Image.FromStream(ms))
                                    {
                                        image.Save(Path.Combine(imagesSavePath,guidName));
                                        vCard.PhotoFileName = guidName;
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
