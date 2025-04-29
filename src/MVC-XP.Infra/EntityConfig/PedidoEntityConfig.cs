using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC_XP.Model.Entidades;

namespace MVC_XP.Infra.EntityConfig
{
    internal class PedidoEntityConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.ClienteId)
                .IsRequired();

            builder.ToTable(nameof(Pedido));
        }
    }
}