using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Schema.Request
{
    public class ApartmentRequest
    {
        public string Block { get; set; }

        public string Type { get; set; }

        public int Floor { get; set; }

        public int ApartmentNo { get; set; }
    }
}
