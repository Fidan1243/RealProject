using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Business.Abstract
{
    public interface IFriendService
    {
        void GetFriends(string Id);
        void AddFriend(string UserId);
        void RemoveFriend(string UserId);
    }
}
