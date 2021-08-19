using Food.Models;
using Food.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Data
{
    public class ApplicationDbContext : IdentityDbContext<FoodApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<RecipeInFavourites> RecipeInFavourites { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //ova e da se dodade nov 
            builder.Entity<Recipe>()
                .Property(z => z.id)
                .ValueGeneratedOnAdd();

            builder.Entity<Favourite>()
                .Property(z => z.id)
                .ValueGeneratedOnAdd();

            //kompoziten kluc od dvata 
            builder.Entity<RecipeInFavourites>()
               .HasKey(z => new { z.RecipeId, z.FavoutiteId });

            builder.Entity<RecipeInFavourites>()
                .HasOne(z => z.Recipe)
                .WithMany(z => z.RecipeInFavourites)
                .HasForeignKey(z => z.FavoutiteId);
            builder.Entity<RecipeInFavourites>()
                .HasOne(z => z.Favourite)
                .WithMany(z => z.RecipeInFavourites)
                .HasForeignKey(z => z.RecipeId);
            //one to one
            builder.Entity<Favourite>()
                .HasOne<FoodApplicationUser>(z => z.Owner)
                .WithOne(z => z.FavouriteCart)
                .HasForeignKey<Favourite>(z => z.OwnerId);
        }

        }
    }
