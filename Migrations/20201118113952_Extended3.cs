using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Extended3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 9, 52, 20, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 9, 52, 20, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 9, 52, 13, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 9, 52, 14, DateTimeKind.Local).AddTicks(6920));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 7, 57, 32, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 7, 57, 32, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 7, 57, 27, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 7, 57, 28, DateTimeKind.Local).AddTicks(59));
        }
    }
}
