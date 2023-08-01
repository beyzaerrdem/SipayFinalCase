using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Request
{
    public class VehicleRequest
    {
        public int UserId { get; set; }

        public string? PlateNo { get; set; }
    }
}
