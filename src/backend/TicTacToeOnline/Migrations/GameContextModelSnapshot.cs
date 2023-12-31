﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToeOnline.Data;

#nullable disable

namespace TicTacToeOnline.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicTacToeOnline.Models.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Board")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Board");

                    b.Property<string>("CurrentPlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Games", t =>
                        {
                            t.Property("Board")
                                .HasColumnName("Board1");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
