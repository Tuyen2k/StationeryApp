using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class InventoryTransactionRepositories : IInventoryTransactionRepositories
    {
        private readonly StationeryDBContext _context;

        public InventoryTransactionRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<int> Count(InventoryTransactionFilterModel filter)
        {
            var query = _context.InventoryTransactions.AsQueryable();

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Code == filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Id) && Guid.TryParse(filter.Id, out Guid id))
            {
                query = query.Where(e => e.Id == id);
            }

            if (!string.IsNullOrEmpty(filter.TransactionType)
                && Enum.TryParse<TransactionTypeEnum>(filter.TransactionType, true, out TransactionTypeEnum type))
            {

                query = query.Where(e => e.TransactionType == type);
            }

            if (filter.FromDate != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromDate);
            }

            if (filter.ToDate != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToDate);
            }

            var count = await query.CountAsync();
            return count;

        }

        public async Task<InventoryTransactionModel> Create(InventoryTransactionModel inventory)
        {
            var result = await _context.InventoryTransactions.AddAsync(inventory);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> Delete(InventoryTransactionModel inventory)
        {
            _context.InventoryTransactions.Update(inventory);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter)
        {
            var query = _context.InventoryTransactions.AsQueryable();
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Code == filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Id) && Guid.TryParse(filter.Id, out Guid id))
            {
                query = query.Where(e => e.Id == id);
            }

            if (!string.IsNullOrEmpty(filter.TransactionType) 
                && Enum.TryParse<TransactionTypeEnum>(filter.TransactionType, true, out TransactionTypeEnum type))
            {
                
                query = query.Where(e => e.TransactionType == type);
            }

            if (filter.FromDate != null)
            {
                query = query.Where(e => e.CreatedAt >= filter.FromDate);
            }

            if (filter.ToDate != null)
            {
                query = query.Where(e => e.CreatedAt <= filter.ToDate);
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            query = query.Skip(skip).Take(limit);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<InventoryTransactionModel?> GetById(Guid id)
        {
            var query = _context.InventoryTransactions.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> Update(InventoryTransactionModel inventory)
        {
            _context.InventoryTransactions.Update(inventory);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
