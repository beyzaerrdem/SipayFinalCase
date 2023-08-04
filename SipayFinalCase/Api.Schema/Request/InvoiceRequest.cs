namespace Api.Schema.Request
{
    public class InvoiceRequest
    {
        public int UserId { get; set; }

        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }
    }
}
