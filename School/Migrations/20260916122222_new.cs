using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "asdfg", "science" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacheriD", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber", "salary" },
                values: new object[] { 1, 1, "llll@345", "lujain", "mohamed", "011234567", 12m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacheriD",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
