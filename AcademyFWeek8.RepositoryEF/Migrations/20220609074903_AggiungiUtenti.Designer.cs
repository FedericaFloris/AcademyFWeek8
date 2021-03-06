// <auto-generated />
using System;
using AcademyFWeek8.RepositoryEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcademyFWeek8.RepositoryEF.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220609074903_AggiungiUtenti")]
    partial class AggiungiUtenti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Corso", b =>
                {
                    b.Property<string>("CorsoCodice")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorsoCodice");

                    b.ToTable("Corso", (string)null);
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Docente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Docente", (string)null);
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Lezione", b =>
                {
                    b.Property<int>("LezioneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LezioneId"), 1L, 1);

                    b.Property<string>("Aula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsoCodice")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataOraInizio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocenteID")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.HasKey("LezioneId");

                    b.HasIndex("CorsoCodice");

                    b.HasIndex("DocenteID");

                    b.ToTable("Lezione", (string)null);
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Studente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsoCodice")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitoloStudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CorsoCodice");

                    b.ToTable("Studente", (string)null);
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Utente", (string)null);
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Lezione", b =>
                {
                    b.HasOne("AcademyFWeek8.Core.Entities.Corso", "Corso")
                        .WithMany("Lezioni")
                        .HasForeignKey("CorsoCodice")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademyFWeek8.Core.Entities.Docente", "Docente")
                        .WithMany("Lezioni")
                        .HasForeignKey("DocenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corso");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Studente", b =>
                {
                    b.HasOne("AcademyFWeek8.Core.Entities.Corso", "Corso")
                        .WithMany("Studenti")
                        .HasForeignKey("CorsoCodice")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corso");
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Corso", b =>
                {
                    b.Navigation("Lezioni");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("AcademyFWeek8.Core.Entities.Docente", b =>
                {
                    b.Navigation("Lezioni");
                });
#pragma warning restore 612, 618
        }
    }
}
