using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models.DTO
{
    public class AddToFavoriteDto
    {
        public Recipe SelectedRecipe { get; set; }
        public Guid RecipeId { get; set; }
    }
}
