using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Food.Data;
using Food.Models;
using Food.Models.DTO;
using System.Security.Claims;

namespace Food.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ImageUrl,Name,Description,Rating,Meal,Time,HowTo,Ingredients,Calories")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.id = Guid.NewGuid();
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,ImageUrl,Name,Description,Rating,Meal,Time,HowTo,Ingredients,Calories")] Recipe recipe)
        {
            if (id != recipe.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(Guid id)
        {
            return _context.Recipes.Any(e => e.id == id);
        }
        public async Task<IActionResult> AddRecipeToFavorite(Guid? Nesto)
        {
            var recipe = await _context.Recipes.Where(z => z.id.Equals(Nesto)).FirstOrDefaultAsync();
            AddToFavoriteDto model = new AddToFavoriteDto
            {
                SelectedRecipe = recipe,
                RecipeId = (Guid)Nesto
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecipeToFavorite(AddToFavoriteDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userFavorite = await _context.Favourites.Where(z => z.OwnerId.Equals(userId)).FirstOrDefaultAsync();
            
            if (item.RecipeId!=null && userFavorite!=null)

            {
                var recipe = await _context.Recipes.Where(z => z.id.Equals(item.RecipeId)).FirstOrDefaultAsync();
                if(recipe!=null)
                {
                    RecipeInFavourites itemToAdd = new RecipeInFavourites()
                    {
                        Recipe = recipe,
                        RecipeId = recipe.id,
                        Favourite= userFavorite,
                        FavoutiteId=userFavorite.id,

                    };
                    _context.Add(itemToAdd);
                    await _context.SaveChangesAsync();                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        
        public async Task<IActionResult> Reminder()
        {
            return View();
        }

        public async Task<IActionResult> WithoutDairy()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        public async Task<IActionResult> GlutenFree()
        {
            return View(await _context.Recipes.ToListAsync());
        }
        public async Task<IActionResult> Diabetes()
        {
            return View(await _context.Recipes.ToListAsync());
        }
        public async Task<IActionResult> Breakfast()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        public async Task<IActionResult> Food()
        {
            return View(await _context.Recipes.ToListAsync());
        }
        public async Task<IActionResult> Dinner()
        {
            return View(await _context.Recipes.ToListAsync());
        }
    }
}
