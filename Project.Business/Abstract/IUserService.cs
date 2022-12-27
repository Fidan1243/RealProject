using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void RemoveUser(int id);
    }
}
