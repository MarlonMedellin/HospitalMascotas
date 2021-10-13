using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaGHCl.App.Persistencia.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLConstFisiologicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Masa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrecRespiratoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrecCardiaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLConstFisiologicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBLMascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLMascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBLMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBLPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLPersona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBLVeterinaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistroSanitario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLVeterinaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLVeterinaria_TBLMedico_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "TBLMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLPropietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    AnimalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLPropietario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLPropietario_TBLMascota_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "TBLMascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLPropietario_TBLPersona_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "TBLPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Procedimiento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLServicio_TBLPropietario_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "TBLPropietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLServicio_TBLVeterinaria_ClinicaID",
                        column: x => x.ClinicaID,
                        principalTable: "TBLVeterinaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLHistClinica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaID = table.Column<int>(type: "int", nullable: false),
                    ParamVitalesID = table.Column<int>(type: "int", nullable: false),
                    PlanTerp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antecedentes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLHistClinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLHistClinica_TBLConstFisiologicas_ParamVitalesID",
                        column: x => x.ParamVitalesID,
                        principalTable: "TBLConstFisiologicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLHistClinica_TBLServicio_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "TBLServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLHistClinica_ConsultaID",
                table: "TBLHistClinica",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLHistClinica_ParamVitalesID",
                table: "TBLHistClinica",
                column: "ParamVitalesID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropietario_AnimalID",
                table: "TBLPropietario",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropietario_UsuarioID",
                table: "TBLPropietario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLServicio_ClienteID",
                table: "TBLServicio",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLServicio_ClinicaID",
                table: "TBLServicio",
                column: "ClinicaID");

            migrationBuilder.CreateIndex(
                name: "IX_TBLVeterinaria_DoctorID",
                table: "TBLVeterinaria",
                column: "DoctorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLHistClinica");

            migrationBuilder.DropTable(
                name: "TBLConstFisiologicas");

            migrationBuilder.DropTable(
                name: "TBLServicio");

            migrationBuilder.DropTable(
                name: "TBLPropietario");

            migrationBuilder.DropTable(
                name: "TBLVeterinaria");

            migrationBuilder.DropTable(
                name: "TBLMascota");

            migrationBuilder.DropTable(
                name: "TBLPersona");

            migrationBuilder.DropTable(
                name: "TBLMedico");
        }
    }
}
