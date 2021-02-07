using Microsoft.EntityFrameworkCore.Migrations;

namespace ETrainerWebAPI.Migrations.AppDb
{
    public partial class ChangingDbModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcludeExercises",
                table: "WorkoutSettingses");

            migrationBuilder.DropColumn(
                name: "ExcludeMuscleses",
                table: "WorkoutSettingses");

            migrationBuilder.DropColumn(
                name: "IncludeExercises",
                table: "WorkoutSettingses");

            migrationBuilder.DropColumn(
                name: "IncludeMuscleses",
                table: "WorkoutSettingses");

            migrationBuilder.DropColumn(
                name: "UseMuscles",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseID",
                table: "Muscles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID",
                table: "Muscles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID1",
                table: "Muscles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID2",
                table: "Muscles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID3",
                table: "Muscles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_ExerciseID",
                table: "Muscles",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_WorkoutSettingsID",
                table: "Muscles",
                column: "WorkoutSettingsID");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_WorkoutSettingsID1",
                table: "Muscles",
                column: "WorkoutSettingsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_WorkoutSettingsID2",
                table: "Muscles",
                column: "WorkoutSettingsID2");

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_WorkoutSettingsID3",
                table: "Muscles",
                column: "WorkoutSettingsID3");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_Exercises_ExerciseID",
                table: "Muscles",
                column: "ExerciseID",
                principalTable: "Exercises",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID",
                table: "Muscles",
                column: "WorkoutSettingsID",
                principalTable: "WorkoutSettingses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID1",
                table: "Muscles",
                column: "WorkoutSettingsID1",
                principalTable: "WorkoutSettingses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID2",
                table: "Muscles",
                column: "WorkoutSettingsID2",
                principalTable: "WorkoutSettingses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID3",
                table: "Muscles",
                column: "WorkoutSettingsID3",
                principalTable: "WorkoutSettingses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_Exercises_ExerciseID",
                table: "Muscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID",
                table: "Muscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID1",
                table: "Muscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID2",
                table: "Muscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_WorkoutSettingses_WorkoutSettingsID3",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_ExerciseID",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_WorkoutSettingsID",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_WorkoutSettingsID1",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_WorkoutSettingsID2",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_WorkoutSettingsID3",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "ExerciseID",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "WorkoutSettingsID",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "WorkoutSettingsID1",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "WorkoutSettingsID2",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "WorkoutSettingsID3",
                table: "Muscles");

            migrationBuilder.AddColumn<string>(
                name: "ExcludeExercises",
                table: "WorkoutSettingses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExcludeMuscleses",
                table: "WorkoutSettingses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncludeExercises",
                table: "WorkoutSettingses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncludeMuscleses",
                table: "WorkoutSettingses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UseMuscles",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
