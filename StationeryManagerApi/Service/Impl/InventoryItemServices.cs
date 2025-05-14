using System.Threading.Tasks;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;
using StationeryManagerLib.ResultDataDb;

namespace StationeryManagerApi.Service.Impl
{
    public class InventoryItemServices : IInventoryItemServices
    {
        private readonly IInventoryTransactionRepositories _repositories;
        private readonly IInventoryItemRepositories _inventoryItemRepositories;

        public InventoryItemServices(IInventoryTransactionRepositories repositories, IInventoryItemRepositories inventoryItemRepositories)
        {
            _repositories = repositories;
            _inventoryItemRepositories = inventoryItemRepositories;
        }

        public async Task<List<ProductItemStock>> CalculateStockByProductIds(List<string> productIds)
        {
            return await _inventoryItemRepositories.CalculateStockByProductIds(productIds);
        }

        public async Task<int> CreateListItemAsync(List<InventoryItemModel> inventoryItems)
        {
           return await _inventoryItemRepositories.CreateListItemAsync(inventoryItems);
        }
    }
}
