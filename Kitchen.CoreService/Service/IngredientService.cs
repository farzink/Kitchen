using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kitchen.CommonModel.Container;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.Model;
using Kitchen.CommonModel.ViewModel.Ingredient;
using Kitchen.Repository.Repository;

namespace Kitchen.CoreService.Service
{
    public class IngredientService : ICoreService<IngredientViewModel>
    {
        private IngredientRepository ingredientRepository;

        public IngredientService(IngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }
        public async Task<ServiceResultModel<IngredientViewModel>> AddAsync(IngredientViewModel model)
        {
            var result = new ServiceResultModel<IngredientViewModel>();
            try
            {
                var ingredient = new Ingredient
                {
                    Name = model.Name
                };
                await ingredientRepository.InsertAsync(ingredient);
                if (ingredient.Id == -1)
                    throw new Exception();
                //add mappings for automapper
                result.Item = Mapper.Map<Ingredient, IngredientViewModel>(ingredient);
                result.Code = ingredient.Id;
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

        public Task<ServiceResultModel<IngredientViewModel>> UpdateAsync(IngredientViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResultModel<IngredientViewModel>> DeleteAsync(IngredientViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<IngredientViewModel>> GetDefaultContainer(int start, SearchCriteria criteria, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<IngredientViewModel>> SearchByKeyContainer(int start, SearchCriteria criteria, string key, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public BasicPaginationResultContainer<IngredientViewModel> GetEmptyContainer()
        {
            throw new NotImplementedException();
        }
    }
}
