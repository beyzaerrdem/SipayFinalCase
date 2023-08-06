using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Response
{
    public class UserResponse
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Tc { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public List<InvoiceResponse> Invoices { get; set; }
    }
}
