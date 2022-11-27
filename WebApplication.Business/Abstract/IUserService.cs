using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IUserService
    {
        void AddUser(CustomIdentityUser user);
    }
}
