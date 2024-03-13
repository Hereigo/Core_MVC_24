using System.IO.Compression;
using ConsoleTestApp;
using NuGet.Packaging;

namespace Core_MVC_24.Data
{
    public class FileManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly string _dabaseFile;
        private readonly string _generalPath;
        private readonly string _lockedFile;
        private readonly string _packedFile;
        private readonly string _workFolder;

        public FileManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _generalPath = Path.Combine(_webHostEnvironment.WebRootPath, "..\\..\\..\\..\\..\\Downloads\\EOS\\Tests\\");
            _dabaseFile = Path.Combine(_generalPath, "workFolder\\TestDb24.dat");
            _lockedFile = Path.Combine(_generalPath, "Tests.aaa");
            _packedFile = Path.Combine(_generalPath, "Tests.pax");
            _workFolder = Path.Combine(_generalPath, "workFolder\\");
        }

        public string CreatePacket(string sourceDirectory, string zipFilePath)
        {
            try
            {


                return string.Empty;
            }
            catch (Exception ex)
            {
                return $"Error creating zip file: {ex.Message}";
            }
        }

        // TODO:
        // TEST ME !!!!!!!!!!
        // TEST ME !!!!!!!!!!
        // internal async Task ProcessDatabase(string blablatest)
        internal void ProcessDatabase(string blablatest)
        {


        }

        internal bool isDbFileExists()
        {
            return
                File.Exists(_dabaseFile) && new FileInfo(_dabaseFile).Length > 0;
        }

        private static void CloseConnection()
        {
            // string filename = "mydatabase.db";
            // SQLiteConnection connection = new SQLiteConnection("Data Source=" + filename);
            // connection.Close();

            GC.Collect(); // Force garbage collection
            GC.WaitForPendingFinalizers(); // Wait for finalization
        }
    }
}
