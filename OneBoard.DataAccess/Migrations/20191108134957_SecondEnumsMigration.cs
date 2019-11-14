using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBoard.DataAccess.Migrations
{
    public partial class SecondEnumsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
