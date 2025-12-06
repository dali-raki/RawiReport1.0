using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Reports;

public class ReportConsumptionModel
{
    public Guid Id { get; set; }
    public Guid ReportId { get; set; }
    public string MatierePremiere { get; set; }
    public string Supplier { get; set; }
    public string Quantity { get; set; }
    public string Loss { get; set; }
    public string Remark { get; set; }

}
