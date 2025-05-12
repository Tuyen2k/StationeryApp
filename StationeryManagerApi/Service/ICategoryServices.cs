using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface ICategoryServices
    {
        Task<CategoryModel?> GetById(string id);
        Task<List<CategoryModel>> GetAlls(FilterModel filter);
        Task<CategoryModel> Create(CategoryRequest category);
        Task<int> Update(CategoryModel category, CategoryRequest request);
        Task<int> Delete(CategoryModel category);
    }
}
