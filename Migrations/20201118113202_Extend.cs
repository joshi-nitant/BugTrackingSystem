using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Extend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_EmployeeId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_OwnerId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_OwnerId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_BugComments_EmployeeId",
                table: "BugComments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BugComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BugComments");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BugComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CommentDate" },
                values: new object[] { "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3", new DateTime(2020, 11, 18, 17, 2, 1, 977, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "CommentDate" },
                values: new object[] { "5c0dbaa8 - edb8 - 4adc - b7c8 - 2b669c572111", new DateTime(2020, 11, 18, 17, 2, 1, 977, DateTimeKind.Local).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "IssueDate" },
                values: new object[] { "5c0dbaa8-edb8-4adc-b7c8-2b669c572111", new DateTime(2020, 11, 18, 17, 2, 1, 971, DateTimeKind.Local).AddTicks(5688) });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "IssueDate" },
                values: new object[] { "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3", new DateTime(2020, 11, 18, 17, 2, 1, 972, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_ApplicationUserId",
                table: "Bugs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BugComments_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_ApplicationUserId",
                table: "Bugs",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_ApplicationUserId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_ApplicationUserId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_BugComments_ApplicationUserId",
                table: "BugComments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BugComments");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "BugComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BugComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 16, 55, 53, 101, DateTimeKind.Local).AddTicks(1728), "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3" });

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 16, 55, 53, 101, DateTimeKind.Local).AddTicks(2715), "5c0dbaa8 - edb8 - 4adc - b7c8 - 2b669c572111" });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                columns: new[] { "IssueDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 16, 55, 53, 95, DateTimeKind.Local).AddTicks(8746), "5c0dbaa8-edb8-4adc-b7c8-2b669c572111" });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                columns: new[] { "IssueDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 16, 55, 53, 96, DateTimeKind.Local).AddTicks(9790), "bc363de9 - 8494 - 44c3 - b25c - 234e056798d3" });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_OwnerId",
                table: "Bugs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BugComments_EmployeeId",
                table: "BugComments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_EmployeeId",
                table: "BugComments",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_OwnerId",
                table: "Bugs",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
