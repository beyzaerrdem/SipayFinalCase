using Api.Base.BaseResponse;
using Api.Business;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Authorize(Roles = "admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public ApiResponse<List<MessageResponse>> GetMessage()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId");
            string userId = "";
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            var entity = _messageService.GetAllById(Convert.ToInt32(userId));
            return entity;
        }

        [HttpPost("{id}")]
        public ApiResponse Post([FromBody] MessageRequest request, int id)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId");

            if (userIdClaim != null)
            {
                string userId = userIdClaim.Value;
                request.SenderUserId = Convert.ToInt32(userId);
                request.SentDate = DateTime.UtcNow;
            }

            var entity = _messageService.Insert(request);
            return entity;
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] MessageRequest request)
        {
            var message = _messageService.GetMessageById(id);
            message.IsRead = true;
            request.IsRead = message.IsRead;
            request.SenderUserId= message.SenderUserId;
            request.SentDate = DateTime.UtcNow;
            request.ReceiverUserId = message.ReceiverUserId;
            request.Content = message.Content;
            var response = _messageService.Update(id, request);
            return response;
        }
    }
}
