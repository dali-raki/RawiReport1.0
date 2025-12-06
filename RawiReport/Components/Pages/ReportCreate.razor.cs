using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Apps.Apps.Shared;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Machines;
using RawiReport.Domains.Models.Reports;
using RawiReport.Implementations.Services.BreackdownServices;
using RawiReportUI.Modals.ReportsDaily;
using System.Buffers;
using System.Threading.Tasks;

namespace RawiReport.Components.Pages;

public partial class ReportCreate 
{
    [Parameter] public Guid Id { get; set; }
    [Inject] private IMachinesServices machinesServices { get; set; }
    [Inject] private IBreackdownService breackdownServices { get; set; }

    [Inject] private IReportsServices reportsServices { get; set; }
    [Inject] private NavigationManager nv { get; set; }
    private List<MachineModel> lismachines = new();
    private BreackdownModal breackdownlink;
    private List<BreackdownInfo>? breakdowns = new();
    private BreackdownInfo? editingBreakdown;
    private ReportInfo reportInfo = new();
    private bool operationmodal = false;
    private bool operationstatus;
    /* private Guid L2 = Guid.Parse("DBF8B637-BE7D-436B-BA03-8FD82E5CDF22");
     private Guid L1_5 = Guid.Parse("C3CD0E1C-F2CB-4FD6-830D-8D54464AC6DD");
     private Guid L1 = Guid.Parse("A4A6F76D-6616-4B17-8BC9-162F1A3CA2A9");
     private Guid L0_5 = Guid.Parse("A437ED8F-C837-4769-9FA1-461191ED9518");*/


    override protected async Task OnInitializedAsync()
    {
        lismachines = await machinesServices.GetMachines();
        if(Id != Guid.Empty)
        {
            reportInfo = await reportsServices.GetReportById(Id);
            breakdowns = reportInfo.BreackdownList;
        }
        else
        {
           
        }
    }

    private async Task savereport()
    {
        
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