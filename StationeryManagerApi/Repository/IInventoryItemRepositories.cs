using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;
using StationeryManagerLib.ResultDataDb;

namespace StationeryManagerApi.Repository
{
    public interface IInventoryItemRepositories
    {
        //Task<InventoryItemModel?> GetById(Guid id);
        //Task<List<InventoryItemModel>> GetAlls(InventoryItemFilterModel filter);
        //Task<InventoryItemModel> Create(InventoryItemModel inventory);
        //Task<int> Update(InventoryItemModel inventory);
        //Task<int> Delete(InventoryItemModel inventory);
        //Task<int> Count(InventoryItemFilterModel filter);
        Task<int> CreateListItemAsync(List<InventoryItemModel> inventoryItems);
        Task<List<ProductItemStock>> CalculateStockByProductIds(List<string> productIds);
        Task<List<InventoryItemModel>> GetAlls(InventoryItemFilterModel filter);
        Task<List<InventoryItemModel>> GetAlls(List<string> productIds, FromToFilterModel time);
        Task<int> CountAll(InventoryItemFilterModel filter);
    }
}
