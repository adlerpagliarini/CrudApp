using Crud.App.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Crud.App.WebSite.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotification _notifications;

        public BaseController(IDomainNotification notifications)
        {
            _notifications = notifications;
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
