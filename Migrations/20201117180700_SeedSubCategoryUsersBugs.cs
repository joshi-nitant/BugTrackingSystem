using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class SeedSubCategoryUsersBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Bugs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCatID", "CategoryId", "SubCatName" },
                values: new object[,]
                {
                    { 1, 1, "C#" },
                    { 2, 2, "HTML" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DepartmentId", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "user1@gmail.com", "user1", "user1" },
                    { 2, 1, "user2@gmail.com", "user2", "user2" },
                    { 3, 2, "user3@gmail.com", "user3", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "BugId", "Code", "Description", "IssueDate", "SubCategoryId", "Title", "UserId" },
                values: new object[] { 1, "modelBuilder.Entity<User>().HasData(\r\n                            users\r\n                        ); ", "What does this specify. I dont understand why this is needed", new DateTime(2020, 11, 17, 23, 36, 59, 375, DateTimeKind.Local).AddTicks(2654), 1, "Issue with modelBuilder", 1 });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "BugId", "Code", "Description", "IssueDate", "SubCategoryId", "Title", "UserId" },
                values: new object[] { 2, "<html>\r\n                            <head> <title> Hello World</title> </head>\r\n                         </html>", "Why we write this. I dont understand why this is needed", new DateTime(2020, 11, 17, 23, 36, 59, 376, DateTimeKind.Local).AddTicks(5434), 2, "Not understanding the code", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "BugId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCatID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCatID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Bugs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
