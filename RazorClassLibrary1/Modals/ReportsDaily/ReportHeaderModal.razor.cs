using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;

namespace RawiReportUI.Modals.ReportsDaily;

public partial class ReportHeaderModal
{
    [Inject] private IReportsServices reportsServices { get; set; }
    [Inject] private NavigationManager nv { get; set; }
    private ReportInfo reportInfo = new ReportInfo();
    private bool showModal;

    public void Show()
    {
        showModal = true;
        StateHasChanged();
    }
    private void Hide()
    {
        showModal = false;
        StateHasChanged();
    }
    private async Task savereport()
    {
        var reportHeader = new ReportHeaderModel
        {
            Id = Guid.NewGuid(),
            Leader = reportInfo.Leader,
            Date = reportInfo.Date,

            // Build StartTime using today's date + time from input
            StartTime = new DateTime(
        DateTime.Today.Year,
        DateTime.Today.Month,
        DateTime.Today.Day,
        reportInfo.StartTime.Hour,
        reportInfo.StartTime.Minute,
        0
    ),
            EndTime = new DateTime(
        DateTime.Today.Year,
        DateTime.Today.Month,
        DateTime.Today.Day,
        reportInfo.EndTime.Hour,
        reportInfo.EndTime.Minute,
        0
    ),

            ProductId = reportInfo.ProductId,
            Objective = reportInfo.Objective,
            Speed = reportInfo.Speed,
            CreatedAt = DateTime.Now,
            CreateBy = Guid.NewGuid(),
            Updatlast = DateTime.Now,
            ReportStatus = ReportStatus.Enabled,
        };

        await reportsServices.CreateReportHeader(reportHeader);
        Hide();
        nv.NavigateTo(nv.Uri, forceLoad: true);
    }
}