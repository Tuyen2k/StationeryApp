using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IWarehouseServices
    {
        Task<WarehouseModel?> GetById(string id);
        Task<List<WarehouseModel>> GetAlls(FilterModel filter);
        Task<WarehouseModel> Create(WarehouseRequest request, ClaimModel user);
        Task<int> Update(WarehouseModel warehouse, WarehouseRequest request, ClaimModel user);
        Task<int> Delete(WarehouseModel warehouse, ClaimModel user);
    }
}
