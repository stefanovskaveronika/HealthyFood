using Food.Data;
using Food.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Food.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Food.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly UserManager<FoodApplicationUser> userManager;
        private readonly SignInManager<FoodApplicationUser> signInManager;
        private readonly ApplicationDbContext context;

        public FavouritesController(UserManager<FoodApplicationUser> userManager, SignInManager<FoodApplicationUser> signInManager, ApplicationDbContext context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context=context;

    }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await context.Users                
                .Where(z => z.Id == userId)
                .Include(z => z.FavouriteCart)
                .Include(z=>z.FavouriteCart.RecipeInFavourites)
                .Include("FavouriteCart.RecipeInFavourites.Recipe")             
                .FirstOrDefaultAsync();

            var userFavouriteCart = loggedInUser.FavouriteCart;

            //var allRecipes = userFavouriteCart.RecipeInFavourites.Select(z => z.Recipe).ToList();
            FavouriteDto FavouriteDtoItem = new FavouriteDto
            {
                RecipeInFavouritess = userFavouriteCart.RecipeInFavourites.ToList()
            };

            return View(FavouriteDtoItem);
        }
        public async Task<IActionResult> DeleteFromFavourites(Guid favoutiteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await context.Users
                .Where(z => z.Id == userId)
                .Include(z => z.FavouriteCart)
                .Include(z => z.FavouriteCart.RecipeInFavourites)
                .Include("FavouriteCart.RecipeInFavourites.Recipe")
                .FirstOrDefaultAsync();

            var userFavouriteCart = loggedInUser.FavouriteCart;
            var recipeToDelete=userFavouriteCart.RecipeInFavourites
                .Where(z => z.FavoutiteId == favoutiteId)
                .FirstOrDefault();

            userFavouriteCart.RecipeInFavourites.Remove(recipeToDelete);
            context.Update(userFavouriteCart);
            await context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Favourites");
        }

    }
}
