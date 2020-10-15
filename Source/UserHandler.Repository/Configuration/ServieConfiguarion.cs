using Microsoft.Extensions.DependencyInjection;
using UserHandler.Db.Models;

namespace UserHandler.Repository.Configuration
{
    public class ServieConfiguarion
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, UserRepository>();
        }
    }
}
