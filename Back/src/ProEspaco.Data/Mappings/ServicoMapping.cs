using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEspaco.Business.Entities;

namespace ProEspaco.Data.Mappings
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.Property(s => s.Nome).HasColumnType("varchar(50)").IsRequired();

            builder.Property(s => s.TemSubtipo).HasColumnName("Tem_Subtipo");
            builder.Property(s => s.ValorAtual).HasColumnType("varchar(20)").HasColumnName("Valor_Atual").IsRequired();

            builder.ToTable("Servico");
        }
    }
}
