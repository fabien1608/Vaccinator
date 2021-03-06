// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vaccinator.Models;

namespace Vaccinator.Migrations
{
    [DbContext(typeof(ContexteBDD))]
    [Migration("20210410153847_modifInjectionModel2")]
    partial class modifInjectionModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Vaccinator.Models.Injection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePremier")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRappel")
                        .HasColumnType("TEXT");

                    b.Property<int>("Lot")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonneId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VaccinId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonneId");

                    b.HasIndex("VaccinId");

                    b.ToTable("Injection");
                });

            modelBuilder.Entity("Vaccinator.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<int>("residence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sexe")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("Vaccinator.Models.Vaccin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeV")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vaccin");
                });

            modelBuilder.Entity("Vaccinator.Models.Injection", b =>
                {
                    b.HasOne("Vaccinator.Models.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("PersonneId");

                    b.HasOne("Vaccinator.Models.Vaccin", "Vaccin")
                        .WithMany()
                        .HasForeignKey("VaccinId");

                    b.Navigation("Personne");

                    b.Navigation("Vaccin");
                });
#pragma warning restore 612, 618
        }
    }
}
