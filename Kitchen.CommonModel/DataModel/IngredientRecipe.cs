using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class IngredientRecipe: BaseIntEntity
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
