using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEspaco.Business.Entities;

namespace ProEspaco.Data.Mappings
{
    public class ServicoSubtipoMapping : IEntityTypeConfiguration<ServicoSubtipo>
    {
        public void Configure(EntityTypeBuilder<ServicoSubtipo> builder)
        {
            builder.Property(s => s.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.ValorAtual).HasColumnType("varchar(10)").HasColumnName("Valor_Atual").IsRequired();

            builder.ToTable("Servico_Subtipo");
        }
    }
}
