using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface ISubCategoryRepositories
    {
        Task<SubCategoryModel?> GetById(Guid id);
        Task<List<SubCategoryModel>> GetAlls(SubCategoryFilterModel filter);
        Task<int> CountAll(SubCategoryFilterModel filter);
        Task<SubCategoryModel> Create(SubCategoryModel inventory);
        Task<int> Update(SubCategoryModel inventory);
        Task<int> Delete(SubCategoryModel inventory);
    }
}
