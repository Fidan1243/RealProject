using Project.Core.DataAccess;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
    }
}
