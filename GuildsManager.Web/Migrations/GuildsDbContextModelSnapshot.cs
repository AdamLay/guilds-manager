﻿// <auto-generated />
using GuildsManager.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GuildsManager.Web.Data.Ability", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("integer");

                    b.Property<bool>("Fatigue")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<bool>("Passive")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("Torment")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Attack", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<bool>("AoE")
                        .HasColumnType("boolean");

                    b.Property<byte>("Arc")
                        .HasColumnType("smallint");

                    b.Property<byte>("Attacks")
                        .HasColumnType("smallint");

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("integer");

                    b.Property<int?>("Element")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<byte>("Range")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("Attacks");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.Faction", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<byte>("Force")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ModelCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte>("Def")
                        .HasColumnType("smallint");

                    b.Property<byte>("Dex")
                        .HasColumnType("smallint");

                    b.Property<short>("FactionId")
                        .HasColumnType("smallint");

                    b.Property<bool>("Healing")
                        .HasColumnType("boolean");

                    b.Property<byte>("HeroicWounds")
                        .HasColumnType("smallint");

                    b.Property<bool>("IgnoreDifficultTerrain")
                        .HasColumnType("boolean");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<bool>("Levitating")
                        .HasColumnType("boolean");

                    b.Property<byte>("Might")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<bool>("Shield")
                        .HasColumnType("boolean");

                    b.Property<byte>("Slots")
                        .HasColumnType("smallint");

                    b.Property<byte>("UnitNumber")
                        .HasColumnType("smallint");

                    b.Property<byte>("Will")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.ToTable("ModelCards");
                });

            modelBuilder.Entity("GuildsManager.Web.Data.ResistanceWeakness", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<short>("CardId")
                        .HasColumnType("smallint");

                    b.Property<int>("CardId1")
                        .HasColumnType("integer");

                    b.Property<int>("Effect")
                        .HasColumnType("integer");

                    b.Property<int>("Element")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.ToTable("ResistancesWeaknesses");
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
