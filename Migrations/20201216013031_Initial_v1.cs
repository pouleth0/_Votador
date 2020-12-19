using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AlterdataVotador.Migrations
{
    public partial class Initial_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModulosVotar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NameModulos = table.Column<string>(nullable: true),
                    LinhaDoModulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosVotar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioVotar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Id_MelhoriaVotada = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioVotar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotaHome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataVotar = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotaHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    TimeZoneUSuario = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DatNass = table.Column<string>(nullable: true),
                    ModulosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosAcess_ModulosVotar_ModulosId",
                        column: x => x.ModulosId,
                        principalTable: "ModulosVotar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MelhoriasVotar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeModulo = table.Column<string>(nullable: true),
                    ModuloId = table.Column<int>(nullable: true),
                    MelhoriaArea = table.Column<string>(nullable: true),
                    QuantVotos = table.Column<string>(nullable: true),
                    DetalheDaMemoria_Votar = table.Column<string>(nullable: true),
                    DataVotacao_Votar = table.Column<string>(nullable: true),
                    TrueFalse_Votar = table.Column<bool>(nullable: false),
                    VotarHomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MelhoriasVotar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MelhoriasVotar_ModulosVotar_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "ModulosVotar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MelhoriasVotar_VotaHome_VotarHomeId",
                        column: x => x.VotarHomeId,
                        principalTable: "VotaHome",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasVotar_ModuloId",
                table: "MelhoriasVotar",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasVotar_VotarHomeId",
                table: "MelhoriasVotar",
                column: "VotarHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAcess_ModulosId",
                table: "UsuariosAcess",
                column: "ModulosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MelhoriasVotar");

            migrationBuilder.DropTable(
                name: "UsuariosAcess");

            migrationBuilder.DropTable(
                name: "UsuarioVotar");

            migrationBuilder.DropTable(
                name: "VotaHome");

            migrationBuilder.DropTable(
                name: "ModulosVotar");
        }
    }
}
