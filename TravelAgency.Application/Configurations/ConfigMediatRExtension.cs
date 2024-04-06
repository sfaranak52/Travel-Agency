
namespace TravelAgency.Application.Configurations;
public static class ConfigMediatRExtension
{
    public static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigMediatRExtension).Assembly));

        return services;
    }


}
