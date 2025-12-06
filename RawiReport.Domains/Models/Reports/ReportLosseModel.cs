using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Domains.Models.Reports;

public class ReportLosseModel
{
    public Guid Id { get; set; }
    public Guid ReportId { get; set; }

    public string Bottles { get; set; }

    public string PreformeSouffleuse { get; set; }

    public string PostformeSouffleuse { get; set; }

    public string Palettes { get; set; }

    public string TotalPalettes { get; set; }

    public string TotalFardeaux { get; set; }

}
