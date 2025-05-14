using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;
using StationeryManagerLib.ResultDataDb;

namespace StationeryManagerApi.Repository.Impl
{
    public class InventoryItemRepositories : IInventoryItemRepositories
    {
        private readonly StationeryDBContext _context;

        public InventoryItemRepositories(StationeryDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductItemStock>> CalculateStockByProductIds(List<string> productIds)
        {
            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            query = query.Where(e => productIds.Contains(e.ProductId.ToString()));
            var resultQuery = query.GroupBy(e => e.ProductId)
                .Select(g => new ProductItemStock
                {
                    ProductId = g.Key,
                    Stock = g.Sum(e => e.Quantity),
                    ImportQuantity = g.Sum(e => e.InventoryType == TransactionTypeEnum.Import ? e.Quantity : 0),
                    ExportQuantity = g.Sum(e => e.InventoryType == TransactionTypeEnum.Export ? e.Quantity * (-1) : 0),
                });
            var list = await resultQuery.ToListAsync();
            return list;
        }

        public async Task<int> CreateListItemAsync(List<InventoryItemModel> inventoryItems)
        {
            await _context.InventoryItems.AddRangeAsync(inventoryItems);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
