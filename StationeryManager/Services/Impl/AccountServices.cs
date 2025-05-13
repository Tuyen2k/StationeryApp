using StationeryManager.Util;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services.Impl
{
    public class AccountServices : IAccountServices
    {
        private readonly HttpClient _httpClient;
        public AccountServices(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<int> CountAll(FilterModel? filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/accounts/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var accounts = await result.Content.ReadFromJsonAsync<int>();
                return accounts;
            }
            return 0;
        }

        public async Task<bool> CreateAccount(CreateAccountRequest account)
        {
            var result = await _httpClient.PostAsJsonAsync("api/accounts", account);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAccount(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/accounts/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<AccountModel?> GetAccountById(string id)
        {
            var result = await _httpClient.GetAsync($"api/accounts/{id}");
            if (result.IsSuccessStatusCode)
            {
                var account = await result.Content.ReadFromJsonAsync<AccountModel>();
                return account;
            }
            return null;
        }

        public async Task<List<AccountModel>> GetAllAccounts(FilterModel? filter)
        {
            var query = string.Empty;
            if (filter != null)
            {
                var parameters = new Dictionary<string, string?>
                {
                    { "limit", filter.Limit.ToString() },
                    { "page", filter.Page.ToString() }
                };

                if(!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
            }
            var result = await _httpClient.GetAsync($"api/accounts?{query}");
            if (result.IsSuccessStatusCode)
            {
                var accounts = await result.Content.ReadFromJsonAsync<List<AccountModel>>();
                return accounts ?? [];
            }
            return [];
        }

        public async Task<bool> UpdateAccount(string id, UpdateAccountRequest account)
        {
            var result = await _httpClient.PatchAsJsonAsync($"api/accounts/{id}", account);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
