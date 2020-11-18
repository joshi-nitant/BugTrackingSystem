using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_Users_UserId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_UserId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_BugComments_UserId",
                table: "BugComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BugComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "BugComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dept",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EmployeeId",
                table: "BugComments");

            migrationBuilder.DropColumn(
                name: "Dept",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bugs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BugComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 1, "BackendDeveloper" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 2, "FrontendDeveloper" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DepartmentId", "Email", "Password", "UserName" },
                values: new object[] { 1, 1, "user1@gmail.com", "user1", "user1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DepartmentId", "Email", "Password", "UserName" },
                values: new object[] { 2, 1, "user2@gmail.com", "user2", "user2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DepartmentId", "Email", "Password", "UserName" },
                values: new object[] { 3, 2, "user3@gmail.com", "user3", "user3" });

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 1,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 1, 54, 30, 799, DateTimeKind.Local).AddTicks(2492), 2 });

            migrationBuilder.UpdateData(
                table: "BugComments",
                keyColumn: "BugCommentId",
                keyValue: 2,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 1, 54, 30, 799, DateTimeKind.Local).AddTicks(3306), 1 });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1,
                columns: new[] { "IssueDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 1, 54, 30, 797, DateTimeKind.Local).AddTicks(9443), 1 });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2,
                columns: new[] { "IssueDate", "UserId" },
                values: new object[] { new DateTime(2020, 11, 18, 1, 54, 30, 798, DateTimeKind.Local).AddTicks(8484), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_UserId",
                table: "Bugs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BugComments_UserId",
                table: "BugComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_Users_UserId",
                table: "BugComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
