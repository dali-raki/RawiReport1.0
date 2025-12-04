using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;
using RawiReport.Infrastructures.Storages.BreackdownStorages;
using RawiReport.Infrastructures.Storages.ReportsStorages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RawiReport.Implementations.Services.ReportsServices;

public class ReportsService(IReportStorages reportStorages, IBreackdownStorage breackdownStorage) : IReportsServices
{
    public async ValueTask<ReportInfo> GetReportById(Guid id)
    {
        try
        {
            //return await reportStorages.SelectById(id);
            return null;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async ValueTask<List<ReportHeaderModel>> GetAllReportHeader(ReportStatus status)
    {
        try
        {
            return await reportStorages.SelectAllReportHeader(status);
        }
        catch (Exception)
        {
            throw;
        }

    }



    public async ValueTask<int> CreateReportHeader(ReportHeaderModel model)
   {
        using var s = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        try
        {
            await reportStorages.InsertReportHeader(model);
            foreach (var breackdown in model.Breackdowns)
            {
                breackdown.ReportId = model.Id;
                breackdown.Id = Guid.NewGuid();
                await breackdownStorage.InsertBreackdown(breackdown);
            }
            s.Complete();
            return 1;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            s.Dispose();
        }
    }

    public ValueTask<int> SetReportHeader(ReportHeaderModel model)
    {
        try
        {
            return reportStorages.UpdateReportHeader(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ValueTask<int> RemoveReportHeader(Guid id)
    {
        try
        {
            return reportStorages.DeleteReportHeader(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
