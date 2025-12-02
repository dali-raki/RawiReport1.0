using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.BreackdownsApps;

public class BreackdownInfo
{
    public Guid BreakdownId { get; set; }
    public Guid ReportId { get; set; }
    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public DateTime StoppingTime { get; set; }
    public string DurationStopping { get; set; }
    public long ErrorCode { get; set; }
    public string Description { get; set; }
}
