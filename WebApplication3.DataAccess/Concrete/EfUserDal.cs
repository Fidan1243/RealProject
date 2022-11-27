using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Concrete
{
    public class EfUserDal : WebApplication3.Core.DataAccess.EntityFramework.EfEntityRepositoryBase<WebApplication3.Entities.Concrete.Post, WebApplication3.DataAccess.Concrete.ProjectContext>, WebApplication3.DataAccess.Abstract.IPostDal
    {
    }
}
