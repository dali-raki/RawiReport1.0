using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.ReportApps;

public class ReportInfo
{
    public Guid Id { get; set; }
    public string Leader { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string ProductId { get; set; }
    public string Objective { get; set; }
    public int Speed { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime Updatedlast { get; set; }
    public ReportStatus reportStatus { get; set; } 
    public List<BreackdownInfo>? BreackdownList { get; set; } = new();

}
