using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace StationeryManager.Util
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly ProtectedLocalStorage _localStorage;
        public AuthTokenHandler(ProtectedLocalStorage localStorage, AppStateService appState)
        {
            _localStorage = localStorage;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenResult = await _localStorage.GetAsync<string>("authToken");
            if (tokenResult.Success && !string.IsNullOrEmpty(tokenResult.Value))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult.Value);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
