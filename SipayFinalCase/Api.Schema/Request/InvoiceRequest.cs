namespace Api.Schema.Request
{
    public class InvoiceRequest
    {
        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }
    }
}
