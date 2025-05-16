using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface ICategoryServices
    {
        Task<CategoryModel?> GetById(string id);
        Task<List<CategoryModel>> GetAlls(FilterModel filter);
        Task<CategoryModel> Create(CategoryRequest category, ClaimModel user);
        Task<int> Update(CategoryModel category, CategoryRequest request, ClaimModel user);
        Task<int> Delete(CategoryModel category, ClaimModel user);
        Task<int> CountAll(FilterModel filter);
    }
}
