using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Core.DataAccess;
using WebApplication3.Entities.Concrete;

namespace WebApplication3.DataAccess.Abstract
{
    public interface IFriendDal: IEntityRepository<Friend>
    {
    }
}
