using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ConsoleTestApp
{
    internal class MsWordProcessor
    {
        static void ProcessRun()
        {
            string msWordTemplate = Constants.PathDownloads + "TEMPLATE.docx";
            string outputFilePath = msWordTemplate.Replace("LATE", DateTime.Now.ToString("_ddHHmmss"));

            Dictionary<string, string> replaceDictionary = new Dictionary<string, string>
            {
                { "<Marker1>", "World =)))" },
                { "<Marker2>", "Hello Hello Hello ..." },
                { "<Marker3>", "Data must be collected using TLS version 1.2 using strong cryptography. We will not accept calls to our API at lower grade encryption levels. We regularly scan our TLS endpoints for vulnerabilities and perform TLS assessments as part of our compliance program.\r\nThe application must not store sensitive card holder data (CHD) such as the card security code (CSC) or primary access number (PAN)..."}
            };

            try
            {
                File.Copy(msWordTemplate, outputFilePath, true);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(outputFilePath, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;

                    foreach (var textElement in mainPart.Document.Descendants<Text>())
                    {
                        if (replaceDictionary.ContainsKey(textElement.Text))
                        {
                            replaceDictionary.TryGetValue(textElement.Text, out string replacement);

                            if (replacement != null)
                            {
                                textElement.Text = textElement.Text.Replace(textElement.Text, replacement);
                            }
                            else
                            {
                                Console.WriteLine($"Can't find a value for key : {textElement.Text} !!!");
                            }
                        }
                    }
                    mainPart.Document.Save();
                }
                Console.WriteLine("Document created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
