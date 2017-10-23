using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.CommonModel.Enum;

namespace Kitchen.CommonModel.Container
{
    public class SearchCriteria
    {
        public int BussinessId { get; set; }
        public int ProfileId { get; set; }
        public int ParentId { get; set; }
        public string Path { get; set; }
        public SortTypes SortOrder { get; set; }
    }
}
