using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGJOB.Migrations
{
    public partial class verifyEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "email_confirm_tokens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ud_id = table.Column<Guid>(nullable: true),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_confirm_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_email_confirm_tokens_users_ud_id",
                        column: x => x.ud_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_confirm_tokens_ud_id",
                table: "email_confirm_tokens",
                column: "ud_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_confirm_tokens");
        }
    }
}
