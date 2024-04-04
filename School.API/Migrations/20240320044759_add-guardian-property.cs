using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAttendenceFeature.Migrations
{
    /// <inheritdoc />
    public partial class addguardianproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Guardian_GuardianId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Student_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentGurdians");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_GuardianId",
                table: "StudentGurdians",
                newName: "IX_StudentGurdians_GuardianId");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Guardian",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGurdians",
                table: "StudentGurdians",
                columns: new[] { "StudentId", "GuardianId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGurdians_Guardian_GuardianId",
                table: "StudentGurdians",
                column: "GuardianId",
                principalTable: "Guardian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGurdians_Student_StudentId",
                table: "StudentGurdians",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGurdians_Guardian_GuardianId",
                table: "StudentGurdians");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGurdians_Student_StudentId",
                table: "StudentGurdians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGurdians",
                table: "StudentGurdians");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Guardian");

            migrationBuilder.RenameTable(
                name: "StudentGurdians",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGurdians_GuardianId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_GuardianId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "GuardianId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Guardian_GuardianId",
                table: "StudentCourses",
                column: "GuardianId",
                principalTable: "Guardian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Student_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
