using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface IVendorServiceAsync
    {
        Task<int> InsertVendorAsync(VendorModel model);
        Task<VendorModel> GetVendorByIdAsync(int id);
        Task<IEnumerable<VendorModel>> GetAllAsync();
        Task<int> DeleteVendorAsync(int id);
        Task<int> UpdateVendorAsync(VendorModel model);

    }
}
