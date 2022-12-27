using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.Add(user);
        }

        public User GetUser(int id)
        {
            var user = _userDal.Get(g => g.Id == id);
            return user;
        }

        public List<User> GetUsers()
        {
            var users = _userDal.GetList();
            return users;
        }

        public void RemoveUser(int id)
        {
            _userDal.Delete(GetUser(id));
        }
    }
}
