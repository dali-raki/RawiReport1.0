using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Breackdowns;

public class BreackdownModel
{
    public Guid BreackdownId { get; set; }
    public Guid ReportId { get; set; }
    public int MachineId { get; set; }
    public DateTime StoppingTime { get; set; }
    public string DurationStopping { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}
