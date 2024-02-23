using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class add_mig_removedlinefromcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactCategoryID",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts",
                column: "ContactCategoryID",
                principalTable: "ContactCategories",
                principalColumn: "ContactCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactCategoryID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts",
                column: "ContactCategoryID",
                principalTable: "ContactCategories",
                principalColumn: "ContactCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
