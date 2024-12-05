using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleTestApp
{
    internal class TEMP_TEST
    {
    }

    public static class VCardParser
    {
        public static void TEST()
        {
            // vCard string with multiple vCards
            string vCardContent = @"
BEGIN:VCARD
VERSION:2.1
N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:=D0=A1=D0=BE=D0=9E=D1=8F;=D0=94=D0=B0=D1=88=D0=B8=D0=BD=D0=B0;=D1=81=D1=96=D1=81=D1=82=D1=80;;
FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:=D0=A1
=D1=81=D1=96=D1=81=D1=82=D1=80
TEL;CELL:+380 68 123 0123
END:VCARD
BEGIN:VCARD
VERSION:2.1
N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:=D0=A1=D0=BE=D0=9E=D1=8F;=D0=94=D0=B0=D1=88=D0=B8=D0=BD=D0=B0;=D1=81=D1=96=D1=81=D1=82=D1=80;;
FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:=D0
=D1=81=D1=96=D1=81=D1=82=D1=80
TEL;CELL:+380 68 111 0111
END:VCARD";

            var vCards = ParseMultipleVCards(vCardContent);

            // Output the parsed vCards
            foreach (var vCard in vCards)
            {
                Console.WriteLine("New vCard:");
                foreach (var field in vCard)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine();
            }
        }

        public static List<Dictionary<string, string>> ParseMultipleVCards(string vCardContent)
        {
            var vCards = new List<Dictionary<string, string>>();
            var vCardLines = vCardContent.Split(new[] { "BEGIN:VCARD", "END:VCARD" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var vCardLine in vCardLines)
            {
                var vCardFields = ParseVCard(vCardLine.Trim());
                if (vCardFields.Count > 0)
                {
                    vCards.Add(vCardFields);
                }
            }

            return vCards;
        }

        public static Dictionary<string, string> ParseVCard(string vCardContent)
        {
            var vCardFields = new Dictionary<string, string>();
            var lines = vCardContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string currentFieldName = null;
            StringBuilder currentFieldValue = new StringBuilder();

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();

                // Handle line continuation (lines starting with space or tab)
                if (trimmedLine.StartsWith(" ") || trimmedLine.StartsWith("\t"))
                {
                    currentFieldValue.Append(trimmedLine.Trim());
                    continue;
                }

                // If there is a field being processed, store it before starting a new one
                if (currentFieldName != null)
                {
                    vCardFields[currentFieldName] = DecodeQuotedPrintable(currentFieldValue.ToString());
                    currentFieldValue.Clear();
                }

                // Now process the current line as a new field
                var parts = trimmedLine.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    currentFieldName = parts[0];
                    currentFieldValue.Append(parts[1]);
                }
            }

            // Ensure the last field is added to the dictionary
            if (currentFieldName != null)
            {
                vCardFields[currentFieldName] = DecodeQuotedPrintable(currentFieldValue.ToString());
            }

            return vCardFields;
        }

        // Decode QUOTED-PRINTABLE encoded strings
        public static string DecodeQuotedPrintable(string encoded)
        {
            // Use HttpUtility to decode quoted-printable encoding
            return HttpUtility.UrlDecode(encoded.Replace("=", "%"));
        }
    }
}
