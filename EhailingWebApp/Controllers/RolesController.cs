using EhailingWebApp.Areas.Identity.Data;
using EhailingWebApp.Data;
using EhailingWebApp.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public async Task<IActionResult> Index(string searchString, string Response=null)
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

           if(Response != null)
            {
                int i = Response.Length - 1;
                string response = Response.Remove(i,1);
                ViewBag.Code = Response[i];
                ViewBag.Response = response;
               
            }

            return View(Users);
        }


        [HttpPost]
        public async Task<IActionResult> Index(Role model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);

                if (roleExists)
                {
                    ViewBag.Message = $"{model.RoleName} already exists!";
                    return View(model);
                }

                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    ViewBag.Message = $"Role created successfully";
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> AssignRole(string Id)
        {
            bool IsRoleExit = await _roleManager.RoleExistsAsync("Administrator");

            if (!IsRoleExit)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                await _roleManager.CreateAsync(role);
            }

            if(_db.UserRoles.Count() > 3)
            {
                return Json("For security reasons, having more than 3 administrator is restricted.2");
            }

            var user = await _db.Users.FindAsync(Id);

            if(user != null)
            {
                if(await _userManager.IsInRoleAsync(user, "Administrator"))
                {
                  
                    return Json("Employee is already an administrator.2");
                }
                await _userManager.AddToRoleAsync(user, "Administrator");
                return Json("Employee is now an administrator.1");
            }
            return Json("Oops! Could not grant employee an admin rights.2");
        }

        public async Task<IActionResult> RemoveRole(string Id)
        {
            var user = await _db.Users.FindAsync(Id);

            if(user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Administrator");
                return Json($"{user.FirstName} {user.LastName} has successfully been removed from admin role.1");
            }

            return Json("Oops! Employee could not be found.2");
        }

    }
}
