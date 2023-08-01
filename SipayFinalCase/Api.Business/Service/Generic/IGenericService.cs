using Api.Base.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business.Service.Generic
{
    public interface IGenericService<TEntity, TRequest, TResponse>
    {
        ApiResponse<List<TResponse>> GetAll();
        ApiResponse<TResponse> GetById(int id);
        ApiResponse Insert(TRequest request);
        ApiResponse Update(int id, TRequest request);
        ApiResponse Delete(int id);
    }
}
