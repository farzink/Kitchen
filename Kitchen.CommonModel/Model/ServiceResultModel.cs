using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.CommonModel.Model
{
    public class ServiceResultModel<T>
    {
        public ServiceResultModel()
        {
        }

        public ServiceResultModel(int version)
        {
            this.Version = version;            
        }
        public T Item { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public int Version { get; set; }
    }
}
