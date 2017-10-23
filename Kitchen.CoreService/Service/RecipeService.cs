using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kitchen.CommonModel.Container;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.Model;
using Kitchen.CommonModel.ViewModel.Recipe;
using Kitchen.Repository.Repository;

namespace Kitchen.CoreService.Service
{
    public class RecipeService : ICoreService<RecipeViewModel>
    {
        private RecipeRepository recipeRepository;

        public RecipeService(RecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        public async Task<ServiceResultModel<RecipeViewModel>> AddAsync(RecipeViewModel model)
        {
            var result = new ServiceResultModel<RecipeViewModel>();
            try
            {
                var recipe = new Recipe
                {
                    
                };
                await recipeRepository.InsertAsync(recipe);
                if (recipe.Id == -1)
                    throw new Exception();
                //add mappings for automapper
                result.Item = Mapper.Map<Recipe, RecipeViewModel>(recipe);
                result.Code = recipe.Id;
                return result;
            }
            catch (Exception ex)
            {
                result.Item = null;
                result.Message = ex.Message;
                result.Code = -1;
                Console.WriteLine(ex);
                return result;
            }
        }

        public Task<ServiceResultModel<RecipeViewModel>> UpdateAsync(RecipeViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResultModel<RecipeViewModel>> DeleteAsync(RecipeViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<RecipeViewModel>> GetDefaultContainer(int start, SearchCriteria criteria, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<RecipeViewModel>> SearchByKeyContainer(int start, SearchCriteria criteria, string key, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public BasicPaginationResultContainer<RecipeViewModel> GetEmptyContainer()
        {
            throw new NotImplementedException();
        }
    }
}
