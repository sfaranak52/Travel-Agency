
using Travelagency.Infrastructure.Repositories;

namespace Travelagency.Infrastructure.Configurations;

public static class RegisterInfrastructureServicesExtension
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<IPayRepository, PayRepository>();
        return services;
    }
}