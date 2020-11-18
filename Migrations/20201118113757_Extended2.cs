using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Extended2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 6, 0, 62, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 6, 0, 62, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 6, 0, 56, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 6, 0, 57, DateTimeKind.Local).AddTicks(5636));
        }
    }
}
