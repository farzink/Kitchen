using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
