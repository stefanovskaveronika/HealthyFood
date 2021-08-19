using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favourites_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Meal = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    HowTo = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeInFavourites",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    FavoutiteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInFavourites", x => new { x.RecipeId, x.FavoutiteId });
                    table.ForeignKey(
                        name: "FK_RecipeInFavourites_Recipes_FavoutiteId",
                        column: x => x.FavoutiteId,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeInFavourites_Favourites_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Favourites",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_OwnerId",
                table: "Favourites",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInFavourites_FavoutiteId",
                table: "RecipeInFavourites",
                column: "FavoutiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeInFavourites");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
