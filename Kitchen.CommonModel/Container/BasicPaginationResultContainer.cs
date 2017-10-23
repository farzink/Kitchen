using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Base;

namespace Kitchen.CommonModel.Container
{
    public class BasicPaginationResultContainer<T> : IPaginativeResult<T, int> where T : class, IEntity<int>
    {
        public int CurrentIndex { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public IList<T> Items { get; set; }
        public bool KermFactor { get; set; }
        public int Total { get; set; }
    }
}
