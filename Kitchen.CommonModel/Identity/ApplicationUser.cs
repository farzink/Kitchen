using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Microsoft.AspNetCore.Identity;

namespace Kitchen.CommonModel.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
