using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.
                Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(400);

            builder.
                Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.
                Property(x => x.SobreNome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(x => x.Pedidos)
                .WithOne(p => p.Usuario);
        }
    }
}
