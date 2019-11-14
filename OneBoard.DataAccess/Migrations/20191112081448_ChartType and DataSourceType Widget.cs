using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBoard.DataAccess.Migrations
{
    public partial class ChartTypeandDataSourceTypeWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CharTypeName",
                table: "ChartTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataSourceTypeName",
                table: "DataSourceTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CharTypeName",
                table: "ChartTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
