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

    private bool isModalOpen = false;

    public void OpenModal() => isModalOpen = true;
    public void CloseModal() => isModalOpen = false;

    private BreackdownModel breakdown = new();


    private async Task SaveBreakdown()
    {
    
        CloseModal();

        await Task.CompletedTask;
    }
}
