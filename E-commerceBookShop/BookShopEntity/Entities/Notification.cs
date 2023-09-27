using BookShopCore.Entities;

namespace BookShopEntity.Entities
{
    public class Notification : BaseEntity
    {
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetails { get; set; }
    }
}
