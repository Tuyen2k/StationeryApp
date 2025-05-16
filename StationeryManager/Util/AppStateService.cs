namespace StationeryManager.Util
{
    public class AppStateService
    {
        private string _title = "Trang chủ";
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyTitleChanged();
                }
            }
        }
        public bool IsLoggedIn { get; set; } = false;
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public Action? ShowLoginDialog { get; set; }
        public Action? ShowRegister { get; set; }
        public Action? ShowUserProfile { get; set; }

        public event Action? OnLoginStateChanged;

        public void NotifyLoginStateChanged() => OnLoginStateChanged?.Invoke();

        public event Action? OnTitleChanged;

        private void NotifyTitleChanged() => OnTitleChanged?.Invoke();
    }
}
