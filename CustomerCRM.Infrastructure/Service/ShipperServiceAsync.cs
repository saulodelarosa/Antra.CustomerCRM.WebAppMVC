using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Entities;
using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Service
{
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        IShipperRepositoryAsync shipperRepositoryAsync;
        IRegionRepositoryAsync regionRepositoryAsync;
        public ShipperServiceAsync(IShipperRepositoryAsync _repo, IRegionRepositoryAsync _region)
        {
            shipperRepositoryAsync = _repo;
            regionRepositoryAsync = _region;
        }

        public async Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            var shippers = await shipperRepositoryAsync.GetAllAsync();
            if (shippers != null)
            {
                List<ShipperModel> lstShippers = new List<ShipperModel>();
                foreach (var c in shippers)
                {
                    ShipperModel model = new ShipperModel();
                    model.Id = c.Id;
                    model.Name = c.Name;
                    model.Phone = c.Phone;
                    lstShippers.Add(model);
                }
                return lstShippers;
            }
            return null;
        }

        public async Task<ShipperModel> GetShipperByIdAsync(int id)
        {
            Shipper c = await shipperRepositoryAsync.GetByIdAsync(id);
            if (c != null)
            {
                ShipperModel model = new ShipperModel();
                model.Id = c.Id;
                model.Name = c.Name;
                model.Phone = c.Phone;

                return model;
            }
            return null;
        }

        public Task<int> InsertShipperAsync(ShipperModel model)
        {
            Shipper shipper = new Shipper()
            {

                Name = model.Name,
                Phone = model.Phone,

            };
            return shipperRepositoryAsync.InsertAsync(shipper);
        }


        public Task<int> DeleteShipperAsync(int id)
        {
            return shipperRepositoryAsync.DeleteAsync(id);
        }

        public Task<int> UpdateShipperAsync(ShipperModel model)
        {
            Shipper shipperEntity = new Shipper();
            shipperEntity.Id = model.Id;
            shipperEntity.Name = model.Name;
            shipperEntity.Phone = model.Phone;
            return shipperRepositoryAsync.UpdateAsync(shipperEntity);
        }




    }
}
