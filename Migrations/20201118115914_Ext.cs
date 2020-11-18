using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Ext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_UserId",
                table: "BugComments");

            migrationBuilder.DeleteData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BugComments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BugComments_UserId",
                table: "BugComments",
                newName: "IX_BugComments_ApplicationUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Bugs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Bugs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "BugId", "ApplicationUserId", "Code", "Description", "IssueDate", "SubCategoryId", "Title" },
                values: new object[] { 1, "5c0dbaa8-edb8-4adc-b7c8-2b669c572111", "modelBuilder.Entity<User>().HasData(\r\n                            users\r\n                        ); ", "What does this specify. I dont understand why this is needed", new DateTime(2020, 11, 18, 17, 12, 54, 264, DateTimeKind.Local).AddTicks(1130), 1, "Issue with modelBuilder" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "BugId", "ApplicationUserId", "Code", "Description", "IssueDate", "SubCategoryId", "Title" },
                values: new object[] { 2, "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3", "<html>\r\n                            <head> <title> Hello World</title> </head>\r\n                         </html>", "Why we write this. I dont understand why this is needed", new DateTime(2020, 11, 18, 17, 12, 54, 265, DateTimeKind.Local).AddTicks(780), 2, "Not understanding the code" });

            migrationBuilder.InsertData(
                table: "BugComments",
                columns: new[] { "BugCommentId", "BugId", "Comment", "CommentDate", "UserId" },
                values: new object[] { 1, 1, "This code simply stores the seed data", new DateTime(2020, 11, 18, 17, 12, 54, 268, DateTimeKind.Local).AddTicks(8631), "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3" });

            migrationBuilder.InsertData(
                table: "BugComments",
                columns: new[] { "BugCommentId", "BugId", "Comment", "CommentDate", "UserId" },
                values: new object[] { 2, 2, "This code is a basic HTML template", new DateTime(2020, 11, 18, 17, 12, 54, 268, DateTimeKind.Local).AddTicks(9495), "5c0dbaa8 - edb8 - 4adc - b7c8 - 2b669c572111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_UserId",
                table: "BugComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
