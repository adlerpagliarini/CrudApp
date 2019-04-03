using Crud.App.Domain.Core.Commands;
using System;

namespace Crud.App.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
