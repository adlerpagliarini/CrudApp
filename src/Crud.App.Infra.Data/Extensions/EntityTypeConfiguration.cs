using Crud.App.Domain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.App.Infra.Data.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : Entity<TEntity>
    {
        public virtual void Map(EntityTypeBuilder<TEntity> builder) {
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
