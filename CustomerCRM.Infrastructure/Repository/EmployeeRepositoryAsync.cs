﻿using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Entities;
using CustomerCRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Repository
{
    public class EmployeeRepositoryAsync : BaseRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        public EmployeeRepositoryAsync(CustomerCrmDbContext _context) : base(_context)
        {
        }
    }
}
