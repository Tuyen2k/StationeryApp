using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface ISubCategoryServices
    {
        Task<SubCategoryModel?> GetById(string id);
        Task<List<SubCategoryModel>> GetAlls(SubCategoryFilterModel filter);
        Task<int> CountAll(SubCategoryFilterModel filter);
        Task<SubCategoryModel> Create(SubCategoryRequest request, ClaimModel user);
        Task<int> Update(SubCategoryModel subCategory, SubCategoryRequest request, ClaimModel user);
        Task<int> Delete(SubCategoryModel subCategory, ClaimModel user);
    }
}
