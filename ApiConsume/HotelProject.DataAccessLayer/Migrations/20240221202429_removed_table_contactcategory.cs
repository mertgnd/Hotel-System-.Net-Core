using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class removed_table_contactcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactCategories");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactCategoryID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactCategoryID",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactCategoryID",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactCategories",
                columns: table => new
                {
                    ContactCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCategories", x => x.ContactCategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCategoryID",
                table: "Contacts",
                column: "ContactCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactCategories_ContactCategoryID",
                table: "Contacts",
                column: "ContactCategoryID",
                principalTable: "ContactCategories",
                principalColumn: "ContactCategoryID");
        }
    }
}
