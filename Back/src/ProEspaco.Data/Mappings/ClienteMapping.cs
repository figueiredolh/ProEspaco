using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEspaco.Business.Entities;

namespace ProEspaco.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nome).HasColumnType("varchar(30)").IsRequired();
            builder.Property(c => c.Sobrenome).HasColumnType("varchar(30)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(15)").IsRequired();
            builder.Property(c => c.Cep).HasColumnType("varchar(10)");
            builder.Property(c => c.Endereco).HasColumnType("varchar(150)");
            builder.Property(c => c.Bairro).HasColumnType("varchar(50)");
            builder.Property(c => c.Cidade).HasColumnType("varchar(50)");

            builder.Property(c => c.DataCriacao).HasColumnName("Data_Cadastro");

            builder.ToTable("Clientes");
        }
    }
}
