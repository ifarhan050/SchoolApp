using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAttendenceFeature.Migrations
{
    /// <inheritdoc />
    public partial class addStudentinfostables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentStatus",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nic",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantAddress",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentEducationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviouslyAttended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForLeaving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEducationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEducationInfo_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEmergencyContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationShipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEmergencyContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEmergencyContactInfo_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMedicalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hasDiabetes = table.Column<bool>(type: "bit", nullable: false),
                    hasPhysicalDisability = table.Column<bool>(type: "bit", nullable: false),
                    hasHearingImpairment = table.Column<bool>(type: "bit", nullable: false),
                    hasVisualImpairment = table.Column<bool>(type: "bit", nullable: false),
                    hasAllergy = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMedicalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMedicalInfo_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEducationInfo_StudentId",
                table: "StudentEducationInfo",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmergencyContactInfo_StudentId",
                table: "StudentEmergencyContactInfo",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMedicalInfo_StudentId",
                table: "StudentMedicalInfo",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentEducationInfo");

            migrationBuilder.DropTable(
                name: "StudentEmergencyContactInfo");

            migrationBuilder.DropTable(
                name: "StudentMedicalInfo");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Nic",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PermenantAddress",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "Student");
        }
    }
}
