using Microsoft.EntityFrameworkCore.Migrations;

namespace ACManageR.Entities
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserID",
                table: "Requests",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Requests__UserID__34C8D9D1",
                table: "Requests",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Requests__UserID__34C8D9D1",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Requests");
        }
    }
}
