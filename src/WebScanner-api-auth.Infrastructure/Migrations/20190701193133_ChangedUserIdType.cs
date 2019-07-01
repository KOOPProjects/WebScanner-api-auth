using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScanner_api_auth.Infrastructure.Migrations
{
    public partial class ChangedUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOrders",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserOrders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
