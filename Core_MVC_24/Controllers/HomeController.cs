using System.Diagnostics;
using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_24.Controllers
{
    public class HomeController(ILogger<HomeController> logger, DataContext dataContext, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly FileManager _fileMan = new(webHostEnvironment);

        public IActionResult Index()
        {
            ViewBag.fileExists = _fileMan.isDbFileExists();

            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile fileToUpload)
        {
            if (fileToUpload != null && fileToUpload.Length > 0)
            {
                string FileNameOnServer = Path.GetTempPath();
                FileNameOnServer += fileToUpload.FileName;
                
                long FileContentLength = fileToUpload.Length; // bytes
                string FileContentType = fileToUpload.ContentType;

                using var stream = System.IO.File.Create(FileNameOnServer);
                fileToUpload.CopyTo(stream);

                return View("UploadComplete", this);
            }
            else
            {
                // User did not select a file
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
