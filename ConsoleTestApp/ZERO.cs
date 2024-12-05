using System.Text.Json;
using ConsoleTestApp;
// =================================================================================
// WORKING !!!!!!!!!!
// =================================================================================

// var main = new FileWorker();
// main.CreateDatabase();

// =================================================================================
// TESTING :
// =================================================================================


string workFolder = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
    "Downloads", "EOS", "Tests", "VCF_TEST");

string fileVcf = Path.Combine(workFolder, "20240813.vcf");

var vCards = VcfProfileParser.ParseVcfFile(fileVcf, workFolder);

string json = JsonSerializer.Serialize(vCards);

try
{
    File.WriteAllText(Path.Combine(workFolder, "TEST.json"), json);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}





// https://4js.com/online_documentation/fjs-fgl-3.00.05-manual-html/c_fgl_odiagsqt_017.html

Console.WriteLine("\r\nFinished.\r\n");
Console.ReadLine();