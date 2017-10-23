using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.ViewModel;
using Kitchen.CommonModel.ViewModel.Ingredient;
using Kitchen.CommonModel.ViewModel.Recipe;

namespace Kitchen.CommonModel.AutoMapperConfiguration
{
    public class Config: AutoMapper.Profile
    {
        public Config()
        {
            CreateMap<Profile, ProfileViewModel>()
                .ReverseMap();
            CreateMap<Recipe, RecipeViewModel>()
                .ReverseMap();
            CreateMap<Ingredient, IngredientViewModel>()
                .ReverseMap();
            //CreateMap<Article, ArticleViewModel>()
            //        .ForMember(e => e.FullName, a => a.MapFrom(s => s.Profile.Firstname + " " + s.Profile.Lastname))
            //        .ForMember(e => e.Email, a => a.MapFrom(s => s.Profile.Email))
            //        .ReverseMap();
        }

    }
}
