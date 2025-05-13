namespace StationeryManager.Util
{
    public class AppStateService
    {
        private string _title = "Trang mặc định";

        public string Title => _title;

        public event Action? OnTitleChanged;

        public void SetTitle(string title)
        {
            _title = title;
            OnTitleChanged?.Invoke();
        }
    }
}
