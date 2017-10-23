using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;
using Kitchen.CommonModel.Enum;

namespace Kitchen.CommonModel.DataModel
{
    public class Recipe: BaseIntEntity
    {
        public Recipe()
        {
            DishCategories = new HashSet<DishCategoryRecipe>();
            Ingredients = new HashSet<IngredientRecipe>();
        }
        public string Name { get; set; }
        public string CokkingTime { get; set; }
        public int Serves { get; set; }
        public PreparationDifficultyTypes Difficulty { get; set; }
        public bool IsVegan { get; set; }
        public int Version { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }        
        public string Image { get; set; }
        public virtual ICollection<DishCategoryRecipe> DishCategories { get; set; }
        public virtual ICollection<IngredientRecipe> Ingredients { get; set; }
    }
}
