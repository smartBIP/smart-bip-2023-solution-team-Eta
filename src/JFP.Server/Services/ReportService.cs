using JFP.Domain.Reports;
using System.Threading.Tasks;

namespace JFP.Server.Services;

public class ReportService : IReportService
{
    public Task CreateAsync(ReportDto.Mutate model)
    {
        Report report = new(model.Location.Longitude, model.Location.Latitude, (ReportCategory)model.ReportCategory, (ReportSeverity)model.ReportSeverity, model.Issuer, model.Description, model.Image);

        // Todo: create email service and implement it

        return Task.CompletedTask;
    }
}
