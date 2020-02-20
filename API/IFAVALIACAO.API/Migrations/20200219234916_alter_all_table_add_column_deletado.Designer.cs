﻿// <auto-generated />
using System;
using IFAVALIACAO.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IFAVALIACAO.API.Migrations
{
    [DbContext(typeof(IFDbContext))]
    [Migration("20200219234916_alter_all_table_add_column_deletado")]
    partial class alter_all_table_add_column_deletado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IFAVALIACAO.API.Domain.Entites.Fazenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<bool>("Deletado");

                    b.Property<string>("Endereco");

                    b.Property<string>("Estado");

                    b.Property<string>("InscricaoEstadual");

                    b.Property<string>("NomeFazenda");

                    b.Property<string>("NomeProprietario");

                    b.HasKey("Id");

                    b.ToTable("Fazenda");
                });

            modelBuilder.Entity("IFAVALIACAO.API.Domain.Entites.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<bool>("Deletado");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
