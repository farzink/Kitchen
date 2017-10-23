using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kitchen.CommonModel.Base;
using Kitchen.CommonModel.Container;
using Kitchen.CommonModel.Model;

namespace Kitchen.CoreService
{
    interface ICoreService<T> where T : class, IEntity<int>
    {
        Task<ServiceResultModel<T>> AddAsync(T model);
        Task<ServiceResultModel<T>> UpdateAsync(T model);
        Task<ServiceResultModel<T>> DeleteAsync(T model);
        Task<BasicPaginationResultContainer<T>> GetDefaultContainer(int start, SearchCriteria criteria, bool isActive = true, int size = 10);
        Task<BasicPaginationResultContainer<T>> SearchByKeyContainer(int start, SearchCriteria criteria, string key, bool isActive = true, int size = 10);
        BasicPaginationResultContainer<T> GetEmptyContainer();
    }
}
