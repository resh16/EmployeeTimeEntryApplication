
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

        public AccountDAL(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
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
                await _userManager.AddToRoleAsync(user, "Admin");
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

        public async Task<ApplicationUser> GetId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
