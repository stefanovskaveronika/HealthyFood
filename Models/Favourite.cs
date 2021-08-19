using Food.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class Favourite
    {
        public Guid id { get; set; }       
        public string OwnerId { get; set; }
        public virtual FoodApplicationUser Owner { get; set; }
        public virtual ICollection<RecipeInFavourites> RecipeInFavourites { get; set; }
    }


}
