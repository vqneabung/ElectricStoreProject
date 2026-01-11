using Common.Extensions;
using ElectricStoreProject.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {   
            services.AddBaseServicesWithDbContext<ElectricStoreDBContext>(configuration);

            // Infrastructure service registrations go here
            return services;
        }

    }
}
