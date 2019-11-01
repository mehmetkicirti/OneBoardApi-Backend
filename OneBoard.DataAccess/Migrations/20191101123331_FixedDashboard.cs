using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBoard.DataAccess.Migrations
{
    public partial class FixedDashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UserID",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_UserID",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Dashboards");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_CreatorID",
                table: "Dashboards",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_CreatorID",
                table: "Dashboards",
                column: "CreatorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_CreatorID",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_CreatorID",
                table: "Dashboards");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "Users",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Dashboards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserID",
                table: "Dashboards",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UserID",
                table: "Dashboards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
