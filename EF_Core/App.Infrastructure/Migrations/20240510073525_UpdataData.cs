using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdataData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "IsWorking" },
                values: new object[,]
                {
                    { 1L, 1L, true },
                    { 5L, 1L, true },
                    { 6L, 1L, true },
                    { 8L, 1L, true },
                    { 11L, 1L, true },
                    { 1L, 2L, false },
                    { 6L, 2L, true },
                    { 9L, 2L, true },
                    { 12L, 2L, true },
                    { 1L, 3L, true },
                    { 7L, 3L, false },
                    { 10L, 3L, false },
                    { 13L, 3L, false },
                    { 14L, 3L, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 5L, 1L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 6L, 1L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 8L, 1L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 11L, 1L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 9L, 2L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 12L, 2L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 7L, 3L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 10L, 3L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 13L, 3L });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 14L, 3L });
        }
    }
}