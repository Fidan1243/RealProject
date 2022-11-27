using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Abstract
{
    public interface IUserDal : WebApplication3.Core.DataAccess.IEntityRepository<Entities.Concrete.User>
    {
    }
}
