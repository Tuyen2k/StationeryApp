using System.Threading.Tasks;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Dtos;
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

        public async Task<List<ReportProductModel>> CalculateRepostProduct(List<ProductModel> products, FromToFilterModel time)
        {
            var productIds = products.Select(p => p.Id.ToString()).ToList();
            var items = await _inventoryItemRepositories.GetAlls(productIds, time);
            var result = from item in items
                         join product in products on item.ProductId equals product.Id.ToString()
                         group new { item, product } by item.ProductId into g
                         select new ReportProductModel
                         {
                             Id = g.Key,
                             Name = g.FirstOrDefault().product.Name,
                             Sku = g.FirstOrDefault().product.Sku,
                             ImageUrl = g.FirstOrDefault().product.ImageUrl,
                             TotalImport = g.Sum(e => (e.item.InventoryType == TransactionTypeEnum.Import ? e.item.Quantity : 0) * e.item.Price), 
                             TotalExport = g.Sum(e => (e.item.InventoryType == TransactionTypeEnum.Export ? e.item.Quantity * (-1) : 0) * e.item.Price),
                             Profit = g.Sum(e =>
                                 e.item.InventoryType == TransactionTypeEnum.Export
                                     ? (e.item.Price - e.product.Price) * (e.item.Quantity * -1)
                                     : 0)
                         };

            return result.ToList();
        }

        public async Task<List<ProductItemStock>> CalculateStockByProductIds(List<string> productIds)
        {
            return await _inventoryItemRepositories.CalculateStockByProductIds(productIds);
        }

        public async Task<int> CountAll(InventoryItemFilterModel filter)
        {
            return await _inventoryItemRepositories.CountAll(filter);
        }

        public async Task<int> CreateListItemAsync(List<InventoryItemModel> inventoryItems)
        {
           return await _inventoryItemRepositories.CreateListItemAsync(inventoryItems);
        }

        public async Task<List<InventoryItemModel>> GetAlls(InventoryItemFilterModel filter)
        {
            var result = await _inventoryItemRepositories.GetAlls(filter);
            return result;
        }
    }
}
