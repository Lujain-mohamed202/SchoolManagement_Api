
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class lastt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_students_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_subjects_SubjectId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_SubjectId",
                table: "enrollments",
                newName: "IX_enrollments_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId_SubjectId",
                table: "enrollments",
                newName: "IX_enrollments_StudentId_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_students_StudentId",
                table: "enrollments",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_subjects_SubjectId",
                table: "enrollments",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_students_StudentId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_subjects_SubjectId",
                table: "enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments");

            migrationBuilder.RenameTable(
                name: "enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_SubjectId",
                table: "Enrollment",
                newName: "IX_Enrollment_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_StudentId_SubjectId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_students_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_subjects_SubjectId",
                table: "Enrollment",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
