using Project.Core.DataAccess;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication.DataAccess.Abstract
{
    public interface IModelDal: IEntityRepository<Model>
    {
    }
}
