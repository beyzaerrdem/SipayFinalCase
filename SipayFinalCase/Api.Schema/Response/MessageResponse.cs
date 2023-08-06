using Api.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Response
{
    public class MessageResponse
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime SentDate { get; set; }

        public int SenderUserId { get; set; }

        public int ReceiverUserId { get; set; }
    }
}
