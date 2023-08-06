using Api.Base.BaseModel;

namespace Api.DataAccess.Models
{
    public class Message : IdBaseModel
    {
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime SentDate { get; set; }

        public int SenderUserId { get; set; }

        public int ReceiverUserId { get; set; } 
    }
}
