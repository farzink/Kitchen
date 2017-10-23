using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Kitchen.Data;

namespace Kitchen.Repository.Repository
{
    public class IngredientRepository : SqlRepository<MainContext, Ingredient>
    {
        public IngredientRepository(MainContext context) : base(context)
        {
        }
    }
}
