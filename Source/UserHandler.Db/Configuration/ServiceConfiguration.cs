using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserHandler.Db.Configuration
{
    public class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDbFactory, MongoDbFactory>();
        }
    }
}
