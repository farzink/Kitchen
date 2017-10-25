using Kitchen.CommonModel.ViewModel.DishCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Model
{
    public class ClientConfiguration
    {
        public IList<DishCategoryViewModel> DishCategories { get; set; }        
    }
}
