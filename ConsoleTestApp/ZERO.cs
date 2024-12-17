using System.Text.RegularExpressions;
using APP_4_TESTS;
using ConsoleTestApp;

int yourSelect = 0;
string workDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "EOS", "Tests", "VCF_TEST");
string fileVcf = Path.Combine(workDir, "20240813.vcf");
string fileCsv = Path.Combine(workDir, "GmaExpo_contacts.csv");

while (yourSelect == 0)
{
    Console.WriteLine("Choose:" +
        "\r\n\r\n 1. Create Database." +
        "\r\n\r\n 2. VCF Parser1." +
        "\r\n\r\n 3. CSV Parser1." +
        "\r\n\r\n 9+. TEMP TEST.\r\n");

    int.TryParse(Console.ReadLine(), out yourSelect);
}

switch (yourSelect)
{
    case 1:
        var main = new FileWorker();
        main.CreateDatabase();
        break;
    case 2:
        VcfProfileParser.TestVcfParsing(fileVcf, workDir);
        break;
    case 3:
        CsvParser.TestCsvParsing(fileCsv, workDir);
        break;
    default:
        // TEMP TESTING BLOCK ...
        string unicodeText = @"\u0421\u043E\u043D\u044F, \u0414\u0430\u0448\u0438\u043D\u0430 \u0441\u0456\u0441\u0442\u0440";
        string TEST = Regex.Replace(unicodeText, @"\\u([0-9A-Fa-f]{4})", m => char.ConvertFromUtf32(int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)));
        File.WriteAllText(Path.Combine(workDir, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), TEST);
        break;
}

Console.WriteLine("\r\nFinished.\r\n");
Console.ReadLine();