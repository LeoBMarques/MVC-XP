using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC_XP.Model.Entidades;

namespace MVC_XP.Infra.EntityConfig
{
    internal class ClienteEntityConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(128);

            builder.ToTable(nameof(Cliente));
        }
    }
}
