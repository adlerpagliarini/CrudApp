using System;
using System.Collections.Generic;

namespace Crud.App.Domain.Core.Notifications
{
    public interface IDomainNotification : IDisposable
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
