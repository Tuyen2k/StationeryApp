using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IAuthServices
    {
        Task<bool> LoginAsync(LoginRequestModel request);
        Task<bool> RegisterAsync(string username, string password);
        Task<bool> LogoutAsync();
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string username, string newPassword);
        Task<bool> IsAuthenticatedAsync();
        Task<string> GetCurrentUserIdAsync();
        Task<string> GetCurrentUsernameAsync();
        Task<string> GetCurrentUserRoleAsync();
    }
}
