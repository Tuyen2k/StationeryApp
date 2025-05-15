using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IInventoryItemServices
    {
        public Task<List<InventoryItemModel>> GetAllByTransactionIdAsync(string transactionId);
        public Task<int> CountAllAsync(InventoryItemFilterModel filter); 
    }
}
