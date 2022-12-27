using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrand(int id);
        void AddBrand(Brand brand);
        void RemoveBrand(int id);
    }
}
