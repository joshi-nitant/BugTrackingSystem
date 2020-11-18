using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Extended4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "BugComments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BugComments_ApplicationUserId",
                table: "BugComments",
                newName: "IX_BugComments_UserId");

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 12, 54, 268, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2020, 11, 18, 17, 12, 54, 268, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 12, 54, 264, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2020, 11, 18, 17, 12, 54, 265, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_UserId",
                table: "BugComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_UserId",
                table: "BugComments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BugComments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BugComments_UserId",
                table: "BugComments",
                newName: "IX_BugComments_ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
