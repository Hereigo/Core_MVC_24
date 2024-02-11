using Core_MVC_24.Data;
using Core_MVC_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly AppDataContext _context;

        public ProfilesController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profiles.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AaaType,Name,GivenName,AdditionalName,FamilyName,YomiName,GivenNameYomi,AdditionalNameYomi,FamilyNameYomi,NamePrefix,NameSuffix,Initials,Nickname,ShortName,MaidenName,Birthday,Gender,Location,BillingInformation,DirectoryServer,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,GroupMembership,Email1type,Email1value,Email2type,Email2value,Email3type,Email3value,IM1type,IM1Service,IM1value,Phone1type,Phone1value,Phone2type,Phone2value,Phone3type,Phone3value,Address1type,Address1Formatted,Address1Street,Address1City,Address1POBox,Address1Region,Address1PostalCode,Address1Country,Address1ExtendedAddress,Org1type,Org1Name,Org1YomiName,Org1Title,Org1Department,Org1Symbol,Org1Location,Org1JobDescription,Website1type,Website1value,Website2type,Website2value,Event1type,Event1value,CustomField1type,CustomField1value")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,AaaType,Name,GivenName,AdditionalName,FamilyName,YomiName,GivenNameYomi,AdditionalNameYomi,FamilyNameYomi,NamePrefix,NameSuffix,Initials,Nickname,ShortName,MaidenName,Birthday,Gender,Location,BillingInformation,DirectoryServer,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,GroupMembership,Email1type,Email1value,Email2type,Email2value,Email3type,Email3value,IM1type,IM1Service,IM1value,Phone1type,Phone1value,Phone2type,Phone2value,Phone3type,Phone3value,Address1type,Address1Formatted,Address1Street,Address1City,Address1POBox,Address1Region,Address1PostalCode,Address1Country,Address1ExtendedAddress,Org1type,Org1Name,Org1YomiName,Org1Title,Org1Department,Org1Symbol,Org1Location,Org1JobDescription,Website1type,Website1value,Website2type,Website2value,Event1type,Event1value,CustomField1type,CustomField1value")] Profile profile)
        {
            if (id != profile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ID))
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

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(string id)
        {
            return _context.Profiles.Any(e => e.ID == id);
        }
    }
}
