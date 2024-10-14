﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoDeliveryApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241012110933_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Contribuicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContribuinteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Prevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Recebimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagamentoId")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ContribuinteId");

                    b.HasIndex("TipoPagamentoId");

                    b.ToTable("Contribuicao");
                });

            modelBuilder.Entity("Contribuinte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contribuintes");
                });

            modelBuilder.Entity("Mensageiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mensageiros");
                });

            modelBuilder.Entity("MovimentoDiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContribuicaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Movimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("MensageiroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContribuicaoId");

                    b.HasIndex("MensageiroId");

                    b.ToTable("MovimentosDiarios");
                });

            modelBuilder.Entity("TipoPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPagamentos");
                });

            modelBuilder.Entity("Contribuicao", b =>
                {
                    b.HasOne("Contribuinte", "Contribuinte")
                        .WithMany()
                        .HasForeignKey("ContribuinteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TipoPagamento", "TipoPagamento")
                        .WithMany()
                        .HasForeignKey("TipoPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contribuinte");

                    b.Navigation("TipoPagamento");
                });

            modelBuilder.Entity("MovimentoDiario", b =>
                {
                    b.HasOne("Contribuicao", "ContribuicaoRecibo")
                        .WithMany()
                        .HasForeignKey("ContribuicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mensageiro", "Mensageiro")
                        .WithMany()
                        .HasForeignKey("MensageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContribuicaoRecibo");

                    b.Navigation("Mensageiro");
                });
#pragma warning restore 612, 618
        }
    }
}