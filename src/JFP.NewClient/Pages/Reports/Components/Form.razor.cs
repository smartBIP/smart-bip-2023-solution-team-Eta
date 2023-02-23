using Blazored.Toast.Services;
using JFP.Domain.Common;
using JFP.Domain.Reports;
using JFP.Shared.Images;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Colors;

namespace JFP.NewClient.Pages.Reports.Components;

public partial class Form
{
    private List<string> _reportCategories = new()
    {
        "Broken Street",
        "Traffic Lights",
        "Trash Can",
        "Other"
    };
    private List<MudChip> _categoryChips = new();
    private ReportDto.Mutate _report = new();
    private MudChip _selected = default!;

    [Parameter] public ImageResponse.CreateResponse Response { get; set; } = default!;
    [Parameter] public LocationDto.Index Location { get; set; } = default!;
    
    [Inject] public IToastService ToastService { get; set; } = default!;
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    [Inject] public IReportService ReportService { get; set; } = default!;

    protected override void OnInitialized()
    {
        int counter = 1;

        foreach (string category in _reportCategories)
        {
            MudChip chip = new()
            {
                Color = Color.Primary,
                Value = counter,
                Text = category,
                Default = false
            };

            counter++;

            if (Response.Prediction.ReportCategory == _reportCategories.FindIndex(c => c == category) + 1)
            {
                chip.Default = true;
                _selected = chip;
            }

            _categoryChips.Add(chip);
        }
    }

    private void HandleSelect(string selectedElement)
    {
        switch (selectedElement)
        {
            case "Low":
                _report.ReportSeverity = 1;
                break;
            case "Medium":
                _report.ReportSeverity = 2;
                break;
            case "High":
                _report.ReportSeverity = 3;
                break;
            default:
                break;
        }
    }

    private async Task HandleSubmit()
    {
        _report.Image = Response.Image.Id;
        _report.ReportCategory = (int)_selected.Value;
        _report.Location = Location;

        await ReportService.CreateAsync(_report);

        ToastService.ShowSuccess("Your report has been submitted");
    }
}