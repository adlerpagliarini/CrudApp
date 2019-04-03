using Crud.App.Domain.Core.Notifications;
using Crud.App.Domain.Interfaces;
using FluentValidation.Results;

namespace Crud.App.Domain.CommandHandlers
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotification _notifications;

        protected ServiceBase(IUnitOfWork unitOfWork, IDomainNotification notifications)
        {
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected void NotificarValidacoesErro(string evento, string mensagemDeErro)
        {
            _notifications.AddNotification(new Notification(evento, mensagemDeErro));
        }

        protected bool Commit()
        {

            if (_notifications.HasNotifications()) return false;
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            _notifications.AddNotification(new Notification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }

        public bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
