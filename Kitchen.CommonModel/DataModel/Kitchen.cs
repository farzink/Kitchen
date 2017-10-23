using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class Kitchen: BaseIntEntity
    {
        public Kitchen()
        {
            Recipes = new HashSet<Recipe>();
        }
        public string Name { get; set; }
        public string  Logo { get; set; }
        public int NumberOfRecipes { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
