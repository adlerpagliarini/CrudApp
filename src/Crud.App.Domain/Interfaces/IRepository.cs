using Crud.App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crud.App.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);       
        void Remover(Guid id);
        IEnumerable<TEntity> ObterTodos(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
