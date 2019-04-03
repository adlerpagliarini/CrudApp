using System;

namespace Crud.App.Domain.Core.Notifications
{
    public class Notification
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value  { get; private set; }
        public int Version { get; private set; }

        public Notification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}
