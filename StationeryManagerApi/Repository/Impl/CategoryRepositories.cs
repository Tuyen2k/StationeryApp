using Microsoft.EntityFrameworkCore;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly StationeryDBContext _context;

        public CategoryRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<CategoryModel> Create(CategoryModel category)
        {
            var result = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> Delete(CategoryModel category)
        {
            _context.Categories.Update(category);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<CategoryModel>> GetAlls(FilterModel filter)
        {
            var query = _context.Categories.AsQueryable();
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

        public async Task<CategoryModel?> GetById(Guid id)
        {
            var query = _context.Categories.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> Update(CategoryModel category)
        {
            _context.Categories.Update(category);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
