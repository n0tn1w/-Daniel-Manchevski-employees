using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SirmaBE.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesProjects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesProjects");
        }
    }
}
