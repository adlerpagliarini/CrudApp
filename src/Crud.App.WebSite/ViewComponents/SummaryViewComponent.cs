using Crud.App.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crud.App.WebSite.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotification _notifications;

        public SummaryViewComponent(IDomainNotification notifications)
        {
            _notifications = notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.GetNotifications());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}
