using RawiReport.Apps.Apps.MachinesApps;
using RawiReport.Domains.Models.Machines;
using RawiReport.Infrastructures.Storages.MachinesStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Implementations.Services.MachinesServices;

public class MachinesService(IMachinesStorage machinesStorage): IMachinesServices
{

    public async ValueTask<List<MachineModel>> GetMachines()
    {
        try
        {
        
            return await machinesStorage.SelectMachines();

        }
        catch (Exception)
        {
            throw;
        }
     
    }
}
