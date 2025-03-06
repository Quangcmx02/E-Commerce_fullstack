using AsmC5.Context;
using AsmC5.Contracts;
using AsmC5.Interfaces;
using AsmC5.Persistence.Repositories;
using AsmC5.Services;

namespace AsmC5
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodItemRepository, FoodItemRepository>(); // Đăng ký service
            services.AddScoped<IFoodItemService, FoodItemService>(); // Đăng ký IFoodItemService
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IAuthService, AuthService>(); 
            services.AddScoped<IComboRepository, ComboRepository>();
            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped <ICartService, CartService>();
            services.AddScoped <ICategoryService, CategoryService>();
            services.AddScoped <ICategoryRepository, CategoryRepository>();
            services.AddScoped <IComboFoodItemRepository, ComboFoodItemRepository>(); //
            services.AddScoped<IComboFoodItemDetailRepository, ComboFoodItemDetailRepository>();
            services.AddScoped <ISessionService, SessionService>();
            services.AddScoped <IOrderRepository, OrderRepository>();
            services.AddScoped <IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
