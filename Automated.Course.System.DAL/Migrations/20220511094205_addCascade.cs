using Microsoft.EntityFrameworkCore.Migrations;

namespace Automated.Course.System.DAL.Migrations
{
    public partial class addCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answers_task",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_course",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "fk_answers_task",
                table: "answers",
                column: "task_id",
                principalTable: "tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_course",
                table: "tasks",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answers_task",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_course",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "fk_answers_task",
                table: "answers",
                column: "task_id",
                principalTable: "tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
