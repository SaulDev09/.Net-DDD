﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Saul.Test.Services.WebAPI.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });
            services.AddHealthChecksUI().AddInMemoryStorage();
            return services;
        }
    }
}
