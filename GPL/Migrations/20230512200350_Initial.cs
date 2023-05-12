using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Person",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PersonInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PersonInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Person_Tbl_PersonInfo",
                        column: x => x.Id,
                        principalTable: "Tbl_Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_PersonInfo");

            migrationBuilder.DropTable(
                name: "Tbl_Person");
        }
    }
}
