using System.Diagnostics;
using ConsoleTestApp;
using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _filePath;
        private readonly string _filePathN;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _filePath = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFile);
            _filePathN = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFileN);
        }

        public IActionResult Index()
        {
            ViewBag.fileExists = System.IO.File.Exists(_filePath) && new FileInfo(_filePath).Length > 0;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Profiles()
        {
            return View(await _dataContext.Profiles.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestSubmit(string blablatest)
        {
            string filePathNTemp = $"{_filePathN}.{DateTime.Now:HHmmss}";
            try
            {
                if (System.IO.File.Exists(_filePath) && new FileInfo(_filePath).Length > 0)
                {
                    System.IO.File.Copy(_filePathN, filePathNTemp, true);

                    Cryptonic.EncryptByPass(_filePath, _filePathN, blablatest);

                    if (System.IO.File.Exists(filePathNTemp))
                    {
                        CloseConnection();

                        System.IO.File.Delete(_filePath);
                    }
                }
                else if (System.IO.File.Exists(_filePathN))
                {
                    Cryptonic.DecryptByPass(_filePathN, _filePath, blablatest);
                }
                else
                {
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CloseConnection()
        {
            // string filename = "mydatabase.db";
            // SQLiteConnection connection = new SQLiteConnection("Data Source=" + filename);
            // connection.Close();

            GC.Collect(); // Force garbage collection
            GC.WaitForPendingFinalizers(); // Wait for finalization
        }
    }
}
