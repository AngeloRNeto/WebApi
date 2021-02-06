﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Entity;

namespace WebApi.Entity.Migrations
{
    [DbContext(typeof(WebContext))]
    partial class WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApi.Domain.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("brand")
                        .HasColumnType("text");

                    b.Property<int?>("categoriaid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.Property<double>("value")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.HasIndex("categoriaid");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Produto", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaid");
                });
#pragma warning restore 612, 618
        }
    }
}