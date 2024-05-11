using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.CheckConstraint("CK_Project_StartDate_EndDate", "StartDate < EndDate");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.CheckConstraint("CK_Salary_Amount", "Amount > 0");
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1L, "Hanoi", "Software Development" },
                    { 2L, "Danang", "Finance" },
                    { 3L, "Hanoi", "Accountant" },
                    { 4L, "HCM", "Human Resource" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1L, "Description for Project 1", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 1", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New" },
                    { 2L, "Description for Project 2", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 2", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress" },
                    { 3L, "Description for Project 3", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 3", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DateOfBirth", "DepartmentId", "Email", "JoinDate", "Name", "Phone" },
                values: new object[,]
                {
                    { 1L, "Address 1", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "email1@example.com", new DateTime(2000, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 1", "1234567890" },
                    { 2L, "Address 2", new DateTime(1991, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "email2@example.com", new DateTime(2002, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 2", "1234567891" },
                    { 3L, "Address 3", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "email3@example.com", new DateTime(2003, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 3", "1234567892" },
                    { 4L, "Address 4", new DateTime(1993, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "email4@example.com", new DateTime(2004, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 4", "1234567893" },
                    { 5L, "Address 5", new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "email5@example.com", new DateTime(2005, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 5", "1234567894" },
                    { 6L, "Address 6", new DateTime(1995, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "email6@example.com", new DateTime(2006, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 6", "1234567895" },
                    { 7L, "Address 7", new DateTime(1996, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "email7@example.com", new DateTime(2007, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 7", "1234567896" },
                    { 8L, "Address 8", new DateTime(1997, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "email8@example.com", new DateTime(2008, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 8", "1234567897" },
                    { 9L, "Address 9", new DateTime(1998, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "email9@example.com", new DateTime(2009, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 9", "1234567898" },
                    { 10L, "Address 10", new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "email10@example.com", new DateTime(2010, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 10", "1234567899" },
                    { 11L, "Address 11", new DateTime(2000, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "email11@example.com", new DateTime(2011, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 11", "1234567800" },
                    { 12L, "Address 12", new DateTime(2001, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "email12@example.com", new DateTime(2012, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 12", "1234567801" },
                    { 13L, "Address 13", new DateTime(2002, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "email13@example.com", new DateTime(2013, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 13", "1234567802" },
                    { 14L, "Address 14", new DateTime(2003, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "email14@example.com", new DateTime(2014, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 14", "1234567803" },
                    { 15L, "Address 15", new DateTime(2004, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "email15@example.com", new DateTime(2015, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee 15", "1234567804" }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Amount", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 50000m, 1L },
                    { 2, 55000m, 3L },
                    { 3, 58000m, 4L },
                    { 4, 52000m, 5L },
                    { 5, 53000m, 6L },
                    { 6, 56000m, 7L },
                    { 7, 57000m, 8L },
                    { 8, 54000m, 9L },
                    { 9, 59000m, 10L },
                    { 10, 62000m, 11L },
                    { 11, 61000m, 12L },
                    { 12, 57000m, 13L },
                    { 13, 56000m, 14L },
                    { 14, 60000m, 15L },
                    { 15, 60000m, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}