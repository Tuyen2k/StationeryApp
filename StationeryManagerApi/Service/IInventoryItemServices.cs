using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;
using StationeryManagerLib.ResultDataDb;

namespace StationeryManagerApi.Services
{
    public interface IInventoryItemServices
    {
        //Task<InventoryTransactionModel?> GetById(string id);
        //Task<List<InventoryTransactionModel>> GetAlls(InventoryItemFilterModel filter);
        //Task<InventoryTransactionModel> Create(InventoryItemRequest request);
        //Task<int> Update(InventoryTransactionModel inventory, InventoryItemRequest request);
        //Task<int> Delete(InventoryTransactionModel inventory);
        Task<int> CreateListItemAsync(List<InventoryItemModel> inventoryItems);
        Task<List<ProductItemStock>> CalculateStockByProductIds(List<string> productIds);
        Task<List<InventoryItemModel>> GetAlls(InventoryItemFilterModel filter);
        Task<int> CountAll(InventoryItemFilterModel filter);

        Task<List<ReportProductModel>> CalculateRepostProduct(List<ProductModel> products, FromToFilterModel time);
        Task<List<ReportProductModel>> CalculateRepostProduct(ReportFilterModel filter, string staffId = "");
        Task<int> CountRepostProduct(ReportFilterModel filter, string staffId = "");

        Task<List<ReportStaffModel>> CalculateRepostStaff(ReportFilterModel filter);
        Task<int> CountRepostStaff(ReportFilterModel filter);
    }
}
