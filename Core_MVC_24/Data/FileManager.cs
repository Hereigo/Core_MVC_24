namespace Core_MVC_24.Data
{
    public class FileManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly string _dabaseFile;

        public FileManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _dabaseFile = Path.Combine(_webHostEnvironment.WebRootPath, 
                "..\\..\\..\\..\\..\\Downloads\\EOS\\Tests\\workFolder\\TestDb24.dat");
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
