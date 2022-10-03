using BurgerApp.DATA.ACCESS;
using BurgerApp.DATA.ACCESS.EFImplementations;
using BurgerApp.DOMAIN.Models;
using BurgerApp.SERVICES.Implementations;
using BurgerApp.SERVICES.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BurgerApp.HELPERS
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {            
            services.AddTransient<IOrderRepository, OrderEFRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();
            services.AddTransient<IRepository<Burger>, BurgerEFRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
            {
                options.UseSqlServer("Server=.\\sqlexpress; Database = BurgerAppDb; Trusted_Connection=True;");
            });
        }
    }
}
