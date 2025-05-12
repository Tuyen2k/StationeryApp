using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IWarehouseRepositories
    {
        Task<WarehouseModel?> GetById(Guid id);
        Task<List<WarehouseModel>> GetAlls(FilterModel filter);
        Task<WarehouseModel> Create(WarehouseModel warehouse);
        Task<int> Update(WarehouseModel warehouse);
        Task<int> Delete(WarehouseModel warehouse);
    }
}
