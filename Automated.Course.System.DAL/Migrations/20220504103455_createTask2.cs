using Microsoft.EntityFrameworkCore.Migrations;

namespace Automated.Course.System.DAL.Migrations
{
    public partial class createTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "tasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
