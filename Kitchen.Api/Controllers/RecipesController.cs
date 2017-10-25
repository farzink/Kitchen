using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Api.Controllers.Base;
using Kitchen.Api.Filter;
using Kitchen.CommonModel.Model;
using Kitchen.CoreService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Kitchen.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class RecipesController: BaseController
    {
        public RecipesController(ProfileService profileService, IConfigurationRoot configuration): base(profileService, configuration)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            ServiceResultModel<int> model = new ServiceResultModel<int>(Version);
            return Ok(model);
        }
    }
}
