﻿// <auto-generated />
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240521124007_RecreateIntital")]
    partial class RecreateIntital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.InterestLinks", b =>
                {
                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("LinkID")
                        .HasColumnType("int");

                    b.Property<int>("InterestLinkID")
                        .HasColumnType("int");

                    b.HasKey("InterestID", "LinkID");

                    b.HasIndex("LinkID");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.PersonInterests", b =>
                {
                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("PersonInterestsID")
                        .HasColumnType("int");

                    b.HasKey("InterestID", "PersonID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            PersonID = 1,
                            PersonInterestsID = 0
                        },
                        new
                        {
                            InterestID = 2,
                            PersonID = 1,
                            PersonInterestsID = 0
                        },
                        new
                        {
                            InterestID = 3,
                            PersonID = 2,
                            PersonInterestsID = 0
                        });
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.PersonalLinks", b =>
                {
                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("LinkID")
                        .HasColumnType("int");

                    b.Property<int>("PersonalLinkID")
                        .HasColumnType("int");

                    b.HasKey("PersonID", "LinkID");

                    b.HasIndex("LinkID");

                    b.ToTable("PersonalLinks");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestID"));

                    b.Property<string>("InterestTitle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("InterestsDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("InterestID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            InterestTitle = "Surfing",
                            InterestsDescription = "Väldigt kul, vatten"
                        },
                        new
                        {
                            InterestID = 2,
                            InterestTitle = "Matlagning",
                            InterestsDescription = "Väldigt kul, ingredienser och grejer"
                        },
                        new
                        {
                            InterestID = 3,
                            InterestTitle = "Datorspel",
                            InterestsDescription = "Väldigt kul, dator"
                        });
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Link", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkID"));

                    b.Property<string>("LinkSite")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LinkID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<double>("PhoneNumber")
                        .HasColumnType("float");

                    b.HasKey("PersonID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            FirstName = "Adam",
                            LastName = "Andersson",
                            PhoneNumber = 42552525.0
                        },
                        new
                        {
                            PersonID = 2,
                            FirstName = "Eva",
                            LastName = "Johansson",
                            PhoneNumber = 731234567.0
                        });
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.InterestLinks", b =>
                {
                    b.HasOne("SUT23TeknikButikModels.Interest", "Interests")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23TeknikButikModels.Link", "Links")
                        .WithMany("InterestLinks")
                        .HasForeignKey("LinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("Links");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.PersonInterests", b =>
                {
                    b.HasOne("SUT23TeknikButikModels.Interest", "Interests")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23TeknikButikModels.Person", "person")
                        .WithMany("PersonInterests")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("person");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Connections.PersonalLinks", b =>
                {
                    b.HasOne("SUT23TeknikButikModels.Link", "Link")
                        .WithMany("PersonalLinks")
                        .HasForeignKey("LinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23TeknikButikModels.Person", "People")
                        .WithMany("PersonalLinks")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("People");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Interest", b =>
                {
                    b.Navigation("InterestLinks");

                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Link", b =>
                {
                    b.Navigation("InterestLinks");

                    b.Navigation("PersonalLinks");
                });

            modelBuilder.Entity("SUT23TeknikButikModels.Person", b =>
                {
                    b.Navigation("PersonInterests");

                    b.Navigation("PersonalLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
