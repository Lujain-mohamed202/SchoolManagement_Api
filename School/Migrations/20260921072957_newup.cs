using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class newup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Subject_SubjectId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teachers_TeacherId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "subjects");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "ClassRoom",
                newName: "classRooms");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_TeacherId",
                table: "subjects",
                newName: "IX_subjects_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Email",
                table: "students",
                newName: "IX_students_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassRoomId",
                table: "students",
                newName: "IX_students_ClassRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects",
                table: "subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classRooms",
                table: "classRooms",
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

            migrationBuilder.AddForeignKey(
                name: "FK_students_classRooms_ClassRoomId",
                table: "students",
                column: "ClassRoomId",
                principalTable: "classRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_Teachers_TeacherId",
                table: "subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacheriD",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_students_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_subjects_SubjectId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_students_classRooms_ClassRoomId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_Teachers_TeacherId",
                table: "subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects",
                table: "subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classRooms",
                table: "classRooms");

            migrationBuilder.RenameTable(
                name: "subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "classRooms",
                newName: "ClassRoom");

            migrationBuilder.RenameIndex(
                name: "IX_subjects_TeacherId",
                table: "Subject",
                newName: "IX_Subject_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_students_Email",
                table: "Student",
                newName: "IX_Student_Email");

            migrationBuilder.RenameIndex(
                name: "IX_students_ClassRoomId",
                table: "Student",
                newName: "IX_Student_ClassRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Subject_SubjectId",
                table: "Enrollment",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teachers_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacheriD",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
