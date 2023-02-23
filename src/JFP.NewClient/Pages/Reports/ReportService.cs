using JFP.Domain.Reports;

namespace JFP.NewClient.Pages.Reports;

public class ReportService : IReportService
{
    private const string _endpoint = "api/Report";

    private readonly HttpClient _client;

    public ReportService(HttpClient client)
    {
        _client = client;
    }

    public async Task CreateAsync(ReportDto.Mutate model)
    {
        var response = await _client.PostAsJsonAsync(_endpoint, model);
    }
}