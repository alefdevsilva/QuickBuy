using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(x => x.Descricao)
               .IsRequired()
               .HasMaxLength(400);

            builder
              .Property(x => x.Preco)
              .IsRequired();
        }
    }
}
