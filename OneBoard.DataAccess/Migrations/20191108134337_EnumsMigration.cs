using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBoard.DataAccess.Migrations
{
    public partial class EnumsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChartTypeName",
                table: "ChartTypes");

            migrationBuilder.AlterColumn<int>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharTypeName",
                table: "ChartTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharTypeName",
                table: "ChartTypes");

            migrationBuilder.AlterColumn<string>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ChartTypeName",
                table: "ChartTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
