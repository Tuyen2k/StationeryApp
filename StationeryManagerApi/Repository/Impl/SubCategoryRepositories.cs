using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class SubCategoryRepositories : ISubCategoryRepositories
    {
        private readonly StationeryDBContext _context;

        public SubCategoryRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<SubCategoryModel> Create(SubCategoryModel subCategory)
        {
            var result = await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> Delete(SubCategoryModel SubCategory)
        {
            _context.SubCategories.Update(SubCategory);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<SubCategoryModel>> GetAlls(FilterModel filter)
        {
            var query = _context.SubCategories.AsQueryable();
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

        public async Task<SubCategoryModel?> GetById(Guid id)
        {
            var query = _context.SubCategories.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> Update(SubCategoryModel SubCategory)
        {
            _context.SubCategories.Update(SubCategory);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
