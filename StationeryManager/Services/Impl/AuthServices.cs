
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using StationeryManager.Util;
using StationeryManagerLib.RequestModel;
using static System.Net.WebRequestMethods;

namespace StationeryManager.Services.Impl
{
    public class AuthServices : IAuthServices
    {
        private readonly HttpClient _httpClient;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly AppStateService _appState;

        public AuthServices(HttpClient httpClient, ProtectedLocalStorage localStorage, AppStateService appState) {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _appState = appState;
        }
        public Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrentUserIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrentUsernameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrentUserRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync(LoginRequestModel request)
        {
            var result = await _httpClient.PostAsync("api/auth/login", new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
            if(result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(token))
                {
                    await _localStorage.SetAsync("authToken", token);
                    await _localStorage.SetAsync("userEmail", request.Email);
                    _appState.UserEmail = request.Email;
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> LogoutAsync()
        {
            // Remove the token from local storage
            await _localStorage.DeleteAsync("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = null;

            // 
            var result = await _localStorage.GetAsync<string>("authToken");
            var token = result.Success ? result.Value : null;

            if (string.IsNullOrEmpty(token))
            {
                return true;
            }
            
            return false;
        }

        public Task<bool> RegisterAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(string username, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
