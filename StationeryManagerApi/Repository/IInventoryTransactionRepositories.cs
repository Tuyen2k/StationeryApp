using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IInventoryTransactionRepositories
    {
        Task<InventoryTransactionModel?> GetById(Guid id);
        Task<List<InventoryTransactionModel>> GetAlls(FilterModel filter);
        Task<InventoryTransactionModel> Create(InventoryTransactionModel subCategory);
        Task<int> Update(InventoryTransactionModel subCategory);
        Task<int> Delete(InventoryTransactionModel subCategory);
    }
}
