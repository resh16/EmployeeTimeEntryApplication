
using BusinessObjectLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Access
{
    public class AccountDAL
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _db;


        public AccountDAL(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext db)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _db = db;
        }

        public async Task<IdentityResult> CreateUser(Register model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded && model.Admin == true)
            {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Employee");
            }

            return result;
        }

        public async Task<SignInResult> CheckUser(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                 user.Email, model.Password, model.RememberMe, false);

                return result;
            }

            var res = SignInResult.Failed;
            return res;
        }


    }
}