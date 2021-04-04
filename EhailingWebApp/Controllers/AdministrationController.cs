using EhailingWebApp.Areas.Identity.Data;
using EhailingWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdministrationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationUser> Users { get; set; }
     
        public async Task<IActionResult> Index(string searchString)
        {
            Users = await _db.Users
                .Include(u => u.Status)
                .Include(u => u.Platform)
                .Include(u => u.Region)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                Users = Users.Where(s => s.FirstName.Contains(searchString)
                || s.LastName.Contains(searchString)
                || s.Status.StatusName.Contains(searchString) 
                || s.Platform.PlatformName.Contains(searchString) 
                || s.Region.RegionName.Contains(searchString));
            }

            return View(Users);
        }

        public async Task<IActionResult> Details(string Id)
        {
            var user = await _db.Users
                .Include(u => u.Status)
                .Include(u => u.Platform)
                .Include(u => u.Region)
                .FirstOrDefaultAsync(m => m.Id == Id);

            return PartialView("_UserDetails", user);
        }
    }
}
