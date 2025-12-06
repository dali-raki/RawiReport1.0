using RawiReport.Domains.Models.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.ReportApps;

public interface  IReportsServices
{
    ValueTask<ReportInfo> GetReportById(Guid id);
    ValueTask<List<ReportHeaderModel>> GetAllReportHeader(ReportStatus status);
    ValueTask<int> CreateReportHeader(ReportHeaderModel model);
    ValueTask<int> SetReportHeader(ReportHeaderModel model);
    ValueTask<int> RemoveReportHeader(Guid id);




    // the next fuctions used just in this time to insert static data of report
    ValueTask<int> CreateConsumption(ReportConsumptionModel model);
    ValueTask<int> CreateLosses(ReportLosseModel model);
    ValueTask<int> ChangeReportState(Guid reportId, ReportStatus newState);
}
