using BusinessObjectLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entry.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET: /Account/CreateRole
        public IActionResult CreateRole()
        {
            return View();
        }

        //POST: /Account/CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole(ProjectRole role)
        {
            var roleExist = await this._roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await this._roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }
    }
}