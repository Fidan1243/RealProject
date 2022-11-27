using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Core.DataAccess.EntityFramework;
using WebApplication3.DataAccess.Abstract;
using WebApplication3.Entities.Concrete;

namespace WebApplication3.DataAccess.Concrete
{
    public class EfFriendDal: EfEntityRepositoryBase<Friend, ProjectContext>, IFriendDal
    {
    }
}
