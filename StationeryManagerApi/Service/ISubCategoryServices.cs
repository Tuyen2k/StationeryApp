using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface ISubCategoryServices
    {
        Task<SubCategoryModel?> GetById(string id);
        Task<List<SubCategoryModel>> GetAlls(FilterModel filter);
        Task<SubCategoryModel> Create(SubCategoryRequest request);
        Task<int> Update(SubCategoryModel subCategory, SubCategoryRequest request);
        Task<int> Delete(SubCategoryModel subCategory);
    }
}
