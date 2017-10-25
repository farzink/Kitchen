using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Api.Controllers.Base;
using Kitchen.Api.Filter;
using Kitchen.CoreService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using Newtonsoft.Json;
using Kitchen.CommonModel.Model;
using Kitchen.CommonModel.ViewModel.DishCategory;

namespace Kitchen.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ProfilesController: BaseController
    {
        private IHostingEnvironment environment;

        public ProfilesController(ProfileService profileService, IHostingEnvironment environment, IConfigurationRoot configuration): base(profileService, configuration)
        {
            this.environment = environment;
        }
        [AllowAnonymous]
        [HttpGet("settings/data")]
        public async Task<IActionResult> GetData()
        {
            var result = new ServiceResultModel<ClientConfiguration>(Version);
            try
            {
                result.Item = new ClientConfiguration();
                result.Item.DishCategories = new List<DishCategoryViewModel>();
                result.Item.DishCategories.Add(new DishCategoryViewModel
                {
                    Title = "دسر"
                });

                result.Item.DishCategories.Add(new DishCategoryViewModel
                {
                    Title = "غذای اصلی"
                });
                var categorories = new[] {"a", "b"};
                var data = new
                {
                    Categorories = categorories
                };
                using (StreamWriter sw = new StreamWriter("data.json"))
                {
                    sw.Write(JsonConvert.SerializeObject(data));
                }
                //return Ok(JsonConvert.SerializeObject(data));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
