using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;

namespace RawiReport.Infrastructures.Storages.ReportsStorages
{
    public interface IReportStorages
    {
        ValueTask<ReportInfo> SelectById(Guid id);
        ValueTask<List<ReportHeaderModel>> SelectAllReportHeader();

        ValueTask<int> InsertReportHeader(ReportHeaderModel model);

        ValueTask<int> UpdateReportHeader(ReportHeaderModel model);

        ValueTask<int> DeleteReportHeader(Guid id);
    }
}