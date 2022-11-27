using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Entities.Concrete;

namespace WebApplication3.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetAll();
        List<Post> GetByCategory(string categoryId);
        List<Post> GetByUser(string userId);
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        Post GetById(string id);
    }
}
