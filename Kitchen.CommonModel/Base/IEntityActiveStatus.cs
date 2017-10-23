using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Base
{
    public interface IEntityActiveStatus<T>
    {
        T IsActive { get; set; }
    }
}
