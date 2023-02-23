using JFP.Domain.Common;

namespace JFP.Domain.Reports;

public static class ReportDto
{
    public class Mutate
    {
		public LocationDto.Index Location { get; set; } = default!;
		public Guid Image { get; set; }
		public int ReportCategory { get; set; }
		public int ReportSeverity { get; set; }
		public string Description { get; set; } = default!;
		public string Issuer { get; set; } = default!;
	}
}