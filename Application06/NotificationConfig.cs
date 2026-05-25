namespace Application06
{
    public class NotificationConfig
    {
        public int DefaultNumberOfNotifications { get; set; } = 3;

        // Supports "Compact" or "Detailed" view types
        public string NotificationStyle { get; set; } = "Compact";
    }
}