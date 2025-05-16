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

        public async Task<int> CountAll(InventoryItemFilterModel filter)
        {
            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.ProductId))
            {
                query = query.Where(e => e.ProductId == filter.ProductId);
            }
            if (!string.IsNullOrEmpty(filter.InventoryTransactionId))
            {
                query = query.Where(e => e.InventoryTransactionId == filter.InventoryTransactionId);
            }
            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(e => e.ProductName.Contains(filter.ProductName));
            }

            if (!string.IsNullOrEmpty(filter.ProductSku))
            {
                query = query.Where(e => e.ProductSku == filter.ProductSku);
            }


            var result = await query.CountAsync();
            return result;

        }

        public async Task<List<InventoryItemModel>> GetAlls(InventoryItemFilterModel filter)
        {
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.ProductId))
            {
                query = query.Where(e => e.ProductId == filter.ProductId);
            }
            if (!string.IsNullOrEmpty(filter.InventoryTransactionId))
            {
                query = query.Where(e => e.InventoryTransactionId == filter.InventoryTransactionId);
            }
            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(e => e.ProductName.Contains(filter.ProductName));
            }

            if (!string.IsNullOrEmpty(filter.ProductSku))
            {
                query = query.Where(e => e.ProductSku == filter.ProductSku);
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            query = query.Skip(skip).Take(limit);

            var result = await query.ToListAsync();
            return result;

        }

        public async Task<List<InventoryItemModel>> GetAlls(List<string> productIds, FromToFilterModel time)
        {
            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            query = query.Where(e => productIds.Contains(e.ProductId));
            if (time.FromTime != null)
            {
                query = query.Where(e => e.CreatedAt >= time.FromTime);
            }
            if (time.ToTime != null)
            {
                query = query.Where(e => e.CreatedAt <= time.ToTime);
            }
            var result = await query.ToListAsync();
            return result;
        }
    }
}
