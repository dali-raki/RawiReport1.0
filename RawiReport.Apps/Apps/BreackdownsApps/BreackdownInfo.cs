using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RawiReport.Apps.Apps.BreackdownsApps;

public class BreackdownInfo
{
    public Guid BreakdownId { get; set; }
    public Guid ReportId { get; set; }

    public int MachineId { get; set; }
   
    public string MachineName { get; set; }
    [Required(ErrorMessage = "Time is required")]
    public DateTime StoppingTime { get; set; }
    [Required(ErrorMessage = "Duration is required")]
    public string DurationStopping { get; set; }
    [Required(ErrorMessage = "Error Code is required")]
    public string ErrorCode { get; set; }
    public string Description { get; set; }
}
