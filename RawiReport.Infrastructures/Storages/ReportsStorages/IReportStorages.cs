using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;

namespace RawiReport.Infrastructures.Storages.ReportsStorages
{
    public interface IReportStorages
    {
        ValueTask<ReportInfo> SelectById(Guid id);
        ValueTask<List<ReportHeaderModel>> SelectAllReportHeader(ReportStatus status);

        ValueTask<int> InsertReportHeader(ReportHeaderModel model);

        ValueTask<int> UpdateReportHeader(ReportHeaderModel model);

        ValueTask<int> DeleteReportHeader(Guid id);


        // the next fuctions used just in this time to insert static data of report

        ValueTask<int> InsertConsumption(ReportConsumptionModel model);
        ValueTask<int> InsertLosses(ReportLosseModel model);

        ValueTask<int> UpdateReportState(Guid reportId, ReportStatus newState);
    }
}