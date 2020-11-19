using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class cascadedadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_Bugs_BugId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_Bugs_BugId",
                table: "BugComments",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "BugId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BugComments_Bugs_BugId",
                table: "BugComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_AspNetUsers_ApplicationUserId",
                table: "BugComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BugComments_Bugs_BugId",
                table: "BugComments",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "BugId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
