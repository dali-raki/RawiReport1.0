using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Machines;
using RawiReport.Domains.Models.Reports;
using RawiReportUI.Components.Modals.ReportsDaily;
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
    private List<BreackdownModel> breakdowns = new();
    private BreackdownModel? editingBreakdown;
    private ReportInfo reportInfo = new();
   /* private Guid L2 = Guid.Parse("DBF8B637-BE7D-436B-BA03-8FD82E5CDF22");
    private Guid L1_5 = Guid.Parse("C3CD0E1C-F2CB-4FD6-830D-8D54464AC6DD");
    private Guid L1 = Guid.Parse("A4A6F76D-6616-4B17-8BC9-162F1A3CA2A9");
    private Guid L0_5 = Guid.Parse("A437ED8F-C837-4769-9FA1-461191ED9518");*/


    override protected async Task OnInitializedAsync()
    {
        lismachines = await machinesServices.GetMachines();
        if(Id != Guid.Empty)
        {
            
        }
        else
        {
           // reportInfo = await reportsServices.GetReportById(Id);
        }
    }

    private async Task savereport()
    {
        var reportHeader = new ReportHeaderModel
        {
            Id = Guid.NewGuid(),
            Date = reportInfo.Date,
            StartTime = reportInfo.StartTime,
            EndTime = reportInfo.EndTime,
            ProductId = reportInfo.ProductId,
            Objective = reportInfo.Objective,
            Speed = reportInfo.Speed,
            CreatedAt = DateTime.Now,
            CreateBy = Guid.NewGuid(), 
            Updatlast = DateTime.Now,
            ReportStatus = ReportStatus.Enabled,
            Breackdowns = breakdowns
        };
       
        await reportsServices.CreateReportHeader(reportHeader);

        nv.NavigateTo("/reports");
    }
    private void showmodal()
    {
        editingBreakdown = null;
        breackdownlink.OpenModal();
    }

    private void AddOrUpdateBreakdown(BreackdownModel model)
    {
        if (model == null) return;

        var existing = breakdowns.FirstOrDefault(b => b.Id == model.Id);
        if (existing is null)
        {
            breakdowns.Add(model);
        }
        else
        {
            existing.MachineId = model.MachineId;
            existing.StoppingTime = model.StoppingTime;
            existing.DurationStopping = model.DurationStopping;
            existing.ErrorCode = model.ErrorCode;
            existing.Description = model.Description;
        }

        StateHasChanged();
    }

    private void EditBreakdown(BreackdownModel model)
    {
        editingBreakdown = model;
        breackdownlink.OpenModal(model);
    }

    private void DeleteBreakdown(BreackdownModel model)
    {
        if (model == null) return;
        breakdowns.Remove(model);
    }

    void selectbreakdown(BreackdownModel model)
    {
        breakdowns.Add(model);
        StateHasChanged();
    }
}