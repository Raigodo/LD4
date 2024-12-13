using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LD4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    JoinedOn = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Topic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StartingAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndingAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "JoinedOn", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateOnly(2001, 7, 7), "Instruktors 1", "aaaaaaaaaaa" },
                    { 2, new DateOnly(2010, 12, 1), "Instruktors 2", "bbbbbbbbbbbbbbb" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "EndingAt", "InstructorId", "StartingAt", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 1, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "why 2 + 2 != 4" },
                    { 2, new DateTime(2024, 12, 13, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8094), 1, new DateTime(2024, 12, 13, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8062), "why 2 + 2 != 4" },
                    { 3, new DateTime(2024, 12, 14, 20, 0, 44, 723, DateTimeKind.Local).AddTicks(8100), 1, new DateTime(2024, 12, 14, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8097), "Introduction to Quantum Mechanics" },
                    { 4, new DateTime(2024, 12, 15, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8104), 1, new DateTime(2024, 12, 15, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8102), "Advanced Mathematics" },
                    { 5, new DateTime(2024, 12, 16, 20, 0, 44, 723, DateTimeKind.Local).AddTicks(8107), 2, new DateTime(2024, 12, 16, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8106), "Philosophy of Science" },
                    { 6, new DateTime(2024, 12, 17, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8111), 2, new DateTime(2024, 12, 17, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8109), "History of Art" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
