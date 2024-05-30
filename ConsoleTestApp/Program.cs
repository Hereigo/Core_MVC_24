using ConsoleTestApp;
using FolkerKinzel.VCards;

// =================================================================================
// WORKING !!!!!!!!!!
// =================================================================================

// var main = new FileWorker();
// main.GeneralMethod();

// =================================================================================
// TESTING :
// =================================================================================

string filePath = "\\ccontacts.vcf";

// Reads a very large VCF file whose contents cannot be
// completely held in memory.

using var textReader = new StreamReader(filePath);
using var vcfReader = new VcfReader(textReader);

IEnumerable<VCard> result = vcfReader.ReadToEnd();

var TEST = result.FirstOrDefault();

Console.WriteLine("The file \"{0}\" contains {1} vCards.",
                  Path.GetFileName(filePath),
                  result.Count());



Console.WriteLine("\r\nFinished.\r\n");
Console.ReadLine();