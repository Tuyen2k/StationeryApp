using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service
{
    public interface IAuthServices
    {
        string GenerateJwtToken(AccountModel account);
    }
}
