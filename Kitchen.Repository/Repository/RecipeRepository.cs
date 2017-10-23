using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Kitchen.Data;

namespace Kitchen.Repository.Repository
{
    public class RecipeRepository : SqlRepository<MainContext, Recipe>
    {
        public RecipeRepository(MainContext context) : base(context)
        {
        }
    }
}

