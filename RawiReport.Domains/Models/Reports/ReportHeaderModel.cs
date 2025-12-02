using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Reports;

public class ReportHeaderModel
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Guid ProductId { get; set; }
    public string Objective { get; set; }
    public int Speed { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreateBy { get; set; }
    public DateTime Updatlast {get; set;}
    public ReportStatus ReportStatus { get; set;}
}