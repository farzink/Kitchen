﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
