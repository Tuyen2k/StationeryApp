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

        public async Task<int> CountAll(SubCategoryFilterModel filter) {
            return await _repositories.CountAll(filter);
        }

        public async Task<SubCategoryModel> Create(SubCategoryRequest request, ClaimModel user)
        {
            var subCategoryCreate = new SubCategoryModel()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = request.Description,
                Name = request.Name,
                IsDeleted = false,
                CategoryId = request.CategoryId,

                CreatedByAccountId = user.UserId,
                CreatedByAccountName = user.UserName,
                CreatedByAccountEmail = user.Email,


            };

            return await _repositories.Create(subCategoryCreate);
        }

        public async Task<int> Delete(SubCategoryModel subCategory, ClaimModel user)
        {
            subCategory.IsDeleted = true;
            subCategory.DeletedAt = DateTime.UtcNow;

            subCategory.DeletedByAccountId = user.UserId;
            subCategory.DeletedByAccountName = user.UserName;
            subCategory.DeletedByAccountEmail = user.Email;

            return await _repositories.Delete(subCategory);
        }

        public async Task<List<SubCategoryModel>> GetAlls(SubCategoryFilterModel filter)
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

        public async Task<int> Update(SubCategoryModel subCategory ,SubCategoryRequest request, ClaimModel user)
        {
            subCategory.CategoryId = request.CategoryId;
            subCategory.Description = request.Description;
            subCategory.Name = request.Name;
            subCategory.UpdatedAt = DateTime.UtcNow;

            subCategory.UpdatedByAccountId = user.UserId;
            subCategory.UpdatedByAccountName = user.UserName;
            subCategory.UpdatedByAccountEmail = user.Email;

            return await _repositories.Update(subCategory);
        }
    }
}
