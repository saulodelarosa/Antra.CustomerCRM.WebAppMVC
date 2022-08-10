using CustomerCRM.Core.Entities;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<SignInResult> LogInAsync(SignInModel model);
    }
}
