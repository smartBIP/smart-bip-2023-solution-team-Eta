namespace JFP.Domain.Reports;

public interface IReportService
{
    Task CreateAsync(ReportDto.Mutate model);
}
