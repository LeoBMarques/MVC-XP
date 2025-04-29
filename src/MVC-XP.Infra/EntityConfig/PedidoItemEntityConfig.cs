using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC_XP.Model.Entidades;

namespace MVC_XP.Infra.EntityConfig
{
    internal class PedidoItemEntityConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.PedidoId)
                .IsRequired();

            builder.HasOne(x => x.Produto)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.ProdutoId)
               .IsRequired();

            builder.ToTable(nameof(PedidoItem));
        }
    }
}
