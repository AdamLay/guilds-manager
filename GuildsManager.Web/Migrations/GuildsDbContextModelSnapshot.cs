﻿// <auto-generated />
using System;
using GuildsManager.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    [DbContext(typeof(GuildsDbContext))]
    partial class GuildsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GuildsManager.Web.Data.Ability", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("int");

                    b.Property<bool>("Fatigue")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("Passive")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("Torment")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("Abilities", (string)null);
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Attack", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<bool>("AoE")
                        .HasColumnType("bit");

                    b.Property<byte>("Arc")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Attacks")
                        .HasColumnType("tinyint");

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("int");

                    b.Property<int?>("Element")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte>("Range")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("Attacks", (string)null);
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Faction", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<byte>("Force")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Factions", (string)null);
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ModelCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Def")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Dex")
                        .HasColumnType("tinyint");

                    b.Property<short>("FactionId")
                        .HasColumnType("smallint");

                    b.Property<bool>("Healing")
                        .HasColumnType("bit");

                    b.Property<bool>("IgnoreDifficultTerrain")
                        .HasColumnType("bit");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("Levitating")
                        .HasColumnType("bit");

                    b.Property<byte>("Might")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("Shield")
                        .HasColumnType("bit");

                    b.Property<byte>("Slots")
                        .HasColumnType("tinyint");

                    b.Property<byte>("UnitNumber")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Will")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.ToTable("ModelCards", (string)null);
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ResistanceWeakness", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("int");

                    b.Property<int>("Effect")
                        .HasColumnType("int");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("ResistancesWeaknesses", (string)null);
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Ability", b =>
                {
                    b.HasOne("GuildsManager.Web.Data.ModelCard", "Card")
                        .WithMany("Abilities")
                        .HasForeignKey("CardId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Attack", b =>
                {
                    b.HasOne("GuildsManager.Web.Data.ModelCard", "Card")
                        .WithMany("Attacks")
                        .HasForeignKey("CardId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ModelCard", b =>
                {
                    b.HasOne("GuildsManager.Web.Data.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ResistanceWeakness", b =>
                {
                    b.HasOne("GuildsManager.Web.Data.ModelCard", "Card")
                        .WithMany("ResistancesWeaknesses")
                        .HasForeignKey("CardId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ModelCard", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Attacks");

                    b.Navigation("ResistancesWeaknesses");
                });
#pragma warning restore 612, 618
        }
    }
}
