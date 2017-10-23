using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class DishCategory: BaseIntEntity
    {
        public DishCategory()
        {
            Recipes = new HashSet<DishCategoryRecipe>();
        }
        public string Title { get; set; }
        public virtual ICollection<DishCategoryRecipe> Recipes { get; set; }
    }
}
