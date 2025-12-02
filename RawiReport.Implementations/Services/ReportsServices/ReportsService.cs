using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Reports;
using RawiReport.Infrastructures.Storages.ReportsStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Implementations.Services.ReportsServices;

public class ReportsService (IReportStorages reportStorages) : IReportsServices
{
    public async ValueTask<ReportInfo> GetReportById(Guid id)
    {
        try
        {
           return await reportStorages.SelectById(id);
        }
        catch(Exception) 
        { 
            throw; 
        }
        
    }

    public async ValueTask<List<ReportHeaderModel>> GetAllReportHeader()
    {
         try
        {
            return await reportStorages.SelectAllReportHeader();
        }
        catch (Exception)
        {
            throw;
        }

    }



    public ValueTask<int> CreateReportHeader(ReportHeaderModel model)
    {
        try
        {
            return reportStorages.InsertReportHeader(model);
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
}
