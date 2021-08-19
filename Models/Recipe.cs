using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class Recipe
    {
        public Guid id { get; set; }
        [Required]
        public String ImageUrl { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public int Rating { get; set; }
        public String Meal { get; set; }
        public int Time { get; set; }
        public String HowTo { get; set; }
        public String Ingredients { get; set; }
        public int Calories { get; set; }

        public virtual ICollection<RecipeInFavourites> RecipeInFavourites { get; set; }
      


    }
}
