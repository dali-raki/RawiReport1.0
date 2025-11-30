using RawiReport.Domains.Models.Machines;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.MachinesApps;

public interface IMachinesServices
{
    public ValueTask<List<MachineModel>> GetMachines();
}
