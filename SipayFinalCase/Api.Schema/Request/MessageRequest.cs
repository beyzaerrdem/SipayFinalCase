using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Schema.Request
{
    public class MessageRequest
    {
        public int ReceiverUserId { get; set; }

        [JsonIgnore]
        public int SenderUserId { get; set; }

        public string Content { get; set; }

        [JsonIgnore]
        public DateTime SentDate { get; set; }

        [JsonIgnore]
        public bool IsRead { get; set; }
    }
}
