using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class DishCategoryRecipe: BaseIntEntity
    {
        public int DishCategoryId { get; set; }
        public DishCategory DishCategory { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
