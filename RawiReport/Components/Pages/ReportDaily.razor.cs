using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.MachinesApps;
using RawiReport.Domains.Models.Machines;
using RawiReportUI.Components.Modals.ReportsDaily;

namespace RawiReport.Components.Pages;

public partial class ReportDaily
{
    [Inject] private IMachinesServices machinesServices { get; set; }

    private List<MachineModel> lismachines = new();
    private BreackdownModal breackdownlink;
    override protected async Task OnInitializedAsync()
    {
        lismachines = await machinesServices.GetMachines();
    }
    private void showmodal()
    {
        breackdownlink.OpenModal();
    }
}