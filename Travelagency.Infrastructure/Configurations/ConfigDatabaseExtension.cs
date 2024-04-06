using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelagency.Infrastructure.Configurations;

public static class ConfigDatabaseExtension
{
    public static IServiceCollection AddGeneralDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GeneralDbContext>(options =>
        {
            options.UseNpgsql(configuration["ConnectionString"],
                npgsqlOptionsAction: builder =>
                {
                    builder.MigrationsAssembly(typeof(ConfigDatabaseExtension).Assembly.GetName().Name);
                    builder.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
        });

        return services;
    }


}