using System;
namespace Application05
{
    public class AuthenticationStateService
    {
        public bool IsAuthenticated { get; private set; } = false;
        public string Username { get; private set; } = string.Empty;
        public event Action? OnStateChanged;
        public void LogIn(string user)
        {
            if (!string.IsNullOrWhiteSpace(user))
            {
                IsAuthenticated = true;
                Username = user.Trim(); 
                NotifyStateChanged();
            }
        }
        public void LogOut()
        {
            IsAuthenticated = false;
            Username = string.Empty;
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}