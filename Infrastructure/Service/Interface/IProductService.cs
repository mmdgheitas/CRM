using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IProductService
    {
        List<ProductEnt> ListAllProducts();
        bool DeleteProduct(int id);
        ProductEnt ProductDetails(int id);
        Task<ProductEnt> ProductDetailsAsync(int id);
        bool AddProduct(ProductEnt item);
        bool EditProduct(ProductEnt item);
        List<ProductCategoryEnt> ListProduCategory();
        bool IfUsedProduCategory(int id);
        bool DeleteProduCategory(int id);
        ProductCategoryEnt ProduCategoryDetails(int id);
        bool IFExistProduCategoryTitle(string title, int iD);
        bool AddProduCategory(ProductCategoryEnt model);
        bool EditProduCategory(ProductCategoryEnt model);
        List<ProductEnt> ListProduct();
        bool IFExistProductTitle(string title, int iD);
        List<ProductEnt> ListProductsByCategory(int id);
    }
}
