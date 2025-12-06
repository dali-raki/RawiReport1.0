using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.ReportApps;

public class ReportStaticInfoModel
{
    public Guid ReportId { get; set; }
    public Guid LosseId { get; set; }
    public Guid ConsumptionId { get; set; }
    public string MatierePremiere { get; set; }
    public string Supplier { get; set; }
    public string Quantity { get; set; }
    public string Loss { get; set; }
    public string Remark { get; set; }

    public string Bottles { get; set; }
    public string PreformeSouffleuse { get; set; }
    public string PostformeSouffleuse { get; set; }
    public string Palettes { get; set; }
    public string TotalPalettes { get; set; }
    public string TotalFardeaux { get; set; }


    public List<ReportStaticInfoModel> RawMaterials { get; set; }
}
