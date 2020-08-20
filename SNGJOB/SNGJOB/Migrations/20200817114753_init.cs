using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGJOB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    us_id = table.Column<Guid>(nullable: false),
                    us_type = table.Column<int>(nullable: false),
                    us_email = table.Column<string>(nullable: true),
                    us_phone = table.Column<string>(nullable: true),
                    us_password = table.Column<string>(nullable: true),
                    us_password_token = table.Column<string>(nullable: true),
                    us_creation_date = table.Column<long>(nullable: false),
                    us_update_date = table.Column<long>(nullable: false),
                    us_delete_timeout = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.us_id);
                });

            migrationBuilder.CreateTable(
                name: "allies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    as_user_id = table.Column<Guid>(nullable: true),
                    as_allie_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allies", x => x.id);
                    table.ForeignKey(
                        name: "FK_allies_users_as_allie_id",
                        column: x => x.as_allie_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_allies_users_as_user_id",
                        column: x => x.as_user_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cs_user_id = table.Column<Guid>(nullable: true),
                    cs_contact_id = table.Column<Guid>(nullable: false),
                    cs_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_users_cs_user_id",
                        column: x => x.cs_user_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_details",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ud_id = table.Column<Guid>(nullable: true),
                    ud_first_name = table.Column<string>(nullable: true),
                    ud_last_name = table.Column<string>(nullable: true),
                    ud_middle_name = table.Column<string>(nullable: true),
                    ud_full_name = table.Column<string>(nullable: true),
                    ud_address = table.Column<string>(nullable: true),
                    ud_emails = table.Column<string>(nullable: true),
                    ud_date_of_birth = table.Column<string>(nullable: true),
                    ud_interests = table.Column<byte>(nullable: false),
                    ud_photos = table.Column<string>(nullable: true),
                    ud_country = table.Column<string>(nullable: true),
                    ud_city = table.Column<string>(nullable: true),
                    ud_state = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_details_users_ud_id",
                        column: x => x.ud_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_educations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ue_user_id = table.Column<Guid>(nullable: true),
                    ue_name = table.Column<string>(nullable: true),
                    ue_type = table.Column<string>(nullable: true),
                    ue_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_educations_users_ue_user_id",
                        column: x => x.ue_user_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_employments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uet_user_id = table.Column<Guid>(nullable: true),
                    uet_name = table.Column<string>(nullable: true),
                    uet_area = table.Column<string>(nullable: true),
                    uet_address = table.Column<string>(nullable: true),
                    uet_phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_employments", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_employments_users_uet_user_id",
                        column: x => x.uet_user_id,
                        principalTable: "users",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_allies_as_allie_id",
                table: "allies",
                column: "as_allie_id");

            migrationBuilder.CreateIndex(
                name: "IX_allies_as_user_id",
                table: "allies",
                column: "as_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_cs_user_id",
                table: "contacts",
                column: "cs_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_details_ud_id",
                table: "user_details",
                column: "ud_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_educations_ue_user_id",
                table: "user_educations",
                column: "ue_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_employments_uet_user_id",
                table: "user_employments",
                column: "uet_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allies");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "user_details");

            migrationBuilder.DropTable(
                name: "user_educations");

            migrationBuilder.DropTable(
                name: "user_employments");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
