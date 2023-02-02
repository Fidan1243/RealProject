using Microsoft.Extensions.DependencyInjection;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DataAccess.Abstract;

namespace Project.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IComboDal, EfComboDal>();
            services.AddScoped<ICartDal, EfCartDal>();
            services.AddScoped<ICartItemDal, EfCartItemDal>();
            services.AddScoped<IComboLikeDal, EfComboLikeDal>();
            services.AddScoped<IComboCommentDal, EfComboCommentDal>();
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderStatusDal, EfOrderStatusDal>();
            services.AddScoped<IMaterialDal, EfMaterialDal>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IModelDal, EfModelDal>();
            services.AddScoped<IUserDal, EfUserDal>();

            return services;
        }
    }
}
