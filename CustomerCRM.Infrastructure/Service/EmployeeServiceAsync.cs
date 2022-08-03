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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        IEmployeeRepositoryAsync employeeRepositoryAsync;
        IRegionRepositoryAsync regionRepositoryAsync;
        public EmployeeServiceAsync(IEmployeeRepositoryAsync _repo, IRegionRepositoryAsync _region)
        {
            employeeRepositoryAsync = _repo;
            regionRepositoryAsync = _region;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            var employees = await employeeRepositoryAsync.GetAllAsync();
            if (employees != null)
            {
                List<EmployeeModel> lstEmployees = new List<EmployeeModel>();
                foreach (var c in employees)
                {
                    EmployeeModel model = new EmployeeModel();
                    model.Id = c.Id;
                    model.FirstName = c.FirstName;
                    model.LastName = c.LastName;
                    model.Title = c.Title;
                    model.TitleOfCourtesy = c.TitleOfCourtesy;
                    model.BirthDate = c.BirthDate;
                    model.HireDate = c.HireDate;
                    model.Address = c.Address;
                    model.City = c.City;
                    model.RegionId = c.RegionId;
                    model.PostalCode = c.PostalCode;
                    model.Country = c.Country;
                    model.Phone = c.Phone;
                    model.ReportsTo = c.ReportsTo;
                    model.PhotoPath = c.PhotoPath;
                    lstEmployees.Add(model);
                }
                return lstEmployees;
            }
            return null;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            Employee c = await employeeRepositoryAsync.GetByIdAsync(id);
            if (c != null)
            {
                EmployeeModel model = new EmployeeModel();
                model.Id = c.Id;
                model.FirstName = c.FirstName;
                model.LastName = c.LastName;
                model.Title = c.Title;
                model.TitleOfCourtesy = c.TitleOfCourtesy;
                model.BirthDate = c.BirthDate;
                model.HireDate = c.HireDate;
                model.Address = c.Address;
                model.City = c.City;
                model.RegionId = c.RegionId;
                model.PostalCode = c.PostalCode;
                model.Country = c.Country;
                model.Phone = c.Phone;
                model.ReportsTo = c.ReportsTo;
                model.PhotoPath = c.PhotoPath;

                return model;
            }
            return null;
        }

        public Task<int> InsertEmployeeAsync(EmployeeModel model)
        {
            Employee employee = new Employee()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                TitleOfCourtesy = model.TitleOfCourtesy,
                BirthDate = model.BirthDate,
                HireDate = model.HireDate,
                Address = model.Address,
                City = model.City,
                RegionId = model.RegionId,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                ReportsTo = model.ReportsTo,
                PhotoPath = model.PhotoPath,

            };
            return employeeRepositoryAsync.InsertAsync(employee);
        }


        public Task<int> DeleteEmployeeAsync(int id)
        {
            return employeeRepositoryAsync.DeleteAsync(id);
        }

        public Task<int> UpdateEmployeeAsync(EmployeeModel model)
        {
            Employee employeeEntity = new Employee();
            employeeEntity.Id = model.Id;
            employeeEntity.FirstName = model.FirstName;
            employeeEntity.LastName = model.LastName;
            employeeEntity.Title = model.Title;
            employeeEntity.TitleOfCourtesy = model.TitleOfCourtesy;
            employeeEntity.BirthDate = model.BirthDate;
            employeeEntity.HireDate = model.HireDate;
            employeeEntity.Address = model.Address;
            employeeEntity.City = model.City;
            employeeEntity.RegionId = model.RegionId;
            employeeEntity.PostalCode = model.PostalCode;
            employeeEntity.Country = model.Country;
            employeeEntity.Phone = model.Phone;
            employeeEntity.ReportsTo = model.ReportsTo;
            employeeEntity.PhotoPath = model.PhotoPath;
            return employeeRepositoryAsync.UpdateAsync(employeeEntity);
        }




    }
}
