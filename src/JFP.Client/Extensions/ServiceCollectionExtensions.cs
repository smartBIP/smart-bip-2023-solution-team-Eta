using JFP.Client.Pages.Reports;
using JFP.Shared.Images;

namespace JFP.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddScoped<ImageService>();

        return services;
    }
}
