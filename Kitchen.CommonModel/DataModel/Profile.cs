using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.DataModel
{
    public class Profile : BaseIntEntity
    {
        public Profile()
        {
            Recipes = new HashSet<Recipe>();            
        }
        
        public string Name { get; set; }
        public string Logo { get; set; }
        public int NumberOfRecipes { get; set; }
        public string Description { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public virtual ICollection<Recipe> Recipes { get; set; }
        //public virtual ICollection<ItemCategory> ItemCategories { get; set; }
    }

}
