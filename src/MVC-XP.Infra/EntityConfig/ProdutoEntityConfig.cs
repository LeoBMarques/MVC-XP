using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC_XP.Model.Entidades;

namespace MVC_XP.Infra.EntityConfig
{
    internal class ProdutoEntityConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.ToTable(nameof(Produto));
        }
    }
}
