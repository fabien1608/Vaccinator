using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaccinator.Migrations
{
    public partial class ResetUsermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Personnes");

            migrationBuilder.RenameColumn(
                name: "Sexe",
                table: "Personnes",
                newName: "sexe");

            migrationBuilder.RenameColumn(
                name: "Resident",
                table: "Personnes",
                newName: "type");

            migrationBuilder.AlterColumn<int>(
                name: "sexe",
                table: "Personnes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Personnes",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Personnes",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sexe",
                table: "Personnes",
                newName: "Sexe");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Personnes",
                newName: "Resident");

            migrationBuilder.AlterColumn<string>(
                name: "Sexe",
                table: "Personnes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Personnes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Personnes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<bool>(
                name: "Personnel",
                table: "Personnes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
