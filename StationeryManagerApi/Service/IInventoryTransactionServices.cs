using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IInventoryTransactionServices
    {
        Task<InventoryTransactionModel?> GetById(Guid id);
        Task<List<InventoryTransactionModel>> GetAlls(FilterModel filter);
        Task<InventoryTransactionModel> Create(InventoryTransactionModel account);
        Task<int> Update(InventoryTransactionModel account);
        Task<int> Delete(InventoryTransactionModel account);
    }
}
