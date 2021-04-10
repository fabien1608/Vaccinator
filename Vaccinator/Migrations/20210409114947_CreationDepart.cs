using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class CreationDepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resident = table.Column<bool>(type: "INTEGER", nullable: false),
                    Personnel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
