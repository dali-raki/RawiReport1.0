using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Machines;
using RawiReportUI.Modals.ReportsDaily;

namespace RawiReport.Components.Pages;

public partial class ReportCreate 
{
    [Parameter] public Guid Id { get; set; }
    [Inject] private IMachinesServices machinesServices { get; set; }
    [Inject] private IBreackdownService breackdownServices { get; set; }

    [Inject] private IReportsServices reportsServices { get; set; }
 
    private List<MachineModel> lismachines = new();
    private BreackdownModal breackdownlink;
    private List<BreackdownInfo>? breakdowns = new();
    private BreackdownInfo? editingBreakdown;
    private ReportInfo reportInfo = new();
    private bool operationmodal = false;
    private bool operationstatus;

    override protected async Task OnInitializedAsync()
    {
        lismachines = await machinesServices.GetMachines();
        reportInfo = await reportsServices.GetReportById(Id);
        breakdowns = reportInfo.BreackdownList;
    }

    private void showmodal()
    {
        operationstatus = false;
        editingBreakdown = null;
        breackdownlink.OpenModal();
    }


    private void EditBreakdown(BreackdownInfo model)
    {
        editingBreakdown = model;
        operationstatus = true;
        breackdownlink.OpenModal(model);


    }

    private async Task DeleteBreakdown(BreackdownInfo model)
    {
        if (model == null) return;
        breakdowns.Remove(model);

        await breackdownServices.RemoveBreakdown(model.BreakdownId);
    }

    private void selectbreakdown(BreackdownInfo model)
    {
        if(operationstatus == false)
        breakdowns.Add(model);

        OnInitializedAsync();
        StateHasChanged();
    }
}