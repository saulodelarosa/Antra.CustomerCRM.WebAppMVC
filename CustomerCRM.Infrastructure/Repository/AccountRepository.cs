using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Entities;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(UserManager<ApplicationUser> m, SignInManager<ApplicationUser> s)
        {
            userManager = m;
            signInManager = s;
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel user)
        {
            ApplicationUser AppUser = new ApplicationUser();
            AppUser.FirstName = user.FirstName;
            AppUser.LastName = user.LastName;
            AppUser.Email = user.Email;
            AppUser.UserName = user.Email;

            return userManager.CreateAsync(AppUser, user.Password);

        }

        public Task<SignInResult> LogInAsync(SignInModel model)
        {
            var result = signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
            return result;
        }
    }
}
