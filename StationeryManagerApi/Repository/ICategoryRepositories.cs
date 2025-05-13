using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface ICategoryRepositories
    {
        Task<CategoryModel?> GetById(Guid id);
        Task<List<CategoryModel>> GetAlls(FilterModel filter);
        Task<CategoryModel> Create(CategoryModel category);
        Task<int> Update(CategoryModel category);
        Task<int> Delete(CategoryModel category);
        Task<int> CountAll(FilterModel filter);
    }
}
