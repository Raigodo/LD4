using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LD4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seedingstudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 13, 19, 48, 30, 621, DateTimeKind.Local).AddTicks(7969), new DateTime(2024, 12, 13, 18, 18, 30, 621, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 14, 20, 18, 30, 621, DateTimeKind.Local).AddTicks(7974), new DateTime(2024, 12, 14, 18, 18, 30, 621, DateTimeKind.Local).AddTicks(7972) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 15, 19, 48, 30, 621, DateTimeKind.Local).AddTicks(7978), new DateTime(2024, 12, 15, 18, 18, 30, 621, DateTimeKind.Local).AddTicks(7977) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 16, 20, 18, 30, 621, DateTimeKind.Local).AddTicks(7982), new DateTime(2024, 12, 16, 18, 18, 30, 621, DateTimeKind.Local).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 17, 19, 48, 30, 621, DateTimeKind.Local).AddTicks(7985), new DateTime(2024, 12, 17, 18, 18, 30, 621, DateTimeKind.Local).AddTicks(7984) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "pirmais" },
                    { 2, "otrais" },
                    { 3, "tresais" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 13, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8094), new DateTime(2024, 12, 13, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 14, 20, 0, 44, 723, DateTimeKind.Local).AddTicks(8100), new DateTime(2024, 12, 14, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 15, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8104), new DateTime(2024, 12, 15, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 16, 20, 0, 44, 723, DateTimeKind.Local).AddTicks(8107), new DateTime(2024, 12, 16, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndingAt", "StartingAt" },
                values: new object[] { new DateTime(2024, 12, 17, 19, 30, 44, 723, DateTimeKind.Local).AddTicks(8111), new DateTime(2024, 12, 17, 18, 0, 44, 723, DateTimeKind.Local).AddTicks(8109) });
        }
    }
}
