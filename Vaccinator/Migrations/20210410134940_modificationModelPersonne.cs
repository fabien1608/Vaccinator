using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class modificationModelPersonne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Personnes",
                newName: "residence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "residence",
                table: "Personnes",
                newName: "type");
        }
    }
}
