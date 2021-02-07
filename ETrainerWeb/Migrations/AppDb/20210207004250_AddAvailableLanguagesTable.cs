using Microsoft.EntityFrameworkCore.Migrations;

namespace ETrainerWebAPI.Migrations.AppDb
{
    public partial class AddAvailableLanguagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "MuscleTranslatedInfo");

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "MuscleTranslatedInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MuscleTranslatedInfo_LanguageID",
                table: "MuscleTranslatedInfo",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleTranslatedInfo_Language_LanguageID",
                table: "MuscleTranslatedInfo",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleTranslatedInfo_Language_LanguageID",
                table: "MuscleTranslatedInfo");

            migrationBuilder.DropIndex(
                name: "IX_MuscleTranslatedInfo_LanguageID",
                table: "MuscleTranslatedInfo");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "MuscleTranslatedInfo");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MuscleTranslatedInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
