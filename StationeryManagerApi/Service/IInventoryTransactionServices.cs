using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IInventoryTransactionServices
    {
        Task<InventoryTransactionModel?> GetById(string id);
        Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter);
        Task<InventoryTransactionModel> Create(InventoryTransactionRequest request, List<ProductModel> products, ClaimModel user);
        Task<int> Update(InventoryTransactionModel inventory, InventoryTransactionRequest request, ClaimModel user);
        Task<int> Delete(InventoryTransactionModel inventory, ClaimModel user);
        Task<List<HistoryProductInTransaction>> GetHistoryByProductId(InventoryTransactionFilterModel filter);
    }
}
