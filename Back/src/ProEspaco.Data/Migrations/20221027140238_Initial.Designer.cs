﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEspaco.Data.Context;

namespace ProEspaco.Data.Migrations
{
    [DbContext(typeof(ProEspacoContext))]
    [Migration("20221027140238_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProEspaco.Business.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Agendamento");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Criacao");

                    b.Property<DateTime>("HorarioFim")
                        .HasColumnType("datetime2")
                        .HasColumnName("Horario_Fim");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("Horario_Inicio");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicoSubtipoId")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("ValorCobrado")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Valor_Cobrado");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("ServicoSubtipoId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Cadastro");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("TemSubtipo")
                        .HasColumnType("bit")
                        .HasColumnName("Tem_Subtipo");

                    b.Property<string>("ValorAtual")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Valor_Atual");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.ServicoSubtipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("ValorAtual")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Valor_Atual");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.ToTable("Servico_Subtipo");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.Agendamento", b =>
                {
                    b.HasOne("ProEspaco.Business.Entities.Cliente", "Cliente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEspaco.Business.Entities.Servico", "Servico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEspaco.Business.Entities.ServicoSubtipo", "ServicoSubtipo")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ServicoSubtipoId");

                    b.Navigation("Cliente");

                    b.Navigation("Servico");

                    b.Navigation("ServicoSubtipo");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.ServicoSubtipo", b =>
                {
                    b.HasOne("ProEspaco.Business.Entities.Servico", "Servico")
                        .WithMany("Subtipos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.Cliente", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.Servico", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Subtipos");
                });

            modelBuilder.Entity("ProEspaco.Business.Entities.ServicoSubtipo", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
