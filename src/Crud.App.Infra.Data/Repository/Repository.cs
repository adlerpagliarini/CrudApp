using Crud.App.Domain.Core.Models;
using Crud.App.Domain.Interfaces;
using Crud.App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Crud.App.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected CrudAppContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(CrudAppContext context)
        {
            Db = context;
            Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            DbSet = context.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IEnumerable<TEntity> ObterTodos(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.FirstOrDefault(t => t.Id == id);
        }

        public virtual void Remover(Guid id)
        {
            Db.Remove(DbSet.Find(id));
        }

        public virtual void Atualizar(TEntity obj)
        {
            DetachAll();
            Db.Update(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        private void DetachAll()
        {
            foreach (EntityEntry dbEntityEntry in Db.ChangeTracker.Entries().ToList())
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
        }
    }
}
