using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface ICategoryServices
    {
        Task<List<CategoryModel>> GetAllAsync(FilterModel? filter);
        Task<int> CountAllAsync(FilterModel? filter);
        Task<CategoryModel?> GetByIdAsync(string id);
        Task<bool> CreateAsync(CategoryRequest category);
        Task<bool> UpdateAsync(string id, CategoryRequest category);
        Task<bool> DeleteAsync(string id);
    }
}
