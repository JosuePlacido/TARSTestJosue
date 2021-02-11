using Microsoft.EntityFrameworkCore.Migrations;

namespace TARSTestJosue.Data.Migrations
{
    public partial class fixconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusColor",
                table: "tb_component",
                newName: "Status_Color");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "tb_component",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Status_Color",
                table: "tb_component",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(7)",
                oldMaxLength: 7,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Color",
                table: "tb_component",
                newName: "StatusColor");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "tb_component",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusColor",
                table: "tb_component",
                type: "varchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
