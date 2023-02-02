using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public Product GetProduct(int id)
        {
            var product = _productDal.Get(g => g.Id == id);
            return product;
        }

        public List<Product> GetProductByCategories(int modelId, int materialId)
        {
            return _productDal.GetList(p => p.Model_Id == modelId || modelId == 0 && p.Material_Id == materialId || materialId == 0);
        }

        public List<Product> GetProductByMaterial(int id)
        {
            return _productDal.GetList(p => p.Material_Id == id || id == 0);
        }

        public List<Product> GetProductByModel(int id)
        {
            var product = _productDal.GetList(g => g.Model_Id == id || id == 0);
            return product;
        }

        public List<Product> GetProducts()
        {
            var product = _productDal.GetList();
            return product;
        }

        public List<Product> GetProductsByName(string productName)
        {
            var product = _productDal.GetList(g => g.Name == productName);
            return product;
        }

        public void RemoveProduct(int id)
        {
            _productDal.Delete(GetProduct(id));
        }

        public void UpdateProduct(Product product)
        {
            _productDal.Update(product);
        }
    }
}
