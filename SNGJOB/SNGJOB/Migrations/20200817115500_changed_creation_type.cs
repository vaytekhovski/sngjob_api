using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGJOB.Migrations
{
    public partial class changed_creation_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "us_update_date",
                table: "users",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "us_delete_timeout",
                table: "users",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "us_creation_date",
                table: "users",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "us_update_date",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "us_delete_timeout",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "us_creation_date",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
