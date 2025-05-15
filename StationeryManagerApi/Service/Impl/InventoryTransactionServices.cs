using System.Threading.Tasks;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class InventoryTransactionServices : IInventoryTransactionServices
    {
        private readonly IInventoryTransactionRepositories _repositories;
        private readonly IInventoryItemServices _inventoryItemServices;

        public InventoryTransactionServices(IInventoryTransactionRepositories repositories, IInventoryItemServices inventoryItemServices)
        {
            _repositories = repositories;
            _inventoryItemServices = inventoryItemServices;
        }

        public async Task<InventoryTransactionModel> Create(InventoryTransactionRequest request, List<ProductModel> products)
        {
            var type = request.TransactionType;
            var code = await GenerateInventoryCode(type);
            
            var inventory = new InventoryTransactionModel
            {
                Code = code,
                TransactionType = type,
                WarehouseId = request.WarehouseId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                Note = request.Note,
            };

            var result = await _repositories.Create(inventory);

            var items = request.Items.Select(e => new InventoryItemModel
            {
                ProductId = e.ProductId,
                Quantity = type == TransactionTypeEnum.Import ? e.Quantity : e.Quantity * (-1),
                Price = e.Price,
                ProductName = products.FirstOrDefault(p => p.Id.ToString() == e.ProductId)?.Name ?? string.Empty,
                ProductSku = products.FirstOrDefault(p => p.Id.ToString() == e.ProductId)?.Sku ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                InventoryTransactionId = result.Id.ToString(),
                InventoryType = type,
            }).ToList();

            await _inventoryItemServices.CreateListItemAsync(items);

            return result;
        }

        public async Task<int> Delete(InventoryTransactionModel inventory)
        {
            inventory.IsDeleted = true;
            inventory.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(inventory);
        }

        public async Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter)
        {
            return await _repositories.GetAlls(filter);
        }

        public async Task<InventoryTransactionModel?> GetById(string id)
        {
            if(Guid.TryParse(id, out Guid guid))
            {
                return await _repositories.GetById(guid);
            }
            return null;
        }

        public async Task<List<HistoryProductInTransaction>> GetHistoryByProductId(InventoryTransactionFilterModel filter)
        {
            var items = await _inventoryItemServices.GetAlls(new InventoryItemFilterModel()
            {
                ProductId = filter.ProductId,
                Limit = filter.Limit,
                Page = filter.Page,
            });

            if (items == null || items.Count == 0)
            {
                return [];
            }

            var inventoryTransactionIds = items.Select(e => e.InventoryTransactionId).Distinct().ToList();
            var inventories = await _repositories.GetAllByIds(inventoryTransactionIds);

            var result = from i in inventories
                         join item in items on i.Id.ToString() equals item.InventoryTransactionId
                         select new HistoryProductInTransaction()
                         {
                             Id = i.Id,
                             Code = i.Code,
                             TransactionType = i.TransactionType,
                             CreatedAt = i.CreatedAt,
                             Note = i.Note,
                             DeletedAt = i.DeletedAt,
                             WarehouseId = i.WarehouseId,
                             IsDeleted = i.IsDeleted,
                             ProductId = item.ProductId,
                             UpdatedAt = i.UpdatedAt,
                             Quantity = item.Quantity,
                             Price = item.Price,
                             ProductName = item.ProductName,
                             ProductSku = item.ProductSku,
                         };
            return result.ToList();
        }

        public async Task<int> Update(InventoryTransactionModel inventory, InventoryTransactionRequest request)
        {
            var type = request.TransactionType;
            inventory.WarehouseId = request.WarehouseId;
            inventory.TransactionType = type;
            inventory.UpdatedAt = DateTime.UtcNow;
            inventory.Note = request.Note;

            return await _repositories.Update(inventory);
        }

        private async Task<string> GenerateInventoryCode(TransactionTypeEnum type)
        {
            var fromDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0,0,0);
            var toDate = fromDate.AddDays(1);
            var count = await _repositories.Count(
                new InventoryTransactionFilterModel() { FromDate = fromDate, ToDate = toDate });
            var code = type switch
            {
                TransactionTypeEnum.Import => $"IMP {fromDate.ToString("yyyyMMdd")} { count:D4}",
                _ => $"EXP {fromDate.ToString("yyyyMMdd")} {count:D4}"
            };
            return code;
        }
    }
}
