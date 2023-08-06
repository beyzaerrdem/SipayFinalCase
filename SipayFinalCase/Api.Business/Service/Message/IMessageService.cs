using Api.Base.BaseResponse;
using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;

namespace Api.Business;

public interface IMessageService : IGenericService<Message, MessageRequest, MessageResponse>
{
    ApiResponse<List<MessageResponse>> GetAllById(int userId);
    Message GetMessageById(int id);
}
