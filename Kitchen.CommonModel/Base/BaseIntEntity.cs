using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Base
{
    public class BaseIntEntity : IEntity<int>, IEntityHistory<DateTime>, IEntityActiveStatus<bool>
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
