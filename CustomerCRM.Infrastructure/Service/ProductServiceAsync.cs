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
    public class ProductServiceAsync : IProductServiceAsync
    {
        IProductRepositoryAsync productRepositoryAsync;
        IRegionRepositoryAsync regionRepositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync _repo, IRegionRepositoryAsync _region)
        {
            productRepositoryAsync = _repo;
            regionRepositoryAsync = _region;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await productRepositoryAsync.GetAllAsync();
            if (products != null)
            {
                List<ProductModel> lstProducts = new List<ProductModel>();
                foreach (var c in products)
                {
                    ProductModel model = new ProductModel();
                    model.Id = c.Id;
                    model.Name = c.Name;
                    model.SupplierId = c.SupplierId;
                    model.CategoryId = c.CategoryId;
                    model.QuantityPerUnit = c.QuantityPerUnit;
                    model.UnitPrice = c.UnitPrice;
                    model.UnitsInStock = c.UnitsInStock;
                    model.UnitsOnOrder = c.UnitsOnOrder;
                    model.ReorderLevel = c.ReorderLevel;
                    model.Discontinued = c.Discontinued;
                    model.VendorId = c.VendorId;

                    lstProducts.Add(model);
                }
                return lstProducts;
            }
            return null;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            Product c = await productRepositoryAsync.GetByIdAsync(id);
            if (c != null)
            {
                ProductModel model = new ProductModel();
                model.Id = c.Id;
                model.Name = c.Name;
                model.SupplierId = c.SupplierId;
                model.CategoryId = c.CategoryId;
                model.QuantityPerUnit = c.QuantityPerUnit;
                model.UnitPrice = c.UnitPrice;
                model.UnitsInStock = c.UnitsInStock;
                model.UnitsOnOrder = c.UnitsOnOrder;
                model.ReorderLevel = c.ReorderLevel;
                model.Discontinued = c.Discontinued;
                model.VendorId = c.VendorId;

                return model;
            }
            return null;
        }

        public Task<int> InsertProductAsync(ProductModel model)
        {
            Product product = new Product()
            {

                Name = model.Name,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                ReorderLevel = model.ReorderLevel,
                Discontinued = model.Discontinued,
                VendorId = model.VendorId,

            };
            return productRepositoryAsync.InsertAsync(product);
        }


        public Task<int> DeleteProductAsync(int id)
        {
            return productRepositoryAsync.DeleteAsync(id);
        }

        public Task<int> UpdateProductAsync(ProductModel model)
        {
            Product productEntity = new Product();
            productEntity.Id = model.Id;
            productEntity.Name = model.Name;
            productEntity.SupplierId = model.SupplierId;
            productEntity.CategoryId = model.CategoryId;
            productEntity.QuantityPerUnit = model.QuantityPerUnit;
            productEntity.UnitPrice = model.UnitPrice;
            productEntity.UnitsInStock = model.UnitsInStock;
            productEntity.UnitsOnOrder = model.UnitsOnOrder;
            productEntity.ReorderLevel = model.ReorderLevel;
            productEntity.Discontinued = model.Discontinued;
            productEntity.VendorId = model.VendorId;
            return productRepositoryAsync.UpdateAsync(productEntity);
        }




    }
}
