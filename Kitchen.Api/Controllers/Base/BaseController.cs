using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.CommonModel.ViewModel;
using Kitchen.CoreService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Kitchen.Api.Controllers.Base
{
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class BaseController: Controller
    {
        protected ProfileViewModel Profile;
        protected ProfileService ProfileService;
        protected IConfigurationRoot Configuration;
        protected int Version;
        public BaseController(ProfileService profileService, IConfigurationRoot configuration)
        {
            this.ProfileService = profileService;
            this.Configuration = configuration;
            this.Version = int.Parse(Configuration["VersionManager:Current"]);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //var profileId = int.Parse(User.Claims.FirstOrDefault(e => e.Type.Equals("pid")).Value);
            //Profile = ProfileService.GetProfileByIdForBase(profileId).Item;
        }
    }
}
