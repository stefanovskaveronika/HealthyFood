using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models.Identity
{
    public class FoodApplicationUser : IdentityUser
    {
        public virtual Favourite FavouriteCart { get; set; }
    }
}
