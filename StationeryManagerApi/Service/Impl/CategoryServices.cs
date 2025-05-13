using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepositories _repositories;

        public CategoryServices(ICategoryRepositories repositories) {
            _repositories = repositories;
        }

        public async Task<int> CountAll(FilterModel filter)
        {
            return await _repositories.CountAll(filter);
        }

        public async Task<CategoryModel> Create(CategoryRequest category)
        {
            var categoryCreate = new CategoryModel()
            {
                CreatedAt = DateTime.UtcNow,
                Description = category.Description,
                Name = category.Name,
                IsDeleted = false,
            };
            var result = await _repositories.Create(categoryCreate);
            return result;
        }

        public async Task<int> Delete(CategoryModel category)
        {
            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(category);
        }

        public async Task<List<CategoryModel>> GetAlls(FilterModel filter)
        {
            var list = await _repositories.GetAlls(filter);
            return list;
        }

        public async Task<CategoryModel?> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return null;
            }
            return await _repositories.GetById(guidId);
        }

        public async Task<int> Update(CategoryModel category, CategoryRequest request)
        {
            category.Description = request.Description;
            category.Name = request.Name;
            category.UpdatedAt = DateTime.UtcNow;

            return await _repositories.Update(category);
        }
    }
}
