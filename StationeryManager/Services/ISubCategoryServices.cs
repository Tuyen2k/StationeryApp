using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface ISubCategoryServices
    {
		Task<List<SubCategoryModel>> GetAllAsync(SubCategoryFilterModel? filter);
		Task<int> CountAllAsync(SubCategoryFilterModel? filter);
		Task<SubCategoryModel?> GetByIdAsync(string id);
		Task<bool> CreateAsync(SubCategoryRequest subCategory);
		Task<bool> UpdateAsync(string id, SubCategoryRequest subCategory);
		Task<bool> DeleteAsync(string id);
	}
}
