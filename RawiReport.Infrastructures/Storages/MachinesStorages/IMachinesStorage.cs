using RawiReport.Domains.Models.Machines;

namespace RawiReport.Infrastructures.Storages.MachinesStorages
{
    public interface IMachinesStorage
    {
        public ValueTask<List<MachineModel>> SelectMachines();
    }
}