using System.Diagnostics;
using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Controllers
{
    public class HomeController(ILogger<HomeController> logger, DataContext dataContext, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly FileManager _fileMan = new(webHostEnvironment);

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
            return View(await dataContext.Profiles.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TestSubmit(string blablatest)
        {
            try
            {
                await _fileMan.CheckDatabase(blablatest);
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
