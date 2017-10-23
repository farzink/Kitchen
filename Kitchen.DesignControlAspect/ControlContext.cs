using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Kitchen.DesignControlAspect
{
    
    public class ControlContext : IdentityDbContext<ApplicationUser>
    {
        public ControlContext(DbContextOptions<ControlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            

            builder.Entity<DishCategoryRecipe>()
                .HasOne(e=>e.Recipe)
                .WithMany(e=>e.DishCategories)
                .HasForeignKey(e=>e.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DishCategoryRecipe>()
                .HasOne(e => e.DishCategory)
                .WithMany(e => e.Recipes)
                .HasForeignKey(e => e.DishCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IngredientRecipe>()
                .HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IngredientRecipe>()
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.Recipes)
                .HasForeignKey(e => e.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Item>()
            //    .HasMany(e => e.WishListItems)
            //    .WithOne(e => e.Item)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Profile>()
            //    .HasMany(e => e.Orders)
            //    .WithOne(e => e.Profile)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Order>()
            //   .HasMany(e => e.OrderDetails)
            //   .WithOne(e => e.Order)
            //   .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Profile>()
            //   .HasMany(e => e.AuctionBids)
            //   .WithOne(e => e.Profile)
            //   .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Auction>()
            //   .HasMany(e => e.AuctionBids)
            //   .WithOne(e => e.Auction)
            //   .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<Checkout>()
            //    .HasOne(e => e.Order)
            //    .WithOne(e => e.Checkout)
            //    .IsRequired(false);

            //builder.Entity<Checkout>()
            //    .HasOne(e => e.Payment)
            //    .WithOne(e => e.Checkout)
            //    .IsRequired(false);



        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }        
        public DbSet<Recipe> Recipes { get; set; }
    }
}
