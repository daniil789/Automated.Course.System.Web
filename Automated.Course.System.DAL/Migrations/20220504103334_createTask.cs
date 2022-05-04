using Microsoft.EntityFrameworkCore.Migrations;

namespace Automated.Course.System.DAL.Migrations
{
    public partial class createTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_course",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "tasks",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_course_id",
                table: "tasks",
                newName: "IX_tasks_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_courses_CourseId",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "tasks",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_CourseId",
                table: "tasks",
                newName: "IX_tasks_course_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_course",
                table: "tasks",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
