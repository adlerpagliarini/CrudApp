using System.Collections.Generic;
using System.Linq;

namespace Crud.App.Domain.Core.Notifications
{
    public class DomainNotification : IDomainNotification
    {
        private List<Notification> _notifications;

        public DomainNotification()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}
