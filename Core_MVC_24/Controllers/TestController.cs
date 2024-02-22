using ConsoleTestApp;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_24.Controllers
{
    public class TestController(IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestSubmit(string blablatest)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            string filePath = Path.Combine(webRootPath, iGor.TestFile);
            string filePathN = Path.Combine(webRootPath, iGor.TestFileN);

            if (System.IO.File.Exists(filePath))
            {
                return RedirectToAction("Index", "Profiles");
            }
            else if (System.IO.File.Exists(filePathN))
            {
                try
                {
                    Cryptonic.DecryptByPass(filePathN, filePath, blablatest);
                }
                catch (Exception)
                {
                    throw;
                }
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
