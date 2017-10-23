using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class Ingredient: BaseIntEntity
    {
        public Ingredient()
        {
            Recipes = new HashSet<IngredientRecipe>();
        }
        public string Name { get; set; }
        public virtual ICollection<IngredientRecipe> Recipes { get; set; }
    }
}
