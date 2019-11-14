using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBoard.DataAccess.Migrations
{
    public partial class Converttostringfromenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharTypeName",
                table: "ChartTypes");

            migrationBuilder.AlterColumn<string>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ChartTypeName",
                table: "ChartTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChartTypeName",
                table: "ChartTypes");

            migrationBuilder.AlterColumn<string>(
                name: "WidgetTypeName",
                table: "WidgetTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharTypeName",
                table: "ChartTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
