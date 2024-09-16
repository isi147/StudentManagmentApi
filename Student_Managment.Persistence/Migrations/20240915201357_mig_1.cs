using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student_Managment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GroupLesson",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    LessonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLesson", x => new { x.GroupsId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_GroupLesson_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupLesson_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LessonStudent",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonStudent", x => new { x.LessonsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LessonStudent_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LessonStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Number", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(1076), false, "Group A", 101, null },
                    { 2, new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(1079), false, "Group B", 102, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "MiddleName", "Name", "Number", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(3820), false, "Edward", "John", 1001, "Doe", null },
                    { 2, new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(3824), false, "Ann", "Jane", 1002, "Smith", null }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedDate", "ExamDate", "IsDeleted", "Mark", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 0, 13, 57, 8, DateTimeKind.Local).AddTicks(9525), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 85, 1, null },
                    { 2, new DateTime(2024, 9, 16, 0, 13, 57, 8, DateTimeKind.Local).AddTicks(9539), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 90, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Code", "CreatedDate", "ExamId", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "MAT", new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(2389), 1, false, "Mathematics", null },
                    { 2, "PHY", new DateTime(2024, 9, 16, 0, 13, 57, 9, DateTimeKind.Local).AddTicks(2393), 2, false, "Physics", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                table: "Exams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLesson_LessonsId",
                table: "GroupLesson",
                column: "LessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ExamId",
                table: "Lessons",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonStudent_StudentsId",
                table: "LessonStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLesson");

            migrationBuilder.DropTable(
                name: "LessonStudent");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
