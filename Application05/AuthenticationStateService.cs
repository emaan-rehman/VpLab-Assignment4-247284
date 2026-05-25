using System;

namespace Application05
{
    public class AuthenticationStateService
    {
        // Maintains the user's logged-in state
        public bool IsAuthenticated { get; private set; } = false;

        // Keeps track of the logged-in username securely
        public string Username { get; private set; } = string.Empty;

        // An event that notifies components when state changes
        public event Action? OnStateChanged;

        public void LogIn(string user)
        {
            // Logic Enhancement: Prevent empty strings or spaces from breaking state rules
            if (!string.IsNullOrWhiteSpace(user))
            {
                IsAuthenticated = true;
                Username = user.Trim(); // Clean input data automatically
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