using Microsoft.EntityFrameworkCore.Migrations;

namespace Automated.Course.System.DAL.Migrations
{
    public partial class addcreateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "create_user_id",
                table: "courses",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_user_id",
                table: "courses");
        }
    }
}
