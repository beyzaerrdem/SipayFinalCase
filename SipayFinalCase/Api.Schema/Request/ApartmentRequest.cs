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
