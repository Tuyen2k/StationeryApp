using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IInventoryTransactionServices
    {
        Task<InventoryTransactionModel?> GetById(string id);
        Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter);
        Task<InventoryTransactionModel> Create(InventoryTransactionRequest request, List<ProductModel> products);
        Task<int> Update(InventoryTransactionModel inventory, InventoryTransactionRequest request);
        Task<int> Delete(InventoryTransactionModel inventory);
    }
}
