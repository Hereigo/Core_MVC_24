using ConsoleTestApp;

namespace Core_MVC_24.Data
{
    public class FileManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _filePath;
        private readonly string _filePathN;

        public FileManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _filePath = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFile);
            _filePathN = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFileN);
        }

        // TODO:
        // TEST ME !!!!!!!!
        internal async Task CheckDatabase(string blablatest)
        {
            // TODO:
            // Refactor time coze its for previous.
            string filePathNTemp = $"{_filePathN}.{DateTime.Now:HHmmss}";

            if (DbFileExists())
            {
                File.Copy(_filePathN, filePathNTemp, true);

                await Cryptonic.EncryptByPass(_filePath, _filePathN, blablatest);

                if (File.Exists(filePathNTemp))
                {
                    CloseConnection();

                    File.Delete(_filePath);
                }
            }
            else if (File.Exists(_filePathN))
            {
                await Cryptonic.DecryptByPass(_filePathN, _filePath, blablatest);
            }
            else
            {
            }

            System.Threading.Thread.Sleep(4000);
        }

        internal bool DbFileExists()
        {
            return
                File.Exists(_filePath) && new FileInfo(_filePath).Length > 0;
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
