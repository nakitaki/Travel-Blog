using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogTravel.Migrations
{
    public partial class NewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_AspNetUsers_AppUserID",
                table: "Adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_AspNetUsers_AppUserID",
                table: "Holidays");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Holidays",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_AppUserID",
                table: "Holidays",
                newName: "IX_Holidays_AppUserId");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Adventures",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adventures_AppUserID",
                table: "Adventures",
                newName: "IX_Adventures_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventures_AspNetUsers_AppUserId",
                table: "Adventures",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_AspNetUsers_AppUserId",
                table: "Holidays",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_AspNetUsers_AppUserId",
                table: "Adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_AspNetUsers_AppUserId",
                table: "Holidays");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Holidays",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_AppUserId",
                table: "Holidays",
                newName: "IX_Holidays_AppUserID");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Adventures",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Adventures_AppUserId",
                table: "Adventures",
                newName: "IX_Adventures_AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventures_AspNetUsers_AppUserID",
                table: "Adventures",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_AspNetUsers_AppUserID",
                table: "Holidays",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
