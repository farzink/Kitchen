using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kitchen.CommonModel.Container;
using Kitchen.CommonModel.Model;
using Kitchen.CommonModel.ViewModel;
using Kitchen.Repository.Repository;
using Profile = Kitchen.CommonModel.DataModel.Profile;

namespace Kitchen.CoreService.Service
{
    public class ProfileService: ICoreService<ProfileViewModel>
    {
        private readonly ProfileRepository profileRepository;

        public ProfileService(ProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }
        public async Task<ServiceResultModel<ProfileViewModel>> AddAsync(ProfileViewModel model)
        {
            var result = new ServiceResultModel<ProfileViewModel>();
            try
            {
                var profile = new Profile
                {
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    IsActive = true
                };
                await profileRepository.InsertAsync(profile);
                if (profile.Id == -1)
                    throw new Exception();
                //add mappings for automapper
                result.Item = Mapper.Map<Profile, ProfileViewModel>(profile);
                result.Code = profile.Id;
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

        public Task<ServiceResultModel<ProfileViewModel>> UpdateAsync(ProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResultModel<ProfileViewModel>> DeleteAsync(ProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<ProfileViewModel>> GetDefaultContainer(int start, SearchCriteria criteria, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public Task<BasicPaginationResultContainer<ProfileViewModel>> SearchByKeyContainer(int start, SearchCriteria criteria, string key, bool isActive = true, int size = 10)
        {
            throw new NotImplementedException();
        }

        public BasicPaginationResultContainer<ProfileViewModel> GetEmptyContainer()
        {
            throw new NotImplementedException();
        }
    }
}
