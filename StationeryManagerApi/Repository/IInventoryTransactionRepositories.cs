using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IInventoryTransactionRepositories
    {
        Task<InventoryTransactionModel?> GetById(Guid id);
        Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter);
        Task<List<InventoryTransactionModel>> GetAllByIds(List<string> ids);
        Task<InventoryTransactionModel> Create(InventoryTransactionModel inventory);
        Task<int> Update(InventoryTransactionModel inventory);
        Task<int> Delete(InventoryTransactionModel inventory);
        Task<int> Count(InventoryTransactionFilterModel filter);

        
    }
}
