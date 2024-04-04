using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class ProductService : IProductService
    {
        IRepositoryBase<ProductEnt, int> _ProductRepo;
        IRepositoryBase<ProductCategoryEnt, int> _ProductCategoryRepo;
        public ProductService(IRepositoryBase<ProductEnt, int> _ProductRepo, IRepositoryBase<ProductCategoryEnt, int> _ProductCategoryRepo)
        {
            this._ProductRepo = _ProductRepo;
            this._ProductCategoryRepo = _ProductCategoryRepo;
        }
        public bool AddProduct(ProductEnt item)
        {
            try
            {
                return _ProductRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                return _ProductRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool EditProduct(ProductEnt item)
        {
            try
            {
                return _ProductRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public ProductEnt ProductDetails(int id)
        {
            try
            {
                return _ProductRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<ProductEnt> ProductDetailsAsync(int id)
        {
            try
            {
                return await _ProductRepo.GetAllAsync().Where(p => p.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductEnt> ListAllProducts()
        {
            try
            {
                return _ProductRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<ProductCategoryEnt> ListProduCategory()
        {
            try
            {
                return _ProductCategoryRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IfUsedProduCategory(int id)
        {
            try
            {
                return _ProductRepo.GetAll().Any(p => p.ProductCategoryID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProduCategory(int id)
        {
            try
            {
                return _ProductCategoryRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ProductCategoryEnt ProduCategoryDetails(int id)
        {
            try
            {
                return _ProductCategoryRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistProduCategoryTitle(string title, int id)
        {
            try
            {
                if (id == 0)
                    return _ProductCategoryRepo.GetAll().Any(p => p.Title == title);
                else
                    return _ProductCategoryRepo.GetAll().Any(p => p.Title == title & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddProduCategory(ProductCategoryEnt model)
        {
            try
            {
                return _ProductCategoryRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditProduCategory(ProductCategoryEnt model)
        {
            try
            {
                return _ProductCategoryRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProductEnt> ListProduct()
        {
            try
            {
                return _ProductRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistProductTitle(string title, int id)
        {
            try
            {
                if (id == 0)
                    return _ProductRepo.GetAll().Any(p => p.Title == title);
                else
                    return _ProductRepo.GetAll().Any(p => p.Title == title & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProductEnt> ListProductsByCategory(int id)
        {
            try
            {
                return _ProductRepo.GetAll().Where(p => p.ProductCategoryID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
