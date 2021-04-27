using EhailingWebApp.Areas.Identity.Data;
using EhailingWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdministrationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationUser> Users { get; set; }
     
        public async Task<IActionResult> Index(string searchString, string Response= null)
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

            if (Response != null)
            {
                int i = Response.Length - 1;
                string response = Response.Remove(i, 1);
                ViewBag.Code = Response[i];
                ViewBag.Response = response;

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

        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _db.Users.FindAsync(Id);
            
            if(user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

                return Json($"{user.FirstName} {user.LastName} has successfully been deleted.1");
            }

            return Json("Oops! Employee could not be found.2");
        }
    }
}
