using JFP.Domain.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JFP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

	public ReportController(IReportService reportService)
	{
		_reportService= reportService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromBody]ReportDto.Mutate model)
	{
		await _reportService.CreateAsync(model);
		return Ok();
	}
}
