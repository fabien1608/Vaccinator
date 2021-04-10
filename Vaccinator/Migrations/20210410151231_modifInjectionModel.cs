using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class modifInjectionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Personnes_personneId",
                table: "Injection");

            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Vaccin_vaccinId",
                table: "Injection");

            migrationBuilder.RenameColumn(
                name: "vaccinId",
                table: "Injection",
                newName: "VaccinId");

            migrationBuilder.RenameColumn(
                name: "personneId",
                table: "Injection",
                newName: "PersonneId");

            migrationBuilder.RenameIndex(
                name: "IX_Injection_vaccinId",
                table: "Injection",
                newName: "IX_Injection_VaccinId");

            migrationBuilder.RenameIndex(
                name: "IX_Injection_personneId",
                table: "Injection",
                newName: "IX_Injection_PersonneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection",
                column: "VaccinId",
                principalTable: "Vaccin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Personnes_PersonneId",
                table: "Injection");

            migrationBuilder.DropForeignKey(
                name: "FK_Injection_Vaccin_VaccinId",
                table: "Injection");

            migrationBuilder.RenameColumn(
                name: "VaccinId",
                table: "Injection",
                newName: "vaccinId");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Injection",
                newName: "personneId");

            migrationBuilder.RenameIndex(
                name: "IX_Injection_VaccinId",
                table: "Injection",
                newName: "IX_Injection_vaccinId");

            migrationBuilder.RenameIndex(
                name: "IX_Injection_PersonneId",
                table: "Injection",
                newName: "IX_Injection_personneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Personnes_personneId",
                table: "Injection",
                column: "personneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injection_Vaccin_vaccinId",
                table: "Injection",
                column: "vaccinId",
                principalTable: "Vaccin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
