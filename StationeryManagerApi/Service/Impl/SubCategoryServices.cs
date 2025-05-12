using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class SubCategoryServices : ISubCategoryServices
    {
        private readonly ISubCategoryRepositories _repositories;

        public SubCategoryServices(ISubCategoryRepositories repositories) {
            _repositories = repositories;
        }

        public async Task<SubCategoryModel> Create(SubCategoryRequest request)
        {
            var subCategoryCreate = new SubCategoryModel()
            {
                CreatedAt = DateTime.UtcNow,
                Description = request.Description,
                Name = request.Name,
                IsDeleted = false,
                CategoryId = request.CategoryId
            };

            return await _repositories.Create(subCategoryCreate);
        }

        public async Task<int> Delete(SubCategoryModel subCategory)
        {
            subCategory.IsDeleted = true;
            subCategory.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(subCategory);
        }

        public async Task<List<SubCategoryModel>> GetAlls(FilterModel filter)
        {
            var list = await _repositories.GetAlls(filter);
            return list;
        }

        public async Task<SubCategoryModel?> GetById(string id)
        {
            if(!Guid.TryParse(id, out Guid guidId))
            {
                return null;
            }
            return await _repositories.GetById(guidId);
        }

        public async Task<int> Update(SubCategoryModel subCategory ,SubCategoryRequest request)
        {
            subCategory.CategoryId = request.CategoryId;
            subCategory.Description = request.Description;
            subCategory.Name = request.Name;
            subCategory.UpdatedAt = DateTime.UtcNow;
            return await _repositories.Update(subCategory);
        }
    }
}
