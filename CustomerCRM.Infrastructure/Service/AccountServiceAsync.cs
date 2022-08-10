using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Service
{
    public class AccountServiceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepository accountRepository;

        public AccountServiceAsync(IAccountRepository repo)
        {
            accountRepository = repo;
        }

        public Task<SignInResult> LogInAsync(SignInModel model)
        {
            return accountRepository.LogInAsync(model);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel user)
        {
            return accountRepository.SignUpAsync(user);
        }
    }
}
