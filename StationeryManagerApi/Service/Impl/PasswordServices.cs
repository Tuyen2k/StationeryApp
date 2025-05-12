using Microsoft.AspNetCore.Identity;

namespace StationeryManagerApi.Service.Impl
{
    public class PasswordServices : IPasswordServices
    {
        private readonly PasswordHasher<object> _hasher = new();
        public string HashPassword(string password)
        {
            string hashPassword = _hasher.HashPassword(null,password);
            return hashPassword;
        }

        public bool VerifyPassword(string hashPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword(null, hashPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
