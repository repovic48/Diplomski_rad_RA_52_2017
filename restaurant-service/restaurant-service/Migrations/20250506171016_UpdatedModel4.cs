using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant_service.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Restaurants_Restaurantid",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "restaurant_email",
                table: "Notifications",
                newName: "restaurant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Restaurants_Restaurantid",
                table: "Notifications",
                column: "Restaurantid",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Restaurants_Restaurantid",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "restaurant_id",
                table: "Notifications",
                newName: "restaurant_email");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Restaurants_Restaurantid",
                table: "Notifications",
                column: "Restaurantid",
                principalTable: "Restaurants",
                principalColumn: "id");
        }
    }
}
