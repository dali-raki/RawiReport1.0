using RawiReport.Domains.Models.Breackdowns;

namespace RawiReport.Infrastructures.Storages.BreackdownStorages;

public interface IBreackdownStorage
{
    ValueTask<bool> InsertBreackdown(BreackdownModel model);
    ValueTask<int> UpdateBreakdown(BreackdownModel model);
    ValueTask<int> DeleteBreakdown(Guid id);
}