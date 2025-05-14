using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IWarehouseServices
    {
        Task<List<WarehouseModel>> GetAllAsync(FilterModel filter);
        Task<WarehouseModel?> GetByIdAsync(string id);
    }
}
