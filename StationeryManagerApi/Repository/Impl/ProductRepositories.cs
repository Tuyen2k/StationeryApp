using Microsoft.EntityFrameworkCore;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly StationeryDBContext _context;

        public ProductRepositories(StationeryDBContext context) {
            _context = context;
        }

        public async Task<int> CountAll(ProductFilterModel filter)
        {
            var query = _context.Products.AsQueryable();

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.SubCategoryId))
            {
                query = query.Where(e => e.SubCategoryId == filter.SubCategoryId);
            }

            var result = await query.CountAsync();
            return result;
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> Delete(ProductModel product)
        {
            _context.Products.Update(product);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<ProductModel>> GetAllByIds(List<string> ids)
        {
            var query = _context.Products.AsQueryable();

            query = query.Where(e => e.IsDeleted != true);

            query = query.Where(e => ids.Contains(e.Id.ToString()));

            query = query.OrderByDescending(e => e.CreatedAt);

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<List<ProductModel>> GetAlls(ProductFilterModel filter)
        {
            var query = _context.Products.AsQueryable();
            int limit = filter.Limit ?? 10;
            int skip = (filter.Page ?? 0) * limit;

            query = query.Where(e => e.IsDeleted != true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(e => e.Name.Contains(filter.Name));
            }
            if(!string.IsNullOrEmpty(filter.SubCategoryId))
            {
                query = query.Where(e => e.SubCategoryId == filter.SubCategoryId);
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            query = query.Skip(skip).Take(limit);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<ProductModel?> GetById(Guid id)
        {
            var query = _context.Products.AsQueryable().Where(e => e.Id == id);
            query = query.Where(e => e.IsDeleted != true);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> Update(ProductModel product)
        {
            _context.Products.Update(product);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
