using Microsoft.Extensions.DependencyInjection;
using Project.Business.Abstract;
using Project.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IComboLikeService, ComboLikeService>();
            services.AddScoped<IComboCommentService, ComboCommentService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
