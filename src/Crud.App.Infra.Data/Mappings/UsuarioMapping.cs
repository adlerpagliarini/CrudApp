using Crud.App.Domain.Usuarios;
using Crud.App.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.App.Infra.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(e => e.NomeCompleto).Property(n => n.PrimeiroNome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.OwnsOne(e => e.NomeCompleto).Property(n => n.SegundoNome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.OwnsOne(e => e.NomeCompleto).Property(n => n.UltimoNome)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.OwnsOne(e => e.Telefone).Property(t => t.DDD)
                .HasColumnType("varchar(02)")
                .IsRequired();

            builder.OwnsOne(e => e.Telefone).Property(t => t.Numero)
                .HasColumnType("varchar(09)")
                .IsRequired();

            builder.ToTable(nameof(Usuario));

            base.Map(builder);
        }
    }
}
