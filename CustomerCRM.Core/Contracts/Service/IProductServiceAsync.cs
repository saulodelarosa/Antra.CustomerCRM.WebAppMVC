using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface IProductServiceAsync
    {
        Task<int> InsertProductAsync(ProductModel model);
        Task<ProductModel> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<int> DeleteProductAsync(int id);
        Task<int> UpdateProductAsync(ProductModel model);

    }
}
