using RawiReport.Domains.Models.Breackdowns;

namespace RawiReport.Infrastructures.Storages.BreackdownStorages;

public interface IBreackdownStorage
{
    public ValueTask<bool> InsertBreackdown(BreackdownModel model);
}