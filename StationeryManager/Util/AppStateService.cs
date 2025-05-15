namespace StationeryManager.Util
{
    public class AppStateService
    {
        public string Title { get; set; } = "Trang chủ";
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public Action? ShowLoginDialog { get; set; }
        public Action? ShowRegister { get; set; }
        public Action? ShowUserProfile { get; set; }
    }
}
