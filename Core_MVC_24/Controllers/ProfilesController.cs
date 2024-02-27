using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Controllers
{
    public class ProfilesController(DataContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await context.Profiles.ToListAsync());
            }
            catch (Exception)
            {
                return View(new List<Profile>());
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles.FirstOrDefaultAsync(m => m.ProfileID == id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profile profile)
        {
            ModelState.Remove("ProfileID");
            if (ModelState.IsValid)
            {
                context.Add(profile);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Profile profile)
        {
            if (id != profile.ProfileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(profile);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ProfileID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profile = await context.Profiles.FindAsync(id);
            if (profile != null)
            {
                context.Profiles.Remove(profile);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(string id)
        {
            return context.Profiles.Any(e => e.ProfileID == id);
        }
    }
}
