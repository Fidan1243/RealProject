using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        List<Product> GetProductByModel(int id);
        List<Product> GetProductByMaterial(int id);
        List<Product> GetProductByCategories(int modelId, int materialId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetProductsByName(string productName);
        void RemoveProduct(int id);
    }
}
