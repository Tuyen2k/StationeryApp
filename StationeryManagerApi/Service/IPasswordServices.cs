namespace StationeryManagerApi.Service
{
    public interface IPasswordServices
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string hashPassword,string password);
    }
}
