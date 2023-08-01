using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{ 

}
