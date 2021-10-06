using BusinessObjectLayer.Models;
using DataAccessLayer.Access;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        private readonly AccountDAL _accountDAL;
        public AccountBL(AccountDAL accountDAL)
        {
            this._accountDAL = accountDAL;
        }
        public Task<IdentityResult> CreateUser(Register model)
        {
            var result = _accountDAL.CreateUser(model);
            return result;
        }

        public Task<SignInResult> CheckUser(Login model)
        {
            var result = _accountDAL.CheckUser(model);

            return result;
        }

        public Task<ApplicationUser> GetId(string id)
        {
            var result = _accountDAL.GetId(id);

            return result;
        }
    }
}
