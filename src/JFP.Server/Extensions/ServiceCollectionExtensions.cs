using JFP.Domain.Reports;
using JFP.Server.Services;
using JFP.Shared.Images;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;

namespace JFP.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPredictionModels(this IServiceCollection services)
    {
        services.AddPredictionEnginePool<RecognitionModel.ModelInput, RecognitionModel.ModelOutput>()
            .FromFile("RecognitionModel.zip");

        return services;
    }

    public static IServiceCollection AddPredictionServices(this IServiceCollection services)
    {
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}
