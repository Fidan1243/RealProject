using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Business.Abstract;
using Project.Business.Concrete;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DataAccess.Abstract;

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

            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<IComboDal, EfComboDal>();

            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialDal, EfMaterialDal>();


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelDal, EfModelDal>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddHttpContextAccessor();

            services.AddDbContext<CustomeIdentityDbContext>(
                options => options.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
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
