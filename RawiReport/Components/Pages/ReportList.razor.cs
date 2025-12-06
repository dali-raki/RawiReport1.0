using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;
using RawiReportUI.Modals.ReportsDaily;

namespace RawiReport.Components.Pages;

public partial class ReportList
{
    [Inject] public IReportsServices ReportsServices { get; set; }
    [Inject] public NavigationManager nv { get; set; }

    private List<ReportHeaderModel> ReportsActive, ReportsInActive;
    private ReportHeaderModal ReportHeaderlink;
    private ReportStaticInfoModal ReportSaticInfolink;
    private Guid reportId;
    private bool buttonDisabled = false;

    protected override async Task OnInitializedAsync()
    {
        ReportsActive = await ReportsServices.GetAllReportHeader(ReportStatus.Enabled);
        ReportsInActive = await ReportsServices.GetAllReportHeader(ReportStatus.Disabled);

        // disable button if there are any reports
        if (ReportsActive.Count > 0)
        {
            buttonDisabled = true;
        }
    }
    private void link(Guid Id) => nv.NavigateTo($"report/Edit/{Id}",true);

    private void showmodal()
    {
        ReportHeaderlink.Show();
    }
    private void showCloseShift(Guid Id)
    {
        reportId = Id;
        ReportSaticInfolink.ShowModal();
        StateHasChanged();
    }
}