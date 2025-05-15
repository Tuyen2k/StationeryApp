using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IInventoryTransactionServices
    {
        public Task<List<ProductStockModel>> GetAllAsync(InventoryTransactionFilterModel filter);
        public Task<bool> CreateAsync(InventoryTransactionRequest request);
        public Task<bool> DeleteAsync(string id);
        public Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter);
        public Task<InventoryTransactionModel?> GetById(string id);
        public Task<bool> UpdateAsync(string id, InventoryTransactionRequest request);

        public Task<List<HistoryProductInTransaction>> GetHistoryByProductId(string productId,InventoryTransactionFilterModel filter);
    }
}
