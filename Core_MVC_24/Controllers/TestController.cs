using ConsoleTestApp;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_24.Controllers
{
    public class TestController(IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public IActionResult Index()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            string filePath = Path.Combine(webRootPath, iGor.TestFile);

            if (System.IO.File.Exists(filePath))
            {
                return View();
            }

            return NotFound();
        }
    }
}
