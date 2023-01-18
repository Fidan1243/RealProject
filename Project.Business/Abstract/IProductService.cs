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
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }
}
