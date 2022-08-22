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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        ICustomerRepositoryAsync customerRepositoryAsync;
        IRegionRepositoryAsync regionRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _repo, IRegionRepositoryAsync _region)
        {
            customerRepositoryAsync = _repo;
            regionRepositoryAsync = _region;
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var customers = await customerRepositoryAsync.GetAllAsync();
            if (customers != null)
            {
                List<CustomerResponseModel> lstCustomers = new List<CustomerResponseModel>();
                foreach (var c in customers)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = c.Id;
                    model.Name = c.Name;
                    model.Phone = c.Phone;
                    model.Address = c.Address;
                    model.City = c.City;
                    model.Title = c.Title;
                    model.Country = c.Country;
                    model.RegionId = c.RegionId;
                    model.PostalCode = c.PostalCode;
                    var region = await regionRepositoryAsync.GetByIdAsync(c.RegionId);
                    model.RegionName = region.Name;
                    lstCustomers.Add(model);
                }
                return lstCustomers;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
        {
            Customer c = await customerRepositoryAsync.GetByIdAsync(id);
            if (c != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = c.Id;
                model.Name = c.Name;
                model.Phone = c.Phone;
                model.Address = c.Address;
                model.City = c.City;
                model.Title = c.Title;
                model.Country = c.Country;
                model.RegionId = c.RegionId;
                model.PostalCode = c.PostalCode;
                var region = await regionRepositoryAsync.GetByIdAsync(c.RegionId); 
                model.RegionName = region.Name;

                return model;
            }
            return null;
        }

        public Task<int> InsertCustomerAsync(CustomerModel model)
        {
            Customer customer = new Customer()
            {

                Name = model.Name,
                Title = model.Title,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Phone = model.Phone,
                PostalCode = model.PostalCode,
                RegionId = model.RegionId

            };
            return customerRepositoryAsync.InsertAsync(customer);
        }

        public Task<int> DeleteCustomerAsync(int id)
        {
            return customerRepositoryAsync.DeleteAsync(id);
        }

        public Task<int> UpdateCustomerAsync(CustomerModel model)
        {
            Customer customerEntity = new Customer();
            customerEntity.Id = model.Id;
            customerEntity.Name = model.Name;
            customerEntity.Title = model.Title;
            customerEntity.Address = model.Address;
            customerEntity.City = model.City;
            customerEntity.Country = model.Country;
            customerEntity.Phone = model.Phone;
            customerEntity.PostalCode = model.PostalCode;
            customerEntity.RegionId = model.RegionId;
            return customerRepositoryAsync.UpdateAsync(customerEntity);
        }



    }
}
