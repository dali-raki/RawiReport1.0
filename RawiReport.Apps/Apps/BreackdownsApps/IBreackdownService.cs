using RawiReport.Domains.Models.Breackdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawiReport.Apps.Apps.BreackdownsApps;

public interface IBreackdownService
{
    ValueTask<bool> CreateBreakdown(BreackdownModel model);
    ValueTask<int> SetBreakdown(BreackdownModel model);
    ValueTask<int> RemoveBreakdown(Guid id);
}
