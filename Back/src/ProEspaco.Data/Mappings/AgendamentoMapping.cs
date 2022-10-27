using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEspaco.Business.Entities;

namespace ProEspaco.Data.Mappings
{
    public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.Property(a => a.DataAgendamento).HasColumnName("Data_Agendamento");
            builder.Property(a => a.DataCriacao).HasColumnName("Data_Criacao");
            builder.Property(a => a.HorarioInicio).HasColumnName("Horario_Inicio");
            builder.Property(a => a.HorarioFim).HasColumnName("Horario_Fim");
            builder.Property(a => a.ValorCobrado).HasColumnType("varchar(10)").HasColumnName("Valor_Cobrado").IsRequired();

            builder.ToTable("Agendamentos");
        }
    }
}
