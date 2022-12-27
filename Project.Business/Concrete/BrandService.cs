using Project.Business.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class BrandService : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandService(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public Brand GetBrand(int id)
        {
            var brand = _brandDal.Get(g=> g.Id == id);
            return brand;
        }

        public List<Brand> GetBrands()
        {
            var brand = _brandDal.GetList();
            return brand;
        }

        public void RemoveBrand(int id)
        {
            _brandDal.Delete(GetBrand(id));
        }
    }
}
