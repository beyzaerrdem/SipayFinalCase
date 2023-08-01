using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Request
{
    public class InvoiceRequest
    {
        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }
    }
}
