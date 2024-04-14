﻿// <auto-generated />
using System;
using ChatbotNinja.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatbotNinja.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240410194157_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterTemplateRole", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<Guid>("CharactersCharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacterId", "CharactersCharacterId");

                    b.HasIndex("CharactersCharacterId");

                    b.ToTable("CharacterTemplateRole");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Character", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PersonalityId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TemplateRoleId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex(new[] { "CharacterId" }, "CharacterId");

                    b.HasIndex(new[] { "Name" }, "Name")
                        .IsUnique();

                    b.HasIndex(new[] { "Status" }, "Status");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Instruction", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"));

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Inputs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PersonalityId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Triggers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructionId");

                    b.HasIndex("PersonalityId");

                    b.HasIndex("TemplateRoleId");

                    b.ToTable("Instructions", (string)null);
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Personality", b =>
                {
                    b.Property<int>("PersonalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalityId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PersonalityId");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Personalities", (string)null);
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.PersonalityTrail", b =>
                {
                    b.Property<int>("PersonalityTrailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalityTrailId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalityId")
                        .HasColumnType("int");

                    b.HasKey("PersonalityTrailId");

                    b.HasIndex("PersonalityId");

                    b.ToTable("PersonalityTrail");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.TemplateRole", b =>
                {
                    b.Property<int>("TemplateRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateRoleId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("date");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TemplateRoleId");

                    b.ToTable("TemplateRoles", (string)null);
                });

            modelBuilder.Entity("CharacterTemplateRole", b =>
                {
                    b.HasOne("ChatbotNinja.Core.Entities.TemplateRole", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatbotNinja.Core.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Instruction", b =>
                {
                    b.HasOne("ChatbotNinja.Core.Entities.Personality", "Personality")
                        .WithMany("PersonalityInstructions")
                        .HasForeignKey("PersonalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatbotNinja.Core.Entities.TemplateRole", "TemplateRole")
                        .WithMany("PersonalityInstructions")
                        .HasForeignKey("TemplateRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personality");

                    b.Navigation("TemplateRole");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Personality", b =>
                {
                    b.HasOne("ChatbotNinja.Core.Entities.Character", "Character")
                        .WithOne("BasePersonality")
                        .HasForeignKey("ChatbotNinja.Core.Entities.Personality", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.PersonalityTrail", b =>
                {
                    b.HasOne("ChatbotNinja.Core.Entities.Personality", "Personality")
                        .WithMany("PersonalityTrails")
                        .HasForeignKey("PersonalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personality");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Character", b =>
                {
                    b.Navigation("BasePersonality")
                        .IsRequired();
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.Personality", b =>
                {
                    b.Navigation("PersonalityInstructions");

                    b.Navigation("PersonalityTrails");
                });

            modelBuilder.Entity("ChatbotNinja.Core.Entities.TemplateRole", b =>
                {
                    b.Navigation("PersonalityInstructions");
                });
#pragma warning restore 612, 618
        }
    }
}
