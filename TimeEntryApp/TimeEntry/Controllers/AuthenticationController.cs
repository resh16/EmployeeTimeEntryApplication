using DataAccessLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjectLayer.Models;
using DataAccessLayer;
using BusinessLogic;

namespace TimeEntry.Controllers
{
    public class AuthenticationController : Controller
    {
        //private readonly AppDbContext _db;
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AccountBL _accountBL;

        public AuthenticationController(AccountBL acccount,SignInManager<ApplicationUser> _SignIn)
        {         
            _accountBL = acccount;
            _signInManager = _SignIn;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CheckUser(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("CreateEntry","TimeEntry");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CreateUser(model);


                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Authentication");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}

