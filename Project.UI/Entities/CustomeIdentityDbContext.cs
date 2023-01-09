using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.UI.Models;

namespace Project.UI.Entities
{
    public class CustomeIdentityDbContext:IdentityDbContext<CustomIdentityUser,CustomIdentityRole,string>
    {
        public CustomeIdentityDbContext(DbContextOptions<CustomeIdentityDbContext> options)
            :base(options)
        {

        }
        public DbSet<Project.UI.Models.RegisterViewModel> RegisterViewModel { get; set; }
        public DbSet<Project.UI.Models.LoginViewModel> LoginViewModel { get; set; }
    }
}
