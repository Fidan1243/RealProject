using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.DataAccess.Concrete
{
    public class EfProductDal: EfEntityRepositoryBase<Product, ProjectContext>, IProductDal
    {
    }
}
