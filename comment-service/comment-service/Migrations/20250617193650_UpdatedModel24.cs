using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comment_service.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "Comments",
                newName: "restaurant_id");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "author_email",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "comment_rating",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "restaurant_rating",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<string>>(
                name: "users_that_rated_comment",
                table: "Comments",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "author_email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "comment_rating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "restaurant_rating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "users_that_rated_comment",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "restaurant_id",
                table: "Comments",
                newName: "comment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "comment_id");
        }
    }
}
