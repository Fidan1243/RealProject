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

        public List<Product> GetProducts()
        {
            var product = _productDal.GetList();
            return product;
        }

        public void RemoveProduct(int id)
        {
            _productDal.Delete(GetProduct(id));
        }
    }
}
