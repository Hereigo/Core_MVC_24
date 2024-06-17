using System.Xml.Serialization;
using ConsoleTestApp;
using FolkerKinzel.VCards;

// =================================================================================
// WORKING !!!!!!!!!!
// =================================================================================

var main = new FileWorker();
// main.GeneralMethod();

// =================================================================================
// TESTING :
// =================================================================================

string fileVcfPath = GIT_IGNORE.fileVcfPath;
// VcfProfileParser.ParseVcf(fileVcfPath);

// Reads a very large VCF file whose contents cannot be completely held in memory.
//
using var textReader = new StreamReader(fileVcfPath);
using var vcfReader = new VcfReader(textReader);

IEnumerable<VCard> result = vcfReader.ReadToEnd();

//var TEST = result.FirstOrDefault();

//var aaa = TEST.AnniversaryViews;

//var TestProperties = TEST.GetType().GetProperties();

//string TEST2 = System.Text.Json.JsonSerializer.Serialize(TestProperties);

Console.WriteLine("The file \"{0}\" contains {1} vCards.",
                  Path.GetFileName(fileVcfPath),
                  result.Count());

// https://4js.com/online_documentation/fjs-fgl-3.00.05-manual-html/c_fgl_odiagsqt_017.html

Console.WriteLine("\r\nFinished.\r\n");
Console.ReadLine();