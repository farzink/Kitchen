using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Container
{
    public interface IPaginativeResult<T, Q>
    {
        Q CurrentIndex { get; set; }
        bool HasNext { get; set; }
        bool HasPrevious { get; set; }
        IList<T> Items { get; set; }
    }
}
