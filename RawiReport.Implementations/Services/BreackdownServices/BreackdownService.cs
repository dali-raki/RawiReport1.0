using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Infrastructures.Storages.BreackdownStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Implementations.Services.BreackdownServices;

public class BreackdownService(IBreackdownStorage breackdownStorage) : IBreackdownService
{

    public async ValueTask<bool> SetBreackdown(BreackdownModel model)
    {
         try
        {
            return await breackdownStorage.InsertBreackdown(model);
        }
        catch (Exception)
        {
            throw;
        }

    }


    public async ValueTask<int> SetBreakdown(BreackdownModel model)
    {
        try
        {
            return await breackdownStorage.UpdateBreakdown(model);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async ValueTask<int> RemoveBreakdown(Guid id)
    {
        try
        {
            return await breackdownStorage.DeleteBreakdown(id);
        }
        catch (Exception)
        {
            throw;

        }
    }
}
