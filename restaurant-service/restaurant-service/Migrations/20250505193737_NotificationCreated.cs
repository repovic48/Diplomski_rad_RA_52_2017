using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant_service.Migrations
{
    /// <inheritdoc />
    public partial class NotificationCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    date_of_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    restaurant_email = table.Column<string>(type: "text", nullable: false),
                    Restaurantid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Restaurants_Restaurantid",
                        column: x => x.Restaurantid,
                        principalTable: "Restaurants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Restaurantid",
                table: "Notifications",
                column: "Restaurantid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
