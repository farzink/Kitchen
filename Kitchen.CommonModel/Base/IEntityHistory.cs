using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Base
{
    public interface IEntityHistory<T>
    {
        T CreationDateTime { get; set; }
        T UpdatedDateTime { get; set; }
    }
}
