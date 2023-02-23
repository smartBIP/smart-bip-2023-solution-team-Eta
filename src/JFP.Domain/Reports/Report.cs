using JFP.Domain.Common;

namespace JFP.Domain.Reports;

public class Report
{
    public Location Location { get; private set; }
	public ReportCategory Category { get; private set; }
	public ReportSeverity Severity { get; private set; }
	public string Description { get; private set; }
	public string? Issuer { get; private set; }
	public DateTime ReportDate { get; private set; }
	public DateTime? HandleDate { get; private set; }
	public Guid Image { get; private set; }

	public bool IsHandled => HandleDate is not null;

	public Report(string latitude, string longitude, ReportCategory category, ReportSeverity severity, string issuer, string description, Guid image)
	{
		Location = new Location(latitude, longitude);
		Category = category;
		Severity = severity;
		Description = description;
		Issuer = issuer;
		Description = description;
		ReportDate = DateTime.Now;
		Image = image;
	}
}
