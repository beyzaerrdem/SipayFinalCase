using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? PlateNo { get; set; }
    }
}
