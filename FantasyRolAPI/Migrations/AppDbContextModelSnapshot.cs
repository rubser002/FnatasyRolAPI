﻿// <auto-generated />
using System;
using FantasyRolAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FantasyRolAPI.Models.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Identifier")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("SubclassId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SubclassId");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Background", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bond")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Features")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Flaw")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Ideal")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Languages")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PersonalityTrait")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Background");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Bonus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AbilityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("RaceId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("bonusValue")
                        .HasColumnType("int");

                    b.Property<int>("characteristic")
                        .HasColumnType("int");

                    b.Property<int?>("setProficiency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RaceId");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Alignment")
                        .HasColumnType("int");

                    b.Property<Guid?>("BackgroundId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacterClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacterRaceId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("CurrentHitPoints")
                        .HasColumnType("int");

                    b.Property<string>("CurrentSpellSlots")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExperiencePoints")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Story")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("SubclassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("CharacterRaceId");

                    b.HasIndex("SubclassId");

                    b.HasIndex("UserId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.CharacterAbility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AbilityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterAbility");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.CharacterSpell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SpellId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SpellId");

                    b.ToTable("CharacterSpell");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HitDice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.ClassAbility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AbilityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassAbility");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AbilityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("AgeInterval")
                        .HasColumnType("longtext");

                    b.Property<string>("DescAlignment")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Height")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Weight")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Spell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Components")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SComponents")
                        .HasColumnType("longtext");

                    b.Property<int?>("School")
                        .HasColumnType("int");

                    b.Property<int>("SpellLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Subclass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subclass");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Armor", b =>
                {
                    b.HasBaseType("FantasyRolAPI.Models.Item");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Armor");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Weapon", b =>
                {
                    b.HasBaseType("FantasyRolAPI.Models.Item");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<string>("WeaponTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Ability", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Subclass", null)
                        .WithMany("SubClassAbilities")
                        .HasForeignKey("SubclassId");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Bonus", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Ability", null)
                        .WithMany("Bonuses")
                        .HasForeignKey("AbilityId");

                    b.HasOne("FantasyRolAPI.Models.Character", null)
                        .WithMany("Bonuses")
                        .HasForeignKey("CharacterId");

                    b.HasOne("FantasyRolAPI.Models.Race", null)
                        .WithMany("Bonuses")
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Character", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Background", "Background")
                        .WithMany()
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Class", "CharacterClass")
                        .WithMany("Characters")
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Race", "CharacterRace")
                        .WithMany()
                        .HasForeignKey("CharacterRaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Subclass", "CharacterSubclass")
                        .WithMany()
                        .HasForeignKey("SubclassId");

                    b.HasOne("FantasyRolAPI.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Background");

                    b.Navigation("CharacterClass");

                    b.Navigation("CharacterRace");

                    b.Navigation("CharacterSubclass");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.CharacterAbility", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Ability", "Ability")
                        .WithMany("CharacterAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Character", "Character")
                        .WithMany("CharacterAbilities")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.CharacterSpell", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.ClassAbility", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Ability", "Ability")
                        .WithMany("ClassAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyRolAPI.Models.Class", "Class")
                        .WithMany("ClassAbilities")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Item", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Character", null)
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Race", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Ability", "Ability")
                        .WithMany()
                        .HasForeignKey("AbilityId");

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Spell", b =>
                {
                    b.HasOne("FantasyRolAPI.Models.Character", null)
                        .WithMany("Spells")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Ability", b =>
                {
                    b.Navigation("Bonuses");

                    b.Navigation("CharacterAbilities");

                    b.Navigation("ClassAbilities");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Character", b =>
                {
                    b.Navigation("Bonuses");

                    b.Navigation("CharacterAbilities");

                    b.Navigation("Inventory");

                    b.Navigation("Spells");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Class", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("ClassAbilities");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Race", b =>
                {
                    b.Navigation("Bonuses");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.Subclass", b =>
                {
                    b.Navigation("SubClassAbilities");
                });

            modelBuilder.Entity("FantasyRolAPI.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
