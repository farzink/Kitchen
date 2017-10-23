using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.Enum;

namespace Kitchen.CommonModel.ViewModel.Recipe
{
    public class RecipeViewModel: BaseIntEntity
    {
        public string Name { get; set; }
        public string CokkingTime { get; set; }
        public int Serves { get; set; }
        public PreparationDifficultyTypes Difficulty { get; set; }
        public bool IsVegan { get; set; }
        public int Version { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Image { get; set; }
    }
}
