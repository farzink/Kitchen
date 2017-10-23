using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.DataModel;
using Kitchen.Data;

namespace Kitchen.Repository.Repository
{
    public class ProfileRepository : SqlRepository<MainContext, Profile>
    {
        public ProfileRepository(MainContext context) : base(context)
        {
        }
    }
}
