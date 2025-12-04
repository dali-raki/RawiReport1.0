using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;

namespace RawiReport.Components.Pages;

public partial class ReportList
{
    [Inject] public IReportsServices ReportsServices { get; set; }
    [Inject] public NavigationManager nv { get; set; }

    private List<ReportHeaderModel> ReportsActive, ReportsInActive;
    protected override async Task OnInitializedAsync()
    {
        ReportsActive = await ReportsServices.GetAllReportHeader(ReportStatus.Enabled);
        ReportsInActive = await ReportsServices.GetAllReportHeader(ReportStatus.Disabled);
    }
    void n(Guid a) => nv.NavigateTo($"report/Edit/{a}",true);

}