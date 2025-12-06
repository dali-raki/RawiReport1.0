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
            return await reportStorages.SelectById(id);
           
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
        try
        {
            return await reportStorages.InsertReportHeader(model);
          
        }
        catch (Exception)
        {
            throw;
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



    // the next fuctions used just in this time to insert static data of report

    public async ValueTask<int> CreateConsumption(ReportConsumptionModel model)
    {
         try
        {
            return await reportStorages.InsertConsumption(model);
        }
        catch (Exception)
        {
            throw;
        }

    }


    public async ValueTask<int> CreateLosses(ReportLosseModel model)
    {
        try
        {
            return await reportStorages.InsertLosses(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async ValueTask<int> ChangeReportState(Guid reportId, ReportStatus newState)
    {
        try
        {
            return await reportStorages.UpdateReportState(reportId, newState);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
