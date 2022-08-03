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
    public class VendorServiceAsync : IVendorServiceAsync
    {
        IVendorRepositoryAsync vendorRepositoryAsync;
        IRegionRepositoryAsync regionRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync _repo, IRegionRepositoryAsync _region)
        {
            vendorRepositoryAsync = _repo;
            regionRepositoryAsync = _region;
        }

        public async Task<IEnumerable<VendorModel>> GetAllAsync()
        {
            var vendors = await vendorRepositoryAsync.GetAllAsync();
            if (vendors != null)
            {
                List<VendorModel> lstVendors = new List<VendorModel>();
                foreach (var c in vendors)
                {
                    VendorModel model = new VendorModel();
                    model.Id = c.Id;
                    model.Name = c.Name;
                    model.Mobile = c.Mobile;
                    model.EmailId = c.EmailId;
                    model.IsActive = c.IsActive;
                    model.City = c.City;
                    model.Country = c.Country;
                    lstVendors.Add(model);
                }
                return lstVendors;
            }
            return null;
        }

        public async Task<VendorModel> GetVendorByIdAsync(int id)
        {
            Vendor c = await vendorRepositoryAsync.GetByIdAsync(id);
            if (c != null)
            {
                VendorModel model = new VendorModel();
                model.Id = c.Id;
                model.Name = c.Name;
                model.Mobile = c.Mobile;
                model.EmailId = c.EmailId;
                model.IsActive = c.IsActive;
                model.City = c.City;
                model.Country = c.Country;


                return model;
            }
            return null;
        }

        public Task<int> InsertVendorAsync(VendorModel model)
        {
            Vendor vendor = new Vendor()
            {

                Name = model.Name,
                Mobile = model.Mobile,
                EmailId = model.EmailId,
                IsActive = model.IsActive,
                City = model.City,
                Country = model.Country,


            };
            return vendorRepositoryAsync.InsertAsync(vendor);
        }


        public Task<int> DeleteVendorAsync(int id)
        {
            return vendorRepositoryAsync.DeleteAsync(id);
        }

        public Task<int> UpdateVendorAsync(VendorModel model)
        {
            Vendor vendorEntity = new Vendor();
            vendorEntity.Id = model.Id;
            vendorEntity.Name = model.Name;
            vendorEntity.Mobile = model.Mobile;
            vendorEntity.IsActive = model.IsActive;
            vendorEntity.City = model.City;
            vendorEntity.Country = model.Country;
            vendorEntity.EmailId = model.EmailId;

            return vendorRepositoryAsync.UpdateAsync(vendorEntity);
        }




    }
}
