using RawiReport.Domains.Models.Breackdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Reports;

public class ReportHeaderModel
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
    public Guid CreateBy { get; set; }
    public DateTime Updatlast {get; set;}
    public ReportStatus ReportStatus { get; set;}
    public List<BreackdownModel> Breackdowns { get; set; }=new();

}