using Api.Schema.Response;

namespace Api.Schema.Request
{
    public class UserRequest
    {
        public int ApartmentId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Tc { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; } //?

        public List<VehicleRequest> Vehicles { get; set; }
    }
}
