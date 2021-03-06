// <auto-generated />
using System;
using MascotaGHCl.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MascotaGHCl.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211005225312_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MascotaGHCl.App.Dominio.ConstFisiologicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FrecCardiaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrecRespiratoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Masa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperatura")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBLConstFisiologicas");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.HistClinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Antecedentes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultaID")
                        .HasColumnType("int");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParamVitalesID")
                        .HasColumnType("int");

                    b.Property<string>("PlanTerp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaID");

                    b.HasIndex("ParamVitalesID");

                    b.ToTable("TBLHistClinica");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tamanio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBLMascota");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBLMedico");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBLPersona");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnimalID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("TBLPropietario");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<int>("ClinicaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Procedimiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ClinicaID");

                    b.ToTable("TBLServicio");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Veterinaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroSanitario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorID");

                    b.ToTable("TBLVeterinaria");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.HistClinica", b =>
                {
                    b.HasOne("MascotaGHCl.App.Dominio.Servicio", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotaGHCl.App.Dominio.ConstFisiologicas", "ParamVitales")
                        .WithMany()
                        .HasForeignKey("ParamVitalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("ParamVitales");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Propietario", b =>
                {
                    b.HasOne("MascotaGHCl.App.Dominio.Mascota", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotaGHCl.App.Dominio.Persona", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Servicio", b =>
                {
                    b.HasOne("MascotaGHCl.App.Dominio.Propietario", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotaGHCl.App.Dominio.Veterinaria", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("MascotaGHCl.App.Dominio.Veterinaria", b =>
                {
                    b.HasOne("MascotaGHCl.App.Dominio.Medico", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
