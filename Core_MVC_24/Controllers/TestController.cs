using ConsoleTestApp;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_24.Controllers
{

    public class TestController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _filePath;
        private readonly string _filePathN;

        public TestController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _filePath = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFile);
            _filePathN = Path.Combine(_webHostEnvironment.WebRootPath, iGor.TestFileN);
        }

        public IActionResult Index()
        {
            if (System.IO.File.Exists(_filePath))
            {
                ViewBag.fileExists = true;
            }
            else if (System.IO.File.Exists(_filePathN))
            {
                ViewBag.fileExists = false;
            }
            else
            {
                return RedirectToAction("Index", "Profiles");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestSubmit(string blablatest)
        {
            string filePathNTemp = $"{_filePathN}.{DateTime.Now:HHmmss}";
            try
            {
                if (System.IO.File.Exists(_filePath))
                {
                    System.IO.File.Copy(_filePathN, filePathNTemp, true);

                    Cryptonic.EncryptByPass(_filePath, _filePathN, blablatest);

                    if (System.IO.File.Exists(filePathNTemp))
                        System.IO.File.Delete(_filePath);
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

            //if (System.IO.File.Exists(_filePath))
            //{
            //    return RedirectToAction("Index", "Profiles");
            //}
            //else if (System.IO.File.Exists(_filePathN))
            //{
            //    try
            //    {
            //        Cryptonic.DecryptByPass(_filePathN, _filePath, blablatest);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //    return View("Index");
            //}
            //else
            //{
            return RedirectToAction("Index");
            //}
        }
    }
}
