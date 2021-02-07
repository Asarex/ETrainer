using Microsoft.EntityFrameworkCore.Migrations;

namespace ETrainerWebAPI.Migrations.AppDb
{
    public partial class AddRelationsBetweenModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "WorkoutSettingses",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Muscles",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Muscles",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MuscleExercise",
                columns: table => new
                {
                    MuscleID = table.Column<int>(nullable: false),
                    ExerciseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleExercise", x => new { x.MuscleID, x.ExerciseID });
                    table.ForeignKey(
                        name: "FK_MuscleExercise_Exercises_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleExercise_Muscles_MuscleID",
                        column: x => x.MuscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSettingsExcludeMuscles",
                columns: table => new
                {
                    WorkoutSettingsID = table.Column<int>(nullable: false),
                    MuscleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSettingsExcludeMuscles", x => new { x.WorkoutSettingsID, x.MuscleID });
                    table.ForeignKey(
                        name: "FK_WorkoutSettingsExcludeMuscles_Muscles_MuscleID",
                        column: x => x.MuscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSettingsExcludeMuscles_WorkoutSettingses_WorkoutSettingsID",
                        column: x => x.WorkoutSettingsID,
                        principalTable: "WorkoutSettingses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSettingsIncludeMuscles",
                columns: table => new
                {
                    WorkoutSettingsID = table.Column<int>(nullable: false),
                    MuscleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSettingsIncludeMuscles", x => new { x.WorkoutSettingsID, x.MuscleID });
                    table.ForeignKey(
                        name: "FK_WorkoutSettingsIncludeMuscles_Muscles_MuscleID",
                        column: x => x.MuscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSettingsIncludeMuscles_WorkoutSettingses_WorkoutSettingsID",
                        column: x => x.WorkoutSettingsID,
                        principalTable: "WorkoutSettingses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuscleExercise_ExerciseID",
                table: "MuscleExercise",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSettingsExcludeMuscles_MuscleID",
                table: "WorkoutSettingsExcludeMuscles",
                column: "MuscleID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSettingsIncludeMuscles_MuscleID",
                table: "WorkoutSettingsIncludeMuscles",
                column: "MuscleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuscleExercise");

            migrationBuilder.DropTable(
                name: "WorkoutSettingsExcludeMuscles");

            migrationBuilder.DropTable(
                name: "WorkoutSettingsIncludeMuscles");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "WorkoutSettingses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Muscles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Muscles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseID",
                table: "Muscles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID",
                table: "Muscles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID1",
                table: "Muscles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID2",
                table: "Muscles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSettingsID3",
                table: "Muscles",
                type: "int",
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
    }
}
