﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Saul.Test.Services.WebAPI.Modules.Feature
{
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration, string myPolicy)
        {
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod()
                                                                            ));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            return services;
        }

    }
}