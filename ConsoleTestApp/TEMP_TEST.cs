using System.Text;
using System.Web;

namespace ConsoleTestApp
{
    internal class TEMP_TEST
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

        public static void ParseWin1251()
        {
            string vCardContent = ",;=D0=9D=D0=B0=D1=82=D0=B0=D0=BB=D1=96=D1=8F=20=28=D0=9F=D0=BE=D0=BB=D1=,=96=D0=BD=D0=B8=20=D0=BC=D0=B0=D0=BC=D0=B0=29;;;";
            var TEST = HttpUtility.UrlDecode(vCardContent.Replace("=", "%"));
            Console.WriteLine(TEST);
        }

        public static void TEST()
        {
            // Unicode escape sequence string
            string unicodeText = @"\u0421\u043E\u043D\u044F, \u0414\u0430\u0448\u0438\u043D\u0430 \u0441\u0456\u0441\u0442\u0440";

            // Convert the Unicode escape sequence to actual characters
            string convertedText = ConvertUnicodeToString(unicodeText);

            // Output the converted string
            Console.WriteLine(convertedText);
        }

        static string ConvertUnicodeToString(string unicodeText)
        {
            // Use the .NET built-in functionality to decode the Unicode escape sequences
            string decodedString = System.Text.RegularExpressions.Regex.Replace(unicodeText, @"\\u([0-9A-Fa-f]{4})", m =>
            {
                return char.ConvertFromUtf32(int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber));
            });

            return decodedString;
        }
    }
}
