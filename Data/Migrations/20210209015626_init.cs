using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TARSTestJosue.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Product = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Company = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Version = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    StatusColor = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    DateBuy = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DolarRealBuy = table.Column<decimal>(type: "numeric", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    URL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Requirement = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Extra = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<int>(type: "integer", nullable: false),
                    URL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Store = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Price_Currency = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_item_tb_component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "tb_component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_item_ComponentId",
                table: "tb_item",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_item");

            migrationBuilder.DropTable(
                name: "tb_component");
        }
    }
}
