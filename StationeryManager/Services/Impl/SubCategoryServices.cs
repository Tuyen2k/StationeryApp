using StationeryManager.Util;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
	public class SubCategoryServices : ISubCategoryServices {

		private readonly HttpClient _httpClient;
		public SubCategoryServices(HttpClient client) {
			_httpClient = client;
		}
		public async Task<int> CountAllAsync(SubCategoryFilterModel? filter) {
			var parameters = new Dictionary<string, string?>();
			if (filter != null) {
				if (!string.IsNullOrEmpty(filter.Name)) {
					parameters.Add("name", filter.Name);
				}
				if (!string.IsNullOrEmpty(filter.CategoryId)) {
					parameters.Add("categoryId", filter.CategoryId);
				}
			}

			var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/subcategories/count", parameters);

			var result = await _httpClient.GetAsync(uriBuilder.Uri);
			if (result.IsSuccessStatusCode) {
				var subCategories = await result.Content.ReadFromJsonAsync<int>();
				return subCategories;
			}
			return 0;
		}

		public async Task<bool> CreateAsync(SubCategoryRequest subCategory) {
			var result = await _httpClient.PostAsJsonAsync("api/subcategories", subCategory);

			if (result.IsSuccessStatusCode) {
				return true;
			}
			return false;
		}

		public async Task<bool> DeleteAsync(string id) {
			var result = await _httpClient.DeleteAsync($"api/subcategories/{id}");
			if (result.IsSuccessStatusCode) {
				return true;
			}
			return false;
		}

		public async Task<List<SubCategoryModel>> GetAllAsync(SubCategoryFilterModel? filter) {
			var query = string.Empty;
			if (filter != null) {
				var parameters = new Dictionary<string, string?>
				{
					{ "limit", filter.Limit.ToString() },
					{ "page", filter.Page.ToString() }
				};

				if (!string.IsNullOrEmpty(filter.Name)) {
					parameters.Add("name", filter.Name);
				}

				query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
			}
			var result = await _httpClient.GetAsync($"api/subcategories?{query}");
			if (result.IsSuccessStatusCode) {
				var subCategories = await result.Content.ReadFromJsonAsync<List<SubCategoryModel>>();
				return subCategories ?? [];
			}
			return [];
		}

		public async Task<SubCategoryModel?> GetByIdAsync(string id) {
			var result = await _httpClient.GetAsync($"api/subcategories/{id}");
			if (result.IsSuccessStatusCode) {
				var subCategory = await result.Content.ReadFromJsonAsync<SubCategoryModel>();
				return subCategory;
			}
			return null;
		}

		public async Task<bool> UpdateAsync(string id, SubCategoryRequest subCategory) {
			var result = await _httpClient.PatchAsJsonAsync($"api/subcategories/{id}", subCategory);
			if (result.IsSuccessStatusCode) {
				return true;
			}
			return false;
		}
	}
}
