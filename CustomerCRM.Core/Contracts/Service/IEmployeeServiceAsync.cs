using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface IEmployeeServiceAsync
    {
        Task<int> InsertEmployeeAsync(EmployeeModel model);
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
        Task<int> DeleteEmployeeAsync(int id);
        Task<int> UpdateEmployeeAsync(EmployeeModel model);

    }
}
