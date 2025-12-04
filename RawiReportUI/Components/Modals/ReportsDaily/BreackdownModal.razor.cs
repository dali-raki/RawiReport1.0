using Microsoft.AspNetCore.Components;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Machines;
using System;
using System.Linq;

namespace RawiReportUI.Components.Modals.ReportsDaily;

public partial class BreackdownModal
{
    // incoming list of machines (note: name 'machines' used by Razor markup)
    [Parameter] public List<MachineModel>? Machines { get; set; }

    // notify parent when a breakdown is saved
    [Parameter] public EventCallback<BreackdownModel> OnSave { get; set; }

    private bool isModalOpen = false;

    private BreackdownModel breakdown = new();

    // open modal; if an existing model is provided we'll edit it (copy to avoid two-way issues)
    public void OpenModal(BreackdownModel? model = null)
    {
        if (model is null)
        {
            breakdown = new BreackdownModel();
        }
        else
        {
            breakdown = new BreackdownModel
            {
                Id = model.Id,
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
        // ensure id
        if (breakdown.Id == Guid.Empty)
            breakdown.Id = Guid.NewGuid();

        // send the breakdown to parent
        if (OnSave.HasDelegate)
            await OnSave.InvokeAsync(breakdown);

        CloseModal();

        // reset local model
        breakdown = new BreackdownModel();
    }
}
