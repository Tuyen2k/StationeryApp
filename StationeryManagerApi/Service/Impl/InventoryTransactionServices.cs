using System.Threading.Tasks;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class InventoryTransactionServices : IInventoryTransactionServices
    {
        private readonly IInventoryTransactionRepositories _repositories;
        private readonly IInventoryItemRepositories _inventoryItemRepositories;

        public InventoryTransactionServices(IInventoryTransactionRepositories repositories, IInventoryItemRepositories inventoryItemRepositories)
        {
            _repositories = repositories;
            _inventoryItemRepositories = inventoryItemRepositories;
        }

        public async Task<InventoryTransactionModel> Create(InventoryTransactionRequest request)
        {
            var type = Enum.Parse<TransactionTypeEnum>(request.TransactionType, true);
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

            return await _repositories.Create(inventory);
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

        public async Task<int> Update(InventoryTransactionModel inventory, InventoryTransactionRequest request)
        {
            var type = Enum.Parse<TransactionTypeEnum>(request.TransactionType, true);
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
