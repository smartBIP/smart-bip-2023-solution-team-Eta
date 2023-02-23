using JFP.Domain.Reports;
using JFP.NewClient.Pages.Reports;

namespace JFP.NewClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddScoped<ImageService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}
