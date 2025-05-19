using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Dtos;
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

        public async Task<List<ReportProductModel>> CalculateRepostProduct(ReportFilterModel filter, string staffId = "")
        {
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.ProductName.Contains(filter.Name));
            }
            if (filter.FromTime != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromTime);
            }
            if (filter.ToTime != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToTime);
            }

            if(!string.IsNullOrEmpty(staffId))
            {
                query = query.Where(e => e.CreatedByAccountId == staffId).Where(e => e.InventoryType == TransactionTypeEnum.Export);
            }

            var items = await query.ToListAsync();
            var productIds = items.Select(e => e.ProductId).Distinct().ToList();

            var products = await _context.Products
                .Where(e => productIds.Contains(e.Id.ToString()))
                .ToListAsync();


            var result = items.GroupBy(e => e.ProductId)
                .Join(products,
                g => g.Key,
                p => p.Id.ToString(),
                (g, p) => new ReportProductModel
                {
                    Id = g.Key,
                    Name = p.Name,
                    Sku = p.Sku,
                    ImageUrl = p.ImageUrl,
                    QuantityImport = g.Sum(e => e.InventoryType == TransactionTypeEnum.Import ? e.Quantity : 0),
                    QuantityExport = g.Sum(e => Math.Abs(e.InventoryType == TransactionTypeEnum.Export ? e.Quantity : 0)),
                    TotalImport = g.Sum(e => (e.InventoryType == TransactionTypeEnum.Import ? e.Quantity : 0) * e.Price),
                    TotalExport = g.Sum(e => (e.InventoryType == TransactionTypeEnum.Export ? e.Quantity * (-1) : 0) * e.Price),
                    Profit = g.Sum(e =>
                        e.InventoryType == TransactionTypeEnum.Export
                            ? (e.Price - p.Price) * (e.Quantity * -1)
                            : 0)
                });

            var list = result.Skip(skip).Take(limit).ToList();
            return list;
        }

        public async Task<int> CountRepostProduct(ReportFilterModel filter, string staffId = "")
        {
            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.ProductName.Contains(filter.Name));
            }
            if (filter.FromTime != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromTime);
            }
            if (filter.ToTime != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToTime);
            }

            if (!string.IsNullOrEmpty(staffId))
            {
                query = query.Where(e => e.CreatedByAccountId == staffId);
            }

            var items = await query.ToListAsync();
            var productIds = items.Where(e => e.InventoryType == TransactionTypeEnum.Export).Select(e => e.ProductId).Distinct().ToList();
            return productIds.Count();
        }

        public async Task<List<ReportStaffModel>> CalculateRepostStaff(ReportFilterModel filter)
        {
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => !string.IsNullOrEmpty(e.CreatedByAccountName) && e.CreatedByAccountName!.Contains(filter.Name));
            }
            if (filter.FromTime != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromTime);
            }
            if (filter.ToTime != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToTime);
            }

            query = query.Where(e => e.InventoryType == TransactionTypeEnum.Export);

            var items = await query.ToListAsync();
            var productIds = items.Select(e => e.ProductId).Distinct().ToList();
            var accountIds = items.Select(e => e.CreatedByAccountId).Distinct().ToList();

            var products = await _context.Products
                .Where(e => productIds.Contains(e.Id.ToString()))
                .ToListAsync();

            var accounts = await _context.Accounts
                .Where(e => accountIds.Contains(e.Id.ToString()))
                .ToListAsync();

            var result = items.GroupBy(e => e.CreatedByAccountId)
                .Join(accounts,
                g => g.Key,
                acc => acc.Id.ToString(),
                (g, acc) =>
                {
                    var exportItems = g.ToList();

                    var profit = exportItems.Sum(e =>
                    {
                        var product = products.FirstOrDefault(p => p.Id.ToString() == e.ProductId);
                        return product != null ? (e.Price - product.Price) * (-1 * e.Quantity) : 0;
                    });

                    return new ReportStaffModel
                    {
                        Id = g.Key ?? "",
                        Email = acc.Email,
                        Name = acc.Name,
                        Phone = acc.Phone ?? "",
                        ImageUrl = "",
                        QuantitySale = Math.Abs(g.Sum(e => e.Quantity)),
                        Revenue = Math.Abs(g.Sum(e =>  e.Quantity * e.Price)),
                        Profit = profit
                    };
                });

            var list = result.Skip(skip).Take(limit).ToList();
            return list;
        }

        public async Task<int> CountRepostStaff(ReportFilterModel filter)
        {
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            var query = _context.InventoryItems.AsQueryable();
            query = query.Where(e => e.IsDeleted != true);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => string.IsNullOrEmpty(e.CreatedByAccountName) && e.CreatedByAccountName!.Contains(filter.Name));
            }
            if (filter.FromTime != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromTime);
            }
            if (filter.ToTime != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToTime);
            }

            query = query.Where(e => e.InventoryType == TransactionTypeEnum.Export);

            var items = await query.ToListAsync();
            var accountIds = items.Select(e => e.CreatedByAccountId).Distinct().ToList();

            var accounts = await _context.Accounts
                .Where(e => accountIds.Contains(e.Id.ToString())).ToListAsync();

            return accounts.Count();
        }
    }
}
