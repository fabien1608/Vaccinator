using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class addInjection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Injection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lot = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    Marque = table.Column<int>(type: "INTEGER", maxLength: 30, nullable: false),
                    DatePremier = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRappel = table.Column<DateTime>(type: "TEXT", nullable: false),
                    personneId = table.Column<int>(type: "INTEGER", nullable: true),
                    vaccinId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injection_Personnes_personneId",
                        column: x => x.personneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Injection_Vaccin_vaccinId",
                        column: x => x.vaccinId,
                        principalTable: "Vaccin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Injection_personneId",
                table: "Injection",
                column: "personneId");

            migrationBuilder.CreateIndex(
                name: "IX_Injection_vaccinId",
                table: "Injection",
                column: "vaccinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injection");
        }
    }
}
