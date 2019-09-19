﻿// <auto-generated />
using System;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoteriaFacil.Infra.Data.Migrations
{
    [DbContext(typeof(LoteriaFacilContext))]
    [Migration("20190919174202_PersonLottery")]
    partial class PersonLottery
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoteriaFacil.Domain.Models.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Calcular_Dezenas_Sem_Pontuacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Checar_Jogo_Online")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Enviar_Email_Automaticamente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Enviar_Email_Manualmente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Valor_Minimo_Para_Envio_Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.Lottery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("Concurse")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtConcurse")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtNextConcurse")
                        .HasColumnType("datetime");

                    b.Property<string>("Game")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Hit11")
                        .HasColumnType("int");

                    b.Property<int>("Hit12")
                        .HasColumnType("int");

                    b.Property<int>("Hit13")
                        .HasColumnType("int");

                    b.Property<int>("Hit14")
                        .HasColumnType("int");

                    b.Property<int>("Hit15")
                        .HasColumnType("int");

                    b.Property<decimal>("Shared11")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Shared12")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Shared13")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Shared14")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Shared15")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<Guid?>("TypeLotteryId");

                    b.HasKey("Id");

                    b.HasIndex("TypeLotteryId");

                    b.ToTable("Lottery");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DtRegister");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.PersonLottery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("Concurse")
                        .HasColumnType("int");

                    b.Property<string>("Game")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Game_Checked")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Game_Register")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<Guid?>("LotteryId");

                    b.Property<Guid?>("PersonId");

                    b.Property<decimal>("Ticket_Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("LotteryId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonLottery");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.TypeLottery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<decimal>("Bet_Min")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("Hit_Max")
                        .HasColumnType("int");

                    b.Property<int>("Hit_Min")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<int>("Tens_Min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeLottery");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.Lottery", b =>
                {
                    b.HasOne("LoteriaFacil.Domain.Models.TypeLottery", "TypeLottery")
                        .WithMany()
                        .HasForeignKey("TypeLotteryId");
                });

            modelBuilder.Entity("LoteriaFacil.Domain.Models.PersonLottery", b =>
                {
                    b.HasOne("LoteriaFacil.Domain.Models.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("LotteryId");

                    b.HasOne("LoteriaFacil.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
