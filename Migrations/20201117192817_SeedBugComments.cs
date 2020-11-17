using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class SeedBugComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BugComments",
                columns: new[] { "BugCommentId", "BugId", "Comment", "CommentDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "This code simply stores the seed data", new DateTime(2020, 11, 18, 0, 58, 17, 150, DateTimeKind.Local).AddTicks(5541), 2 },
                    { 2, 2, "This code is a basic HTML template", new DateTime(2020, 11, 18, 0, 58, 17, 150, DateTimeKind.Local).AddTicks(6342), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 0, 58, 17, 149, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 0, 58, 17, 150, DateTimeKind.Local).AddTicks(1371));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 17, 23, 36, 59, 375, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 17, 23, 36, 59, 376, DateTimeKind.Local).AddTicks(5434));
        }
    }
}
