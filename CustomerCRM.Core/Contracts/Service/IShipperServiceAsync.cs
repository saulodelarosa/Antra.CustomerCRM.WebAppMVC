using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface IShipperServiceAsync
    {
        Task<int> InsertShipperAsync(ShipperModel model);
        Task<ShipperModel> GetShipperByIdAsync(int id);
        Task<IEnumerable<ShipperModel>> GetAllAsync();
        Task<int> DeleteShipperAsync(int id);
        Task<int> UpdateShipperAsync(ShipperModel model);

    }
}
