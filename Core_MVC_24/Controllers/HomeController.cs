using System.Diagnostics;
using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly FileManager _fileMan;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _fileMan = new FileManager(webHostEnvironment);
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.fileExists = _fileMan.DbFileExists();

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
            try
            {
                _fileMan.CheckDatabase(blablatest);
            }
            catch (Exception)
            {
                // TODO:
                // Process this!
                throw;
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
