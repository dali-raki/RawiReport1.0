using Microsoft.AspNetCore.Components;
using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Apps.Apps.Shared;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Machines;
using System;

using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace RawiReportUI.Modals.ReportsDaily;

public partial class BreackdownModal
{
    // incoming list of machines (note: name 'machines' used by Razor markup)
    [Parameter] public List<MachineModel>? Machines { get; set; }

    [Parameter] public Guid ReportId { get; set; }

    [Parameter] public bool Edit { get; set; } =false;

    // notify parent when a breakdown is saved
    [Parameter] public EventCallback<BreackdownInfo> OnSave { get; set; }

    [Inject] public IBreackdownService breackdownService { get; set; }

    private bool isModalOpen = false;

    private BreackdownInfo breakdown = new();

    // open modal; if an existing model is provided we'll edit it (copy to avoid two-way issues)
    public void OpenModal(BreackdownInfo? model = null)
    {
        if (model is null)
        {
            breakdown = new BreackdownInfo();
        }
        else
        {
            breakdown = new BreackdownInfo
            {
                BreakdownId = model.BreakdownId,
                ReportId = model.ReportId,
                MachineId = model.MachineId,
                StoppingTime = model.StoppingTime,
                DurationStopping = model.DurationStopping,
                ErrorCode = model.ErrorCode,
                Description = model.Description
            };
        }

        isModalOpen = true;
    }

    public void CloseModal()
    {
        isModalOpen = false;
    }


    private async Task SaveBreakdown()
    {
        if (Edit == false)
        {
            if (breakdown.BreakdownId == Guid.Empty)
                breakdown.BreakdownId = Guid.NewGuid();

            if (breakdown.ReportId == Guid.Empty)
                breakdown.ReportId = ReportId;


            var item = new BreackdownModel
            {
                Id = breakdown.BreakdownId,
                ReportId = breakdown.ReportId,
                MachineId = breakdown.MachineId,
                StoppingTime = new DateTime(
            DateTime.Today.Year,
            DateTime.Today.Month,
            DateTime.Today.Day,
            breakdown.StoppingTime.Hour,
            breakdown.StoppingTime.Minute,
            breakdown.StoppingTime.Second
             ),
                DurationStopping = breakdown.DurationStopping,
                ErrorCode = breakdown.ErrorCode,
                Description = breakdown.Description
            };

            await breackdownService.CreateBreakdown(item);
        }
            
        if(Edit == true)
        {
            var item = new BreackdownModel
            {
                Id = breakdown.BreakdownId,
                ReportId = breakdown.ReportId,
                MachineId = breakdown.MachineId,
                StoppingTime = new DateTime(
            DateTime.Today.Year,
            DateTime.Today.Month,
            DateTime.Today.Day,
            breakdown.StoppingTime.Hour,
            breakdown.StoppingTime.Minute,
            breakdown.StoppingTime.Second
             ),
                DurationStopping = breakdown.DurationStopping,
                ErrorCode = breakdown.ErrorCode,
                Description = breakdown.Description
            };
            await breackdownService.SetBreakdown(item);
        }


        // send the breakdown to parent
        if (OnSave.HasDelegate)
        await OnSave.InvokeAsync(breakdown);

        
        CloseModal();

        // reset local model
        breakdown = new BreackdownInfo();
    }
}
