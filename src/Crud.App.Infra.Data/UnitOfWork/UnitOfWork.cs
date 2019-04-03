using Crud.App.Domain.Core.Commands;
using Crud.App.Domain.Interfaces;
using Crud.App.Infra.Data.Context;

namespace Crud.App.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudAppContext _context;

        public UnitOfWork(CrudAppContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
