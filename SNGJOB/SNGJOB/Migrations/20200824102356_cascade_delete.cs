using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGJOB.Migrations
{
    public partial class cascade_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_details_users_ud_id",
                table: "user_details");

            migrationBuilder.DropIndex(
                name: "IX_user_details_ud_id",
                table: "user_details");

            migrationBuilder.CreateIndex(
                name: "IX_user_details_ud_id",
                table: "user_details",
                column: "ud_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_details_users_ud_id",
                table: "user_details",
                column: "ud_id",
                principalTable: "users",
                principalColumn: "us_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_details_users_ud_id",
                table: "user_details");

            migrationBuilder.DropIndex(
                name: "IX_user_details_ud_id",
                table: "user_details");

            migrationBuilder.CreateIndex(
                name: "IX_user_details_ud_id",
                table: "user_details",
                column: "ud_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_details_users_ud_id",
                table: "user_details",
                column: "ud_id",
                principalTable: "users",
                principalColumn: "us_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
