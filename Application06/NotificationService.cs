using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application06
{
    public class NotificationService
    {
        private readonly NotificationConfig _config;
        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }
        public async Task<List<NotificationItem>> GetNotificationsAsync(int? countOverride = null)
        {
            await Task.Delay(150);
            int finalCount = countOverride ?? _config.DefaultNumberOfNotifications;
            if (finalCount < 1) finalCount = 1;

            var list = new List<NotificationItem>();
            string[] topics = { "Database Sync", "Security Portal", "Memory Core", "API Pipeline", "Cloud Telemetry" };
            string[] descriptions = {
                "System completed indexing transaction matrix registries.",
                "Anomalous login attempt mitigated from unrecognized address route.",
                "Garbage collector successfully cleared unreferenced memory buffers.",
                "Server payload transmission throughput stabilized at optimal rates.",
                "Environment operational parameters verified across active availability zones."
            };
            for (int i = 0; i < finalCount; i++)
            {
                int index = i % topics.Length;
                list.Add(new NotificationItem
                {
                    Id = 100 + i,
                    Title = topics[index],
                    Description = descriptions[index],
                    Timestamp = DateTime.Now.AddMinutes(-i * 12),
                    StyleApplied = _config.NotificationStyle
                });
            }

            return list;
        }
    }
    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string StyleApplied { get; set; } = "Compact";
    }
}