using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Reports;

public class ReportModel
{
    public Guid ReportId { get; set; }

    public Guid BreackdownId { get; set; }
    public DateOnly Date { get; set; }

    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }

    public string Leader { get; set; }
    
    public string Format { get; set; }

    public string Objective { get; set; }

    public string Speed { get; set; }
    }
