using Api.Produtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Produtos.Infrastructure.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("PRODUTOS");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto).HasColumnName("ID_PRODUTO");

            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();

            builder.Property(p => p.Preco).HasColumnName("PRECO").HasPrecision(10, 2).IsRequired();

            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE").IsRequired();

            builder.HasIndex(p => p.Nome).IsUnique();
        }
    }
}
