using Api.Base.BaseResponse;
using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;

namespace Api.Business;

public class MessageService : GenericService<Message, MessageRequest, MessageResponse>, IMessageService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    //public int GetSenderId()
    //{
    //    var d = _unitOfWork.MessageRepository.GetAllAsQueryable().OrderByDescending(x => x.SenderUserId).FirstOrDefault();
    //    return d.SenderUserId;
    //}

    //public override ApiResponse<MessageResponse> Insert(MessageRequest request)
    //{
    //    request.SenderUserId = GetSenderId();
    //    return base.Insert(request);
    //}

    //public List<Message> GetMessages(int userId)
    //{
    //    var messages = _unitOfWork.MessageRepository.Where(x => x.ReceiverUserId == userId).ToList();
    //    return messages;
    //}

    public ApiResponse<List<MessageResponse>> GetAllById(int userId)
    {
        try
        {
            var entityList = _unitOfWork.DynamicRepository<Message>()
            .GetAll()
            .Where(m => m.ReceiverUserId == userId) 
            .ToList();

            var map = _mapper.Map<List<Message>, List<MessageResponse>>(entityList);
            if (entityList.Count == 0)
            {
                return new ApiResponse<List<MessageResponse>>("Listede kayıt bulunamadı.");
            }
            return new ApiResponse<List<MessageResponse>>(map);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<MessageResponse>>(ex.Message);
        }
    }

    public Message GetMessageById(int id)
    {
        var message = _unitOfWork.DynamicRepository<Message>()
            .GetAll()
            .Where(m => m.Id == id)
            .FirstOrDefault();

        return message;
    }
 
}
