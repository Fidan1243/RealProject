using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Business;
using Project.DataAccess;
using Project.UI.Entities;
using Project.UI.Services;

namespace Project.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusiness().AddDataAccess();
            services.AddScoped<ICartSessionService, CartSessionService>();
            services.AddScoped<IOrderSessionService, OrderSessionService>();
            services.AddHttpContextAccessor();

            services.AddDbContext<CustomeIdentityDbContext>(
                options => options.UseSqlServer(@"Server=tcp:ecommercealtos.database.windows.net,1433;Initial Catalog=ProjectDb1;Persist Security Info=False;User ID=adminecommerce;Password=29u2ev66.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomeIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Account}/{action=Login}");
            });
        }
    }
}
