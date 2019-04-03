using Crud.App.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.App.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : Entity<TEntity>
        {
            configuration.Map(builder: modelBuilder.Entity<TEntity>());
        }
    }
}
