using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class WarehouseRepositories : IWarehouseRepositories
    {
        private readonly StationeryDBContext _context;

        public WarehouseRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<WarehouseModel> Create(WarehouseModel warehouse)
        {
            var result = await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> Delete(WarehouseModel warehouse)
        {
            _context.Warehouses.Update(warehouse);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<WarehouseModel>> GetAlls(FilterModel filter)
        {
            var query = _context.Warehouses.AsQueryable();
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name.Contains(filter.Name));
            }

            query = query.Skip(skip).Take(limit);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<WarehouseModel?> GetById(Guid id)
        {
            var query = _context.Warehouses.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> Update(WarehouseModel warehouse)
        {
            _context.Warehouses.Update(warehouse);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
