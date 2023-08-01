using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Response
{
    public class InvoiceResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }
    }
}
