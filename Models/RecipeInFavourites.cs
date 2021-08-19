using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class RecipeInFavourites
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid FavoutiteId { get; set; }
        public Favourite Favourite { get; set; }


    }
}
