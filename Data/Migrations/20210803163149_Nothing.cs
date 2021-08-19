using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Data.Migrations
{
    public partial class Nothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCarts_Tickets_FavoutiteId",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCarts_ShoppingCarts_RecipeId",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "TicketInShoppingCarts",
                newName: "RecipeInFavourites");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "Favourites");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInShoppingCarts_FavoutiteId",
                table: "RecipeInFavourites",
                newName: "IX_RecipeInFavourites_FavoutiteId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_OwnerId",
                table: "Favourites",
                newName: "IX_Favourites_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeInFavourites",
                table: "RecipeInFavourites",
                columns: new[] { "RecipeId", "FavoutiteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_OwnerId",
                table: "Favourites",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeInFavourites_Recipes_FavoutiteId",
                table: "RecipeInFavourites",
                column: "FavoutiteId",
                principalTable: "Recipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeInFavourites_Favourites_RecipeId",
                table: "RecipeInFavourites",
                column: "RecipeId",
                principalTable: "Favourites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_OwnerId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeInFavourites_Recipes_FavoutiteId",
                table: "RecipeInFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeInFavourites_Favourites_RecipeId",
                table: "RecipeInFavourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeInFavourites",
                table: "RecipeInFavourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "RecipeInFavourites",
                newName: "TicketInShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeInFavourites_FavoutiteId",
                table: "TicketInShoppingCarts",
                newName: "IX_TicketInShoppingCarts_FavoutiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_OwnerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts",
                columns: new[] { "RecipeId", "FavoutiteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCarts_Tickets_FavoutiteId",
                table: "TicketInShoppingCarts",
                column: "FavoutiteId",
                principalTable: "Tickets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCarts_ShoppingCarts_RecipeId",
                table: "TicketInShoppingCarts",
                column: "RecipeId",
                principalTable: "ShoppingCarts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
