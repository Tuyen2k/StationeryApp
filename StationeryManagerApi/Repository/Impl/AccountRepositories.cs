using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly StationeryDBContext _context;

        public AccountRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<int> CountAll(FilterModel filter)
        {
            var query = _context.Accounts.AsQueryable();

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name.Contains(filter.Name));
            }

            var result = await query.CountAsync();
            return result;
        }

        public async Task<AccountModel> CreateAccount(AccountModel account)
        {
            var result = await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAccount(AccountModel account)
        {
            _context.Accounts.Update(account);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<AccountModel?> GetAccountByEmail(string email)
        {
            var result = await _context.Accounts.AsQueryable().Where(e => e.Email == email).FirstOrDefaultAsync();
            return result;
        }

        public async Task<AccountModel?> GetAccountById(Guid id)
        {
            var query = _context.Accounts.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var account = await query.FirstOrDefaultAsync();
            return account;
        }

        public async Task<List<AccountModel>> GetAllAccounts(FilterModel filter)
        {
            var query = _context.Accounts.AsQueryable();
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name.Contains(filter.Name));
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            query = query.Skip(skip).Take(limit);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<int> UpdateAccount(AccountModel account)
        {
            _context.Accounts.Update(account);
            var result = await _context.SaveChangesAsync();
            return result;
        }

    }
}
