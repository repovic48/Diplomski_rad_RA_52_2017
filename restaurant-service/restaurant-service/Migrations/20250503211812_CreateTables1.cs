using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant_service.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    verification_code = table.Column<int>(type: "integer", nullable: false),
                    account_active = table.Column<bool>(type: "boolean", nullable: false),
                    account_suspended = table.Column<bool>(type: "boolean", nullable: false),
                    postal_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    restaurant_id = table.Column<string>(type: "text", nullable: false),
                    available = table.Column<bool>(type: "boolean", nullable: false),
                    discount = table.Column<int>(type: "integer", nullable: false),
                    Restaurantid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_Foods_Restaurants_Restaurantid",
                        column: x => x.Restaurantid,
                        principalTable: "Restaurants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Restaurantid",
                table: "Foods",
                column: "Restaurantid");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_email",
                table: "Restaurants",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
